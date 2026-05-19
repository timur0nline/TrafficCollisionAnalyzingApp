using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Анализ_данных_о_ДТП
{

    public partial class mainForm : Form
    {
        public static string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        public static string pythonDirectory = baseDirectory;
        private DataTable currentDirectoryTable;
        private string currentDirectoryName;
        private DataTable accidentsTable;
        private DataTable vehiclesTable;
        private readonly System.Collections.Generic.Dictionary<string, DataTable> directoryCache = new System.Collections.Generic.Dictionary<string, DataTable>();
        public mainForm()
        {
            InitializeComponent();
        }
        static void SetDoubleBuffer(Control dgv, bool DoubleBuffered)
        {
            typeof(Control).InvokeMember("DoubleBuffered",BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,null, dgv, new object[] {DoubleBuffered});
        }
        private DataTable GetDirectoryCached(string tableName)
        {
            if (!directoryCache.ContainsKey(tableName))
            {
                directoryCache[tableName] = DirectoryManager.GetDirectoryTable(tableName);
            }

            return directoryCache[tableName];
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            groupByComboBox.SelectedIndex = 0;
            groupByComboBox2.SelectedIndex = 0;
            metricComboBox.SelectedIndex = 0;
            chartTypeComboBox.SelectedIndex = 0;

            SetDoubleBuffer(dataGridView1, true);
            SetDoubleBuffer(dataGridView2, true);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;

            DatabaseManager.InitializeDatabase();

            if (File.Exists(Path.Combine(baseDirectory, "traffic.db")))
            {
                tabControl1.Enabled = true;
                addButton.Enabled = true;
                LoadAccidents();
                LoadVehicles();

                ConfigureAccidentGrid();
                ConfigureVehicleGrid();
            }
        }
        private async void ParseData(bool clear = true)
        {
            fileSelectButton.Enabled = false;
            addButton.Enabled = false;
            tabControl1.Enabled = false;

            Cursor = Cursors.WaitCursor;

            await Task.Run(() =>
            {
                string scriptPath = Path.Combine(pythonDirectory, "ParseData.py");

                ProcessStartInfo start = new ProcessStartInfo();

                start.FileName = "py";
                start.Arguments = $"\"{scriptPath}\"";
                start.WorkingDirectory = pythonDirectory;

                start.UseShellExecute = false;
                start.CreateNoWindow = true;

                start.RedirectStandardError = true;
                start.RedirectStandardOutput = true;

                Process process = Process.Start(start);

                string errors = process.StandardError.ReadToEnd();

                process.WaitForExit();

                if (!string.IsNullOrWhiteSpace(errors))
                {
                    throw new Exception(errors);
                }

                ImportManager.ImportData(clear);
            });

            directoryCache.Clear();

            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;

            dataGridView1.Columns.Clear();
            dataGridView2.Columns.Clear();

            LoadAccidents();
            LoadVehicles();

            ConfigureAccidentGrid();
            ConfigureVehicleGrid();

            Cursor = Cursors.Default;

            fileSelectButton.Enabled = true;
            addButton.Enabled = true;
            tabControl1.Enabled = true;

            MessageBox.Show("Импорт завершен");
        }
        private void LoadAccidents()
        {
            accidentsTable = AccidentManager.GetAccidentsTable();
            dataGridView1.DataSource = accidentsTable;
        }
        private void LoadVehicles()
        {
            vehiclesTable = VehicleManager.GetVehiclesTable();
            dataGridView2.DataSource = vehiclesTable;
        }
        private void ConfigureAccidentGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            AddTextColumn(dataGridView1, "AccidentID", "Номер ДТП", true);
            AddTextColumn(dataGridView1, "Date", "Дата");
            AddTextColumn(dataGridView1, "Time", "Время");
            AddTextColumn(dataGridView1, "Latitude", "Широта");
            AddTextColumn(dataGridView1, "Longitude", "Долгота");

            AddComboColumn(dataGridView1, "AccidentTypeID", "Вид ДТП", "AccidentTypes", "AccidentTypeID");
            AddComboColumn(dataGridView1, "DistrictID", "Район", "Districts", "DistrictID");
            AddComboColumn(dataGridView1, "WeatherConditionID", "Погода", "WeatherConditions", "WeatherConditionID");
            AddComboColumn(dataGridView1, "RoadStateID", "Состояние дороги", "RoadStates", "RoadStateID");
            AddComboColumn(dataGridView1, "LightingConditionID", "Освещение", "LightingConditions", "LightingConditionID");

            AddTextColumn(dataGridView1, "VehicleCount", "Количество ТС");
            AddTextColumn(dataGridView1, "ParticipantCount", "Участники");
            AddTextColumn(dataGridView1, "DeadCount", "Погибшие");
            AddTextColumn(dataGridView1, "InjuredCount", "Раненые");
            dataGridView1.DataSource = accidentsTable;
        }
        private void ConfigureVehicleGrid()
        {
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.Columns.Clear();

            AddTextColumn(dataGridView2, "VehicleID", "ID", true);
            AddTextColumn(dataGridView2, "AccidentID", "Номер ДТП");
            AddTextColumn(dataGridView2, "VehicleNumber", "Номер ТС");

            AddComboColumn(dataGridView2, "VehicleTypeID", "Тип ТС", "VehicleTypes", "VehicleTypeID");
            AddTextColumn(dataGridView2, "Year", "Год выпуска");
            AddComboColumn(dataGridView2, "VehicleModelID", "Марка/модель", "VehicleModels", "VehicleModelID");
            AddComboColumn(dataGridView2, "OwnershipTypeID", "Форма собственности", "OwnershipTypes", "OwnershipTypeID");
            AddComboColumn(dataGridView2, "ColorID", "Цвет", "Colors", "ColorID");
            AddComboColumn(dataGridView2, "DriveTypeID", "Тип привода", "DriveTypes", "DriveTypeID");
            AddComboColumn(dataGridView2, "HitAndRunStatusID", "Оставление места ДТП", "HitAndRunStatuses", "HitAndRunStatusID");
            AddTextColumn(dataGridView2, "TechnicalIssues", "Технические неисправности");

            dataGridView2.DataSource = vehiclesTable;
        }
        private void AddTextColumn(DataGridView grid, string property, string header, bool readOnly = false)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();

            column.DataPropertyName = property;
            column.HeaderText = header;
            column.Name = property;
            column.ReadOnly = readOnly;

            grid.Columns.Add(column);
        }
        private void AddComboColumn(DataGridView grid, string property, string header, string tableName, string idColumn)
        {
            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
            column.DataPropertyName = property;
            column.HeaderText = header;
            column.Name = property;
            column.DataSource = GetDirectoryCached(tableName);
            column.DisplayMember = "Name";
            column.ValueMember = idColumn;
            column.ValueType = typeof(int);
            grid.Columns.Add(column);
        }
        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }


        private void fileSelectButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Карточки ДТП (*.csv)|*.csv";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string selectedFileName = openFileDialog1.FileName;
            File.Copy(selectedFileName, Path.Combine(pythonDirectory, "data.csv"), true);
            ParseData();

        }
        private void buildAnalysisButton_Click(object sender, EventArgs e)
        {
            string groupBy;
            string dataset;
            if (accidentRadioButton.Checked)
            {
                groupBy = groupByComboBox.Text;
                dataset = "ДТП";
            }
            else
            {
                groupBy = groupByComboBox2.Text;
                dataset = "Транспортные средства";
            }
            string metric = metricComboBox.Text;
            string chartType = chartTypeComboBox.Text;
            string scriptPath = Path.Combine(pythonDirectory, "Analyze.py");
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "py";
            start.Arguments =
                $"\"{scriptPath}\" " +
                $"\"{dataset}\" " +
                $"\"{groupBy}\" " +
                $"\"{metric}\" " +
                $"\"{chartType}\"";

            start.WorkingDirectory = pythonDirectory;
            start.RedirectStandardOutput = true;
            start.UseShellExecute = false;
            start.CreateNoWindow = true;
            Process process = Process.Start(start);
            string errors = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            if (!string.IsNullOrWhiteSpace(errors))
            {
                MessageBox.Show(errors);
            }
            LoadChart();
        }
        private void LoadChart()
        {

            string chartPath = Path.Combine(pythonDirectory, "chart.png");
            if (!File.Exists(chartPath))
            {
                return;
            }
            if (analysisPictureBox.Image != null)
            {
                analysisPictureBox.Image.Dispose();
            }
            using (Bitmap tempBitmap = new Bitmap(chartPath))
            {
                analysisPictureBox.Image = new Bitmap(tempBitmap);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void accidentRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            groupByComboBox.Visible = true;
            groupByComboBox2.Visible = false;
            groupByComboBox.SelectedIndex = 0;
        }

        private void VehiclesRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            groupByComboBox.Visible = false;
            groupByComboBox2.Visible = true;
            groupByComboBox2.SelectedIndex = 0;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image|*.png";
                saveFileDialog.Title = "Сохранить изображение";
                saveFileDialog.DefaultExt = "png";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    analysisPictureBox.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
        }

        private void deleteDirectoryButton_Click(object sender, EventArgs e)
        {
            if (directoriesGridView.CurrentRow == null)
            {
                return;
            }
            directoriesGridView.Rows.Remove(directoriesGridView.CurrentRow);
        }

        private void directoriesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (directoriesListBox.Text)
            {
                case "Виды ДТП":
                    currentDirectoryName = "AccidentTypes";
                    break;

                case "Районы":
                    currentDirectoryName = "Districts";
                    break;

                case "Погода":
                    currentDirectoryName = "WeatherConditions";
                    break;

                case "Состояние дороги":
                    currentDirectoryName = "RoadStates";
                    break;

                case "Освещение":
                    currentDirectoryName = "LightingConditions";
                    break;

                case "Типы ТС":
                    currentDirectoryName = "VehicleTypes";
                    break;

                case "Марки ТС":
                    currentDirectoryName = "VehicleModels";
                    break;

                case "Формы собственности":
                    currentDirectoryName = "OwnershipTypes";
                    break;

                case "Цвета":
                    currentDirectoryName = "Colors";
                    break;

                case "Типы привода":
                    currentDirectoryName = "DriveTypes";
                    break;

                case "Статусы оставления места ДТП":
                    currentDirectoryName = "HitAndRunStatuses";
                    break;
            }
            currentDirectoryTable = DirectoryManager.GetDirectoryTable(currentDirectoryName);
            directoriesGridView.DataSource = currentDirectoryTable;
        }

        private void saveDirectoryButton_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryManager.UpdateDirectory(currentDirectoryTable,currentDirectoryName);
                ConfigureAccidentGrid();
                ConfigureVehicleGrid();
                MessageBox.Show("Изменения сохранены");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addDirectoryButton_Click(object sender, EventArgs e)
        {
            if (currentDirectoryTable == null)
            {
                return;
            }
            DataRow row = currentDirectoryTable.NewRow();
            currentDirectoryTable.Rows.Add(row);
        }

        private void saveAccidentsButton_Click(object sender, EventArgs e)
        {
            try
            {
                AccidentManager.SaveChanges(accidentsTable);
                MessageBox.Show("Изменения сохранены");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addAccidentButton_Click(object sender, EventArgs e)
        {
            if (accidentsTable == null)
            {
                return;
            }

            DataRow row = accidentsTable.NewRow();

            row["Date"] = DateTime.Now.ToString("dd.MM.yyyy");
            row["Time"] = DateTime.Now.ToString("HH:mm");

            row["AccidentTypeID"] = 1;
            row["DistrictID"] = 1;
            row["WeatherConditionID"] = 1;
            row["RoadStateID"] = 1;
            row["LightingConditionID"] = 1;

            row["VehicleCount"] = 0;
            row["ParticipantCount"] = 0;
            row["DeadCount"] = 0;
            row["InjuredCount"] = 0;

            accidentsTable.Rows.Add(row);
        }

        private void deleteAccidentButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }
            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Карточки ДТП (*.csv)|*.csv";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string selectedFileName = openFileDialog1.FileName;
            File.Copy(selectedFileName, Path.Combine(pythonDirectory, "data.csv"), true);
            ParseData(false);
            tabControl1.Enabled = true;
        }

        private void addVehicleButton_Click(object sender, EventArgs e)
        {
            if (vehiclesTable == null)
            {
                return;
            }

            DataRow row = vehiclesTable.NewRow();

            row["VehicleTypeID"] = 1;
            row["VehicleModelID"] = 1;
            row["OwnershipTypeID"] = 1;
            row["ColorID"] = 1;
            row["DriveTypeID"] = 1;
            row["HitAndRunStatusID"] = 1;

            row["Year"] = DateTime.Now.Year;

            row["TechnicalIssues"] = "";

            vehiclesTable.Rows.Add(row);
        }

        private void saveVehiclesButton_Click(object sender, EventArgs e)
        {
            try
            {
                VehicleManager.SaveChanges(vehiclesTable);

                ConfigureVehicleGrid();

                MessageBox.Show("Изменения сохранены");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteVehicleButton_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow == null)
            {
                return;
            }

            dataGridView2.Rows.Remove(dataGridView2.CurrentRow);
        }
    }
}
