namespace EJ
{
    //By Shuvalov Maxim
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.comboBoxListDiscipline = new System.Windows.Forms.ComboBox();
            this.comboBoxListGroups = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.columnFIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPointTest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPointLek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPointLab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPointPrac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPointMore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAllPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBoxTeacherName = new System.Windows.Forms.ComboBox();
            this.labelWeighPoint = new System.Windows.Forms.Label();
            this.tbWeightPoint = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbWeightLek = new System.Windows.Forms.TextBox();
            this.tbCountLek = new System.Windows.Forms.TextBox();
            this.tbCountPrac = new System.Windows.Forms.TextBox();
            this.tbWeightPrac = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCountLab = new System.Windows.Forms.TextBox();
            this.tbWeightLab = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxNameCP = new System.Windows.Forms.ComboBox();
            this.tbWeghtMore = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnCalc = new System.Windows.Forms.Button();
            this.btnCloseDataGrid2 = new System.Windows.Forms.Button();
            this.btnAddTeacher = new System.Windows.Forms.Button();
            this.btnAddDiscipline = new System.Windows.Forms.Button();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.btnAddLines = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.ColumnLab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLabPointForTurn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFIODataGrid2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCloseTurn = new System.Windows.Forms.Button();
            this.lstBCp = new System.Windows.Forms.ListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbTerm = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxListDiscipline
            // 
            this.comboBoxListDiscipline.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxListDiscipline.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxListDiscipline.FormattingEnabled = true;
            this.comboBoxListDiscipline.Location = new System.Drawing.Point(482, 11);
            this.comboBoxListDiscipline.Name = "comboBoxListDiscipline";
            this.comboBoxListDiscipline.Size = new System.Drawing.Size(156, 21);
            this.comboBoxListDiscipline.TabIndex = 3;
            this.comboBoxListDiscipline.SelectedIndexChanged += new System.EventHandler(this.comboboxListDiscipline_SelectedIndexChanged);
            this.comboBoxListDiscipline.Leave += new System.EventHandler(this.button2_Click);
            // 
            // comboBoxListGroups
            // 
            this.comboBoxListGroups.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxListGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxListGroups.FormattingEnabled = true;
            this.comboBoxListGroups.Location = new System.Drawing.Point(783, 11);
            this.comboBoxListGroups.Name = "comboBoxListGroups";
            this.comboBoxListGroups.Size = new System.Drawing.Size(100, 21);
            this.comboBoxListGroups.TabIndex = 5;
            this.comboBoxListGroups.SelectedValueChanged += new System.EventHandler(this.comboboxListGroup_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnFIO,
            this.ColumnPointTest,
            this.ColumnPointLek,
            this.ColumnPointLab,
            this.ColumnPointPrac,
            this.ColumnPointMore,
            this.ColumnAllPoint});
            this.dataGridView1.Location = new System.Drawing.Point(227, 115);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(459, 392);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // columnFIO
            // 
            this.columnFIO.DataPropertyName = "FIO";
            this.columnFIO.HeaderText = "ФИО";
            this.columnFIO.Name = "columnFIO";
            this.columnFIO.Width = 150;
            // 
            // ColumnPointTest
            // 
            this.ColumnPointTest.DataPropertyName = "PointTest";
            this.ColumnPointTest.HeaderText = "Тест";
            this.ColumnPointTest.Name = "ColumnPointTest";
            this.ColumnPointTest.Visible = false;
            // 
            // ColumnPointLek
            // 
            this.ColumnPointLek.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ColumnPointLek.DataPropertyName = "PointForLek";
            this.ColumnPointLek.HeaderText = "Лек.";
            this.ColumnPointLek.Name = "ColumnPointLek";
            this.ColumnPointLek.Width = 55;
            // 
            // ColumnPointLab
            // 
            this.ColumnPointLab.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ColumnPointLab.DataPropertyName = "PointForLab";
            this.ColumnPointLab.HeaderText = "Лаб.";
            this.ColumnPointLab.Name = "ColumnPointLab";
            this.ColumnPointLab.Width = 55;
            // 
            // ColumnPointPrac
            // 
            this.ColumnPointPrac.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ColumnPointPrac.DataPropertyName = "PointForPrac";
            this.ColumnPointPrac.HeaderText = "Пр.";
            this.ColumnPointPrac.Name = "ColumnPointPrac";
            this.ColumnPointPrac.Width = 49;
            // 
            // ColumnPointMore
            // 
            this.ColumnPointMore.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ColumnPointMore.DataPropertyName = "PointForMore";
            this.ColumnPointMore.HeaderText = "Др.";
            this.ColumnPointMore.Name = "ColumnPointMore";
            this.ColumnPointMore.Width = 50;
            // 
            // ColumnAllPoint
            // 
            this.ColumnAllPoint.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ColumnAllPoint.DataPropertyName = "PointGeneral";
            this.ColumnAllPoint.HeaderText = "Итог";
            this.ColumnAllPoint.Name = "ColumnAllPoint";
            this.ColumnAllPoint.Width = 56;
            // 
            // comboBoxTeacherName
            // 
            this.comboBoxTeacherName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxTeacherName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTeacherName.FormattingEnabled = true;
            this.comboBoxTeacherName.Location = new System.Drawing.Point(151, 11);
            this.comboBoxTeacherName.Name = "comboBoxTeacherName";
            this.comboBoxTeacherName.Size = new System.Drawing.Size(199, 21);
            this.comboBoxTeacherName.TabIndex = 12;
            this.comboBoxTeacherName.Click += new System.EventHandler(this.ComboBoxTeacherName_Click);
            // 
            // labelWeighPoint
            // 
            this.labelWeighPoint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(230)))), ((int)(((byte)(57)))));
            this.labelWeighPoint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelWeighPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWeighPoint.Location = new System.Drawing.Point(26, 49);
            this.labelWeighPoint.Name = "labelWeighPoint";
            this.labelWeighPoint.Size = new System.Drawing.Size(72, 20);
            this.labelWeighPoint.TabIndex = 15;
            this.labelWeighPoint.Text = "Вес точки";
            // 
            // tbWeightPoint
            // 
            this.tbWeightPoint.Location = new System.Drawing.Point(104, 49);
            this.tbWeightPoint.Name = "tbWeightPoint";
            this.tbWeightPoint.Size = new System.Drawing.Size(82, 20);
            this.tbWeightPoint.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(230)))), ((int)(((byte)(57)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(193, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 37);
            this.label1.TabIndex = 17;
            this.label1.Text = "Вес лек.";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(101)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(193, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 18);
            this.label2.TabIndex = 18;
            this.label2.Text = "Кол-во";
            // 
            // tbWeightLek
            // 
            this.tbWeightLek.Location = new System.Drawing.Point(250, 49);
            this.tbWeightLek.Name = "tbWeightLek";
            this.tbWeightLek.Size = new System.Drawing.Size(100, 20);
            this.tbWeightLek.TabIndex = 19;
            this.tbWeightLek.TextChanged += new System.EventHandler(this.tbWeight_Click);
            // 
            // tbCountLek
            // 
            this.tbCountLek.Location = new System.Drawing.Point(250, 86);
            this.tbCountLek.Name = "tbCountLek";
            this.tbCountLek.Size = new System.Drawing.Size(100, 20);
            this.tbCountLek.TabIndex = 20;
            this.tbCountLek.TextChanged += new System.EventHandler(this.tbCount_Click);
            // 
            // tbCountPrac
            // 
            this.tbCountPrac.Location = new System.Drawing.Point(418, 86);
            this.tbCountPrac.Name = "tbCountPrac";
            this.tbCountPrac.Size = new System.Drawing.Size(100, 20);
            this.tbCountPrac.TabIndex = 24;
            // 
            // tbWeightPrac
            // 
            this.tbWeightPrac.Location = new System.Drawing.Point(418, 49);
            this.tbWeightPrac.Name = "tbWeightPrac";
            this.tbWeightPrac.Size = new System.Drawing.Size(100, 20);
            this.tbWeightPrac.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(101)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(356, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Кол-во";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(230)))), ((int)(((byte)(57)))));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(356, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 37);
            this.label4.TabIndex = 21;
            this.label4.Text = "Вес прак.";
            // 
            // tbCountLab
            // 
            this.tbCountLab.Location = new System.Drawing.Point(580, 87);
            this.tbCountLab.Name = "tbCountLab";
            this.tbCountLab.Size = new System.Drawing.Size(100, 20);
            this.tbCountLab.TabIndex = 28;
            // 
            // tbWeightLab
            // 
            this.tbWeightLab.Location = new System.Drawing.Point(580, 49);
            this.tbWeightLab.Name = "tbWeightLab";
            this.tbWeightLab.Size = new System.Drawing.Size(100, 20);
            this.tbWeightLab.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(101)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(524, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 20);
            this.label5.TabIndex = 26;
            this.label5.Text = "Кол-во";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(230)))), ((int)(((byte)(57)))));
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(524, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 37);
            this.label6.TabIndex = 25;
            this.label6.Text = "Вес лаб.";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(230)))), ((int)(((byte)(57)))));
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(25, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 21);
            this.label7.TabIndex = 29;
            this.label7.Text = "Точка";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxNameCP
            // 
            this.comboBoxNameCP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxNameCP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNameCP.FormattingEnabled = true;
            this.comboBoxNameCP.Location = new System.Drawing.Point(104, 83);
            this.comboBoxNameCP.Name = "comboBoxNameCP";
            this.comboBoxNameCP.Size = new System.Drawing.Size(83, 21);
            this.comboBoxNameCP.TabIndex = 30;
            // 
            // tbWeghtMore
            // 
            this.tbWeghtMore.Location = new System.Drawing.Point(690, 87);
            this.tbWeghtMore.Name = "tbWeghtMore";
            this.tbWeghtMore.Size = new System.Drawing.Size(100, 20);
            this.tbWeghtMore.TabIndex = 34;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(230)))), ((int)(((byte)(57)))));
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(707, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 35);
            this.label9.TabIndex = 32;
            this.label9.Text = "Вес друг.";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(230)))), ((int)(((byte)(57)))));
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(370, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 21);
            this.label10.TabIndex = 37;
            this.label10.Text = "Дисциплина:";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(230)))), ((int)(((byte)(57)))));
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(677, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 20);
            this.label11.TabIndex = 38;
            this.label11.Text = "Группа:";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            this.label12.Location = new System.Drawing.Point(22, 11);
            this.label12.MaximumSize = new System.Drawing.Size(0, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 21);
            this.label12.TabIndex = 39;
            this.label12.Text = "Преподаватель:";
            // 
            // btnCalc
            // 
            this.btnCalc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(230)))), ((int)(((byte)(57)))));
            this.btnCalc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCalc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCalc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCalc.Location = new System.Drawing.Point(857, 381);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(106, 47);
            this.btnCalc.TabIndex = 35;
            this.btnCalc.Text = "Посчитать баллы";
            this.btnCalc.UseVisualStyleBackColor = false;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            this.btnCalc.MouseEnter += new System.EventHandler(this.btnCalc_MouseEnter);
            this.btnCalc.MouseLeave += new System.EventHandler(this.btnCalc_MouseLeave);
            // 
            // btnCloseDataGrid2
            // 
            this.btnCloseDataGrid2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(230)))), ((int)(((byte)(57)))));
            this.btnCloseDataGrid2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCloseDataGrid2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCloseDataGrid2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCloseDataGrid2.Location = new System.Drawing.Point(857, 328);
            this.btnCloseDataGrid2.Name = "btnCloseDataGrid2";
            this.btnCloseDataGrid2.Size = new System.Drawing.Size(106, 47);
            this.btnCloseDataGrid2.TabIndex = 31;
            this.btnCloseDataGrid2.Text = "Добавить точку";
            this.btnCloseDataGrid2.UseVisualStyleBackColor = false;
            this.btnCloseDataGrid2.Click += new System.EventHandler(this.btnAddCp_Click);
            this.btnCloseDataGrid2.MouseEnter += new System.EventHandler(this.btnAddCp_MouseEnter);
            this.btnCloseDataGrid2.MouseLeave += new System.EventHandler(this.btnAddCp_MouseLeave);
            // 
            // btnAddTeacher
            // 
            this.btnAddTeacher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(230)))), ((int)(((byte)(57)))));
            this.btnAddTeacher.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddTeacher.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddTeacher.Location = new System.Drawing.Point(857, 275);
            this.btnAddTeacher.Name = "btnAddTeacher";
            this.btnAddTeacher.Size = new System.Drawing.Size(106, 47);
            this.btnAddTeacher.TabIndex = 14;
            this.btnAddTeacher.Text = "Добавить преподавателя";
            this.btnAddTeacher.UseVisualStyleBackColor = false;
            this.btnAddTeacher.Click += new System.EventHandler(this.btnAddTeacher_Click);
            this.btnAddTeacher.MouseEnter += new System.EventHandler(this.btnAddTeacher_MouseEnter);
            this.btnAddTeacher.MouseLeave += new System.EventHandler(this.btnAddTeacher_MouseLeave);
            // 
            // btnAddDiscipline
            // 
            this.btnAddDiscipline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(230)))), ((int)(((byte)(57)))));
            this.btnAddDiscipline.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddDiscipline.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddDiscipline.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddDiscipline.Location = new System.Drawing.Point(857, 222);
            this.btnAddDiscipline.Name = "btnAddDiscipline";
            this.btnAddDiscipline.Size = new System.Drawing.Size(106, 47);
            this.btnAddDiscipline.TabIndex = 13;
            this.btnAddDiscipline.Text = "Добавить дисциплину";
            this.btnAddDiscipline.UseVisualStyleBackColor = false;
            this.btnAddDiscipline.Click += new System.EventHandler(this.btnAddDiscipline_Click);
            this.btnAddDiscipline.MouseEnter += new System.EventHandler(this.btnAddDiscipline_MouseEnter);
            this.btnAddDiscipline.MouseLeave += new System.EventHandler(this.btnAddDiscipline_MouseLeave);
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(230)))), ((int)(((byte)(57)))));
            this.btnAddGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddGroup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddGroup.Location = new System.Drawing.Point(857, 169);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(106, 47);
            this.btnAddGroup.TabIndex = 11;
            this.btnAddGroup.Text = "Добавить группу";
            this.btnAddGroup.UseVisualStyleBackColor = false;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            this.btnAddGroup.MouseEnter += new System.EventHandler(this.btnAddGroup_MouseEnter);
            this.btnAddGroup.MouseLeave += new System.EventHandler(this.btnAddGroup_MouseLeave);
            // 
            // btnAddLines
            // 
            this.btnAddLines.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(230)))), ((int)(((byte)(57)))));
            this.btnAddLines.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddLines.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddLines.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddLines.Location = new System.Drawing.Point(857, 116);
            this.btnAddLines.Name = "btnAddLines";
            this.btnAddLines.Size = new System.Drawing.Size(106, 47);
            this.btnAddLines.TabIndex = 10;
            this.btnAddLines.Text = "Добавить пустую строку";
            this.btnAddLines.UseVisualStyleBackColor = false;
            this.btnAddLines.Click += new System.EventHandler(this.btnAddLines_Click);
            this.btnAddLines.MouseEnter += new System.EventHandler(this.btnAddLines_MouseEnter);
            this.btnAddLines.MouseLeave += new System.EventHandler(this.btnAddLines_MouseLeave);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(230)))), ((int)(((byte)(57)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSave.Location = new System.Drawing.Point(12, 214);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 47);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.MouseEnter += new System.EventHandler(this.buttons_MouseEnter);
            this.btnSave.MouseLeave += new System.EventHandler(this.btnSave_MouseLeave);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(230)))), ((int)(((byte)(57)))));
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(12, 161);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(107, 47);
            this.button3.TabIndex = 8;
            this.button3.Text = "Загрузить записи";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            this.button3.MouseEnter += new System.EventHandler(this.button3_MouseEnter);
            this.button3.MouseLeave += new System.EventHandler(this.button3_MouseLeave);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(230)))), ((int)(((byte)(57)))));
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(26, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 21);
            this.label8.TabIndex = 40;
            this.label8.Text = "Преподаватель:";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToOrderColumns = true;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnLab,
            this.ColumnLabPointForTurn,
            this.ColumnFIODataGrid2});
            this.dataGridView2.Location = new System.Drawing.Point(227, 116);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(400, 150);
            this.dataGridView2.TabIndex = 42;
            this.dataGridView2.Visible = false;
            // 
            // ColumnLab
            // 
            this.ColumnLab.DataPropertyName = "Name";
            this.ColumnLab.HeaderText = "Название";
            this.ColumnLab.Name = "ColumnLab";
            this.ColumnLab.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnLabPointForTurn
            // 
            this.ColumnLabPointForTurn.DataPropertyName = "Point";
            this.ColumnLabPointForTurn.HeaderText = "Баллы";
            this.ColumnLabPointForTurn.Name = "ColumnLabPointForTurn";
            this.ColumnLabPointForTurn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnFIODataGrid2
            // 
            this.ColumnFIODataGrid2.DataPropertyName = "NameStudent";
            this.ColumnFIODataGrid2.HeaderText = "ФИО";
            this.ColumnFIODataGrid2.Name = "ColumnFIODataGrid2";
            this.ColumnFIODataGrid2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnCloseTurn
            // 
            this.btnCloseTurn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(230)))), ((int)(((byte)(57)))));
            this.btnCloseTurn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCloseTurn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCloseTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCloseTurn.Location = new System.Drawing.Point(12, 267);
            this.btnCloseTurn.Name = "btnCloseTurn";
            this.btnCloseTurn.Size = new System.Drawing.Size(106, 47);
            this.btnCloseTurn.TabIndex = 43;
            this.btnCloseTurn.Text = "Свернуть занятие";
            this.btnCloseTurn.UseVisualStyleBackColor = false;
            this.btnCloseTurn.Click += new System.EventHandler(this.btnCloseTurn_Click);
            this.btnCloseTurn.MouseEnter += new System.EventHandler(this.btnCloseTurn_MouseEnter);
            this.btnCloseTurn.MouseLeave += new System.EventHandler(this.btnCloseTurn_MouseLeave);
            // 
            // lstBCp
            // 
            this.lstBCp.BackColor = System.Drawing.Color.White;
            this.lstBCp.FormattingEnabled = true;
            this.lstBCp.Location = new System.Drawing.Point(857, 41);
            this.lstBCp.Name = "lstBCp";
            this.lstBCp.Size = new System.Drawing.Size(106, 69);
            this.lstBCp.TabIndex = 44;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(230)))), ((int)(((byte)(57)))));
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(25, 116);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 21);
            this.label13.TabIndex = 45;
            this.label13.Text = "Семестр";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbTerm
            // 
            this.cmbTerm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTerm.FormattingEnabled = true;
            this.cmbTerm.Location = new System.Drawing.Point(103, 115);
            this.cmbTerm.Name = "cmbTerm";
            this.cmbTerm.Size = new System.Drawing.Size(117, 21);
            this.cmbTerm.TabIndex = 46;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(975, 517);
            this.Controls.Add(this.cmbTerm);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lstBCp);
            this.Controls.Add(this.btnCloseTurn);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.tbWeghtMore);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnCloseDataGrid2);
            this.Controls.Add(this.comboBoxNameCP);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbCountLab);
            this.Controls.Add(this.tbWeightLab);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbCountPrac);
            this.Controls.Add(this.tbWeightPrac);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbCountLek);
            this.Controls.Add(this.tbWeightLek);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbWeightPoint);
            this.Controls.Add(this.labelWeighPoint);
            this.Controls.Add(this.btnAddTeacher);
            this.Controls.Add(this.btnAddDiscipline);
            this.Controls.Add(this.comboBoxTeacherName);
            this.Controls.Add(this.btnAddGroup);
            this.Controls.Add(this.btnAddLines);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.comboBoxListGroups);
            this.Controls.Add(this.comboBoxListDiscipline);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "My Journal";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxListDiscipline;
        private System.Windows.Forms.ComboBox comboBoxListGroups;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAddLines;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.ComboBox comboBoxTeacherName;
        private System.Windows.Forms.Button btnAddDiscipline;
        private System.Windows.Forms.Button btnAddTeacher;
        private System.Windows.Forms.Label labelWeighPoint;
        private System.Windows.Forms.TextBox tbWeightPoint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbWeightLek;
        private System.Windows.Forms.TextBox tbCountLek;
        private System.Windows.Forms.TextBox tbCountPrac;
        private System.Windows.Forms.TextBox tbWeightPrac;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbCountLab;
        private System.Windows.Forms.TextBox tbWeightLab;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxNameCP;
        private System.Windows.Forms.Button btnCloseDataGrid2;
        private System.Windows.Forms.TextBox tbWeghtMore;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLab;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLabPointForTurn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFIODataGrid2;
        private System.Windows.Forms.Button btnCloseTurn;
        private System.Windows.Forms.ListBox lstBCp;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnFIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPointTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPointLek;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPointLab;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPointPrac;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPointMore;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAllPoint;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbTerm;
    }
}

