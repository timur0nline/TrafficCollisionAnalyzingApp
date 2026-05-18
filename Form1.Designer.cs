namespace Анализ_данных_о_ДТП
{
    partial class mainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.fileSelectButton = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.SaveButton = new System.Windows.Forms.Button();
            this.groupByComboBox2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.VehiclesRadioButton = new System.Windows.Forms.RadioButton();
            this.accidentRadioButton = new System.Windows.Forms.RadioButton();
            this.buildAnalysisButton = new System.Windows.Forms.Button();
            this.metricComboBox = new System.Windows.Forms.ComboBox();
            this.chartTypeComboBox = new System.Windows.Forms.ComboBox();
            this.groupByComboBox = new System.Windows.Forms.ComboBox();
            this.analysisPictureBox = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.deleteVehicleButton = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.saveVehiclesButton = new System.Windows.Forms.Button();
            this.addVehicleButton = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.deleteAccidentButton = new System.Windows.Forms.Button();
            this.saveAccidentsButton = new System.Windows.Forms.Button();
            this.addAccidentButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.directoriesGridView = new System.Windows.Forms.DataGridView();
            this.saveDirectoryButton = new System.Windows.Forms.Button();
            this.deleteDirectoryButton = new System.Windows.Forms.Button();
            this.addDirectoryButton = new System.Windows.Forms.Button();
            this.directoriesListBox = new System.Windows.Forms.ListBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.analysisPictureBox)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.directoriesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // fileSelectButton
            // 
            this.fileSelectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fileSelectButton.Location = new System.Drawing.Point(16, 637);
            this.fileSelectButton.Name = "fileSelectButton";
            this.fileSelectButton.Size = new System.Drawing.Size(184, 29);
            this.fileSelectButton.TabIndex = 1;
            this.fileSelectButton.Text = "Создать новую базу данных";
            this.fileSelectButton.UseVisualStyleBackColor = true;
            this.fileSelectButton.Click += new System.EventHandler(this.fileSelectButton_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.SaveButton);
            this.tabPage3.Controls.Add(this.groupByComboBox2);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.VehiclesRadioButton);
            this.tabPage3.Controls.Add(this.accidentRadioButton);
            this.tabPage3.Controls.Add(this.buildAnalysisButton);
            this.tabPage3.Controls.Add(this.metricComboBox);
            this.tabPage3.Controls.Add(this.chartTypeComboBox);
            this.tabPage3.Controls.Add(this.groupByComboBox);
            this.tabPage3.Controls.Add(this.analysisPictureBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1260, 593);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Анализ";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(8, 241);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(160, 29);
            this.SaveButton.TabIndex = 12;
            this.SaveButton.Text = "Сохранить график";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // groupByComboBox2
            // 
            this.groupByComboBox2.FormattingEnabled = true;
            this.groupByComboBox2.Items.AddRange(new object[] {
            "Тип ТС",
            "Марка/модель ТС",
            "Год выпуска",
            "Цвет",
            "Расположение руля, тип привода",
            "Технические неисправности"});
            this.groupByComboBox2.Location = new System.Drawing.Point(8, 71);
            this.groupByComboBox2.MinimumSize = new System.Drawing.Size(143, 0);
            this.groupByComboBox2.Name = "groupByComboBox2";
            this.groupByComboBox2.Size = new System.Drawing.Size(160, 21);
            this.groupByComboBox2.TabIndex = 11;
            this.groupByComboBox2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Тип графика";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Показатель";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Группировка";
            // 
            // VehiclesRadioButton
            // 
            this.VehiclesRadioButton.AutoSize = true;
            this.VehiclesRadioButton.Location = new System.Drawing.Point(9, 48);
            this.VehiclesRadioButton.Name = "VehiclesRadioButton";
            this.VehiclesRadioButton.Size = new System.Drawing.Size(149, 17);
            this.VehiclesRadioButton.TabIndex = 7;
            this.VehiclesRadioButton.Text = "Транспортные средства";
            this.VehiclesRadioButton.UseVisualStyleBackColor = true;
            this.VehiclesRadioButton.CheckedChanged += new System.EventHandler(this.VehiclesRadioButton_CheckedChanged);
            // 
            // accidentRadioButton
            // 
            this.accidentRadioButton.AutoSize = true;
            this.accidentRadioButton.Checked = true;
            this.accidentRadioButton.Location = new System.Drawing.Point(9, 25);
            this.accidentRadioButton.Name = "accidentRadioButton";
            this.accidentRadioButton.Size = new System.Drawing.Size(49, 17);
            this.accidentRadioButton.TabIndex = 6;
            this.accidentRadioButton.TabStop = true;
            this.accidentRadioButton.Text = "ДТП";
            this.accidentRadioButton.UseVisualStyleBackColor = true;
            this.accidentRadioButton.CheckedChanged += new System.EventHandler(this.accidentRadioButton_CheckedChanged);
            // 
            // buildAnalysisButton
            // 
            this.buildAnalysisButton.Location = new System.Drawing.Point(8, 206);
            this.buildAnalysisButton.Name = "buildAnalysisButton";
            this.buildAnalysisButton.Size = new System.Drawing.Size(160, 29);
            this.buildAnalysisButton.TabIndex = 4;
            this.buildAnalysisButton.Text = "Построить";
            this.buildAnalysisButton.UseVisualStyleBackColor = true;
            this.buildAnalysisButton.Click += new System.EventHandler(this.buildAnalysisButton_Click);
            // 
            // metricComboBox
            // 
            this.metricComboBox.FormattingEnabled = true;
            this.metricComboBox.Items.AddRange(new object[] {
            "Количество ДТП",
            "Число погибших",
            "Число раненых",
            "Число участников",
            "Количество ТС"});
            this.metricComboBox.Location = new System.Drawing.Point(8, 118);
            this.metricComboBox.MinimumSize = new System.Drawing.Size(143, 0);
            this.metricComboBox.Name = "metricComboBox";
            this.metricComboBox.Size = new System.Drawing.Size(160, 21);
            this.metricComboBox.TabIndex = 1;
            // 
            // chartTypeComboBox
            // 
            this.chartTypeComboBox.FormattingEnabled = true;
            this.chartTypeComboBox.Items.AddRange(new object[] {
            "Столбчатая диаграмма",
            "Круговая диаграмма"});
            this.chartTypeComboBox.Location = new System.Drawing.Point(8, 164);
            this.chartTypeComboBox.MinimumSize = new System.Drawing.Size(143, 0);
            this.chartTypeComboBox.Name = "chartTypeComboBox";
            this.chartTypeComboBox.Size = new System.Drawing.Size(160, 21);
            this.chartTypeComboBox.TabIndex = 2;
            // 
            // groupByComboBox
            // 
            this.groupByComboBox.FormattingEnabled = true;
            this.groupByComboBox.Items.AddRange(new object[] {
            "Район",
            "Состояние погоды",
            "Освещение",
            "Вид ДТП",
            "Состояние проезжей части"});
            this.groupByComboBox.Location = new System.Drawing.Point(8, 71);
            this.groupByComboBox.Name = "groupByComboBox";
            this.groupByComboBox.Size = new System.Drawing.Size(160, 21);
            this.groupByComboBox.TabIndex = 0;
            // 
            // analysisPictureBox
            // 
            this.analysisPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.analysisPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.analysisPictureBox.Location = new System.Drawing.Point(174, 6);
            this.analysisPictureBox.Name = "analysisPictureBox";
            this.analysisPictureBox.Size = new System.Drawing.Size(1067, 579);
            this.analysisPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.analysisPictureBox.TabIndex = 5;
            this.analysisPictureBox.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.deleteVehicleButton);
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Controls.Add(this.saveVehiclesButton);
            this.tabPage2.Controls.Add(this.addVehicleButton);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1260, 593);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ТС";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // deleteVehicleButton
            // 
            this.deleteVehicleButton.Location = new System.Drawing.Point(6, 35);
            this.deleteVehicleButton.Name = "deleteVehicleButton";
            this.deleteVehicleButton.Size = new System.Drawing.Size(75, 23);
            this.deleteVehicleButton.TabIndex = 12;
            this.deleteVehicleButton.Text = "Удалить";
            this.deleteVehicleButton.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(87, 6);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(1154, 579);
            this.dataGridView2.TabIndex = 0;
            // 
            // saveVehiclesButton
            // 
            this.saveVehiclesButton.Location = new System.Drawing.Point(6, 65);
            this.saveVehiclesButton.Name = "saveVehiclesButton";
            this.saveVehiclesButton.Size = new System.Drawing.Size(75, 23);
            this.saveVehiclesButton.TabIndex = 10;
            this.saveVehiclesButton.Text = "Сохранить";
            this.saveVehiclesButton.UseVisualStyleBackColor = true;
            // 
            // addVehicleButton
            // 
            this.addVehicleButton.Location = new System.Drawing.Point(6, 6);
            this.addVehicleButton.Name = "addVehicleButton";
            this.addVehicleButton.Size = new System.Drawing.Size(75, 23);
            this.addVehicleButton.TabIndex = 11;
            this.addVehicleButton.Text = "Добавить";
            this.addVehicleButton.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.deleteAccidentButton);
            this.tabPage1.Controls.Add(this.saveAccidentsButton);
            this.tabPage1.Controls.Add(this.addAccidentButton);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1260, 593);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ДТП";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // deleteAccidentButton
            // 
            this.deleteAccidentButton.Location = new System.Drawing.Point(6, 35);
            this.deleteAccidentButton.Name = "deleteAccidentButton";
            this.deleteAccidentButton.Size = new System.Drawing.Size(75, 23);
            this.deleteAccidentButton.TabIndex = 9;
            this.deleteAccidentButton.Text = "Удалить";
            this.deleteAccidentButton.UseVisualStyleBackColor = true;
            this.deleteAccidentButton.Click += new System.EventHandler(this.deleteAccidentButton_Click);
            // 
            // saveAccidentsButton
            // 
            this.saveAccidentsButton.Location = new System.Drawing.Point(6, 65);
            this.saveAccidentsButton.Name = "saveAccidentsButton";
            this.saveAccidentsButton.Size = new System.Drawing.Size(75, 23);
            this.saveAccidentsButton.TabIndex = 1;
            this.saveAccidentsButton.Text = "Сохранить";
            this.saveAccidentsButton.UseVisualStyleBackColor = true;
            this.saveAccidentsButton.Click += new System.EventHandler(this.saveAccidentsButton_Click);
            // 
            // addAccidentButton
            // 
            this.addAccidentButton.Location = new System.Drawing.Point(6, 6);
            this.addAccidentButton.Name = "addAccidentButton";
            this.addAccidentButton.Size = new System.Drawing.Size(75, 23);
            this.addAccidentButton.TabIndex = 8;
            this.addAccidentButton.Text = "Добавить";
            this.addAccidentButton.UseVisualStyleBackColor = true;
            this.addAccidentButton.Click += new System.EventHandler(this.addAccidentButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(87, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1170, 584);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Enabled = false;
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1268, 619);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.directoriesGridView);
            this.tabPage4.Controls.Add(this.saveDirectoryButton);
            this.tabPage4.Controls.Add(this.deleteDirectoryButton);
            this.tabPage4.Controls.Add(this.addDirectoryButton);
            this.tabPage4.Controls.Add(this.directoriesListBox);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1260, 593);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Справочники";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // directoriesGridView
            // 
            this.directoriesGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.directoriesGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.directoriesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.directoriesGridView.Location = new System.Drawing.Point(189, 6);
            this.directoriesGridView.Name = "directoriesGridView";
            this.directoriesGridView.Size = new System.Drawing.Size(1052, 579);
            this.directoriesGridView.TabIndex = 9;
            // 
            // saveDirectoryButton
            // 
            this.saveDirectoryButton.Location = new System.Drawing.Point(6, 217);
            this.saveDirectoryButton.Name = "saveDirectoryButton";
            this.saveDirectoryButton.Size = new System.Drawing.Size(177, 23);
            this.saveDirectoryButton.TabIndex = 8;
            this.saveDirectoryButton.Text = "Сохранить";
            this.saveDirectoryButton.UseVisualStyleBackColor = true;
            this.saveDirectoryButton.Click += new System.EventHandler(this.saveDirectoryButton_Click);
            // 
            // deleteDirectoryButton
            // 
            this.deleteDirectoryButton.Location = new System.Drawing.Point(6, 188);
            this.deleteDirectoryButton.Name = "deleteDirectoryButton";
            this.deleteDirectoryButton.Size = new System.Drawing.Size(177, 23);
            this.deleteDirectoryButton.TabIndex = 7;
            this.deleteDirectoryButton.Text = "Удалить";
            this.deleteDirectoryButton.UseVisualStyleBackColor = true;
            this.deleteDirectoryButton.Click += new System.EventHandler(this.deleteDirectoryButton_Click);
            // 
            // addDirectoryButton
            // 
            this.addDirectoryButton.Location = new System.Drawing.Point(6, 159);
            this.addDirectoryButton.Name = "addDirectoryButton";
            this.addDirectoryButton.Size = new System.Drawing.Size(177, 23);
            this.addDirectoryButton.TabIndex = 6;
            this.addDirectoryButton.Text = "Добавить";
            this.addDirectoryButton.UseVisualStyleBackColor = true;
            this.addDirectoryButton.Click += new System.EventHandler(this.addDirectoryButton_Click);
            // 
            // directoriesListBox
            // 
            this.directoriesListBox.FormattingEnabled = true;
            this.directoriesListBox.Items.AddRange(new object[] {
            "Виды ДТП",
            "Районы",
            "Погода",
            "Состояние дороги",
            "Освещение",
            "Типы ТС",
            "Марки ТС",
            "Формы собственности",
            "Цвета",
            "Типы привода",
            "Статусы оставления места ДТП"});
            this.directoriesListBox.Location = new System.Drawing.Point(6, 6);
            this.directoriesListBox.Name = "directoriesListBox";
            this.directoriesListBox.Size = new System.Drawing.Size(177, 147);
            this.directoriesListBox.TabIndex = 0;
            this.directoriesListBox.SelectedIndexChanged += new System.EventHandler(this.directoriesListBox_SelectedIndexChanged);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.Location = new System.Drawing.Point(1096, 637);
            this.exitButton.Name = "exitButton";
            this.exitButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.exitButton.Size = new System.Drawing.Size(184, 29);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "Выход";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addButton.Enabled = false;
            this.addButton.Location = new System.Drawing.Point(206, 637);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(184, 29);
            this.addButton.TabIndex = 5;
            this.addButton.Text = "Выберите файл для добавления";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 678);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.fileSelectButton);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "mainForm";
            this.Text = "Анализ данных о ДТП";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.analysisPictureBox)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.directoriesGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button fileSelectButton;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.PictureBox analysisPictureBox;
        private System.Windows.Forms.ComboBox metricComboBox;
        private System.Windows.Forms.ComboBox chartTypeComboBox;
        private System.Windows.Forms.ComboBox groupByComboBox;
        private System.Windows.Forms.Button buildAnalysisButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton VehiclesRadioButton;
        private System.Windows.Forms.RadioButton accidentRadioButton;
        private System.Windows.Forms.ComboBox groupByComboBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ListBox directoriesListBox;
        private System.Windows.Forms.Button deleteDirectoryButton;
        private System.Windows.Forms.Button addDirectoryButton;
        private System.Windows.Forms.Button saveDirectoryButton;
        private System.Windows.Forms.DataGridView directoriesGridView;
        private System.Windows.Forms.Button saveAccidentsButton;
        private System.Windows.Forms.Button deleteAccidentButton;
        private System.Windows.Forms.Button addAccidentButton;
        private System.Windows.Forms.Button deleteVehicleButton;
        private System.Windows.Forms.Button saveVehiclesButton;
        private System.Windows.Forms.Button addVehicleButton;
        private System.Windows.Forms.Button addButton;
    }
}

