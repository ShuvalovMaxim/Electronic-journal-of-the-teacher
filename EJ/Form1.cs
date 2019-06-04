using Calculations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using TestRepos;
using TestRepos.Model;
using NLog;
using WorkForExcel;

namespace EJ
{
    public partial class Form1 : Form
    {
        public string DisciplineName;
        public string TeacherName;
        public string CpName;
        public string TermName;
        public string TeacherNameFromFormAddDiscipline;
        public BindingList<StatementLine> listStatementLine = new BindingList<StatementLine>();
        public BindingList<TurnList> listTurn = new BindingList<TurnList>();

        public BindingList<CP> listCpForGroupAndDiscipline = new BindingList<CP>();
        public IEnumerable<Teacher> TeachersList { get; private set; }
        public IEnumerable<Term> TermList { get; private set; }

        ToolTip toolTip = new ToolTip();

        public string GroupName;

        public IRepository<Discipline> reposDiscipline = RepositoryFactory<Discipline>.Create();
        public IRepository<Term> reposTerm = RepositoryFactory<Term>.Create();
        public IRepository<Group> reposGroup = RepositoryFactory<Group>.Create();
        public IRepository<Teacher> reposTeacher = RepositoryFactory<Teacher>.Create();
        public IRepository<Student> reposStud = RepositoryFactory<Student>.Create();
        public IRepository<CP> reposCP = RepositoryFactory<CP>.Create();
        public IRepository<Turn> reposTurn = RepositoryFactory<Turn>.Create();

        public event EventHandler<EventArgs> OnBtnAddGroupForFormAddGroup;
        public event EventHandler<EventArgs> OnBtnAddDiscipline;
        public event EventHandler<EventArgs> OnBtnAddStudents;
        public event EventHandler<EventArgs> OncomboBoxTeacher;
        public event EventHandler<EventArgs> OnBtnAddTeacherForFormAddTeacher;
        public event EventHandler<EventArgs> OnBtnSearchFileClick;

        public static Bitmap backColorWork = res.BackGround,
            backGroundButtonsMouseEnter = res.BackGroundButtonMouseEnter,
            backGroundButtons = res.BackGroundButton;

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public Form1()
        {
            Thread t1 = new Thread(new ThreadStart(SplashScreen));
            t1.Start();
            Thread.Sleep(8500);
            InitializeComponent();
            t1.Abort();
            dataGridView1.BackgroundColor = Color.FromArgb(255, 247, 101);
            lstBCp.BackColor = Color.FromArgb(255, 247, 101);
            this.BackColor = System.Drawing.Color.FromArgb(235, 202, 254);
            comboBoxListDiscipline.BackColor = Color.FromArgb(255, 247, 101);
            comboBoxListGroups.BackColor = Color.FromArgb(255, 247, 101);
            comboBoxNameCP.BackColor = Color.FromArgb(255, 247, 101);
            comboBoxTeacherName.BackColor = Color.FromArgb(255, 247, 101);
            cmbTerm.BackColor = Color.FromArgb(255, 247, 101);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;
            dataGridView1.DataSource = listStatementLine;
            dataGridView2.DataSource = listTurn;
            reposDiscipline = RepositoryFactory<Discipline>.Create();
            TeachersList = reposTeacher.GetAll();
            TermList = reposTerm.GetAll();
            this.comboBoxNameCP.SelectedIndexChanged += new EventHandler(comboboxNameCP_SelectedIndexChanged);
            this.comboBoxTeacherName.SelectedIndexChanged += new EventHandler(comboboxTeacherName_SelectedIndexChanged);
            this.cmbTerm.SelectedIndexChanged += new EventHandler(comboboxListTerm_SelectedIndexChanged);
            AddItemsTbCp();
            this.BringToFront();
        }

        public void SplashScreen()
        {
            Application.Run(new SplashScreen());
        }

        private void InvokeUI(Action a) //Метод для работы с GUI
        {
            this.BeginInvoke(new MethodInvoker(a));
        }
        private async void comboboxTeacherName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TeacherName = comboBoxTeacherName.Items[comboBoxTeacherName.SelectedIndex].ToString();
                _logger.Info("Выбран преподаватель {0}", TeacherName);
            }
            catch { }

            await Task.Factory.StartNew(() =>
            {
                InvokeUI(() =>
                {
                    var listDiscipline = WorkWithDB.GetAllDisciplineForTeacher(TeacherName).ToList();
                    if (listDiscipline != null)
                    {
                        AddItemToComboBox(comboBoxListDiscipline, listDiscipline);
                    }
                    listDiscipline.Clear();
                });
            });

        }

        private void comboboxListTerm_SelectedIndexChanged(object sender, EventArgs e)
        {
            listCpForGroupAndDiscipline.Clear();

            TermName = cmbTerm.Items[cmbTerm.SelectedIndex].ToString();

            var list = WorkWithDB.GetAllCpForGroupAndDiscipline(GroupName, DisciplineName, TermName);

            foreach (var cp in list)
                listCpForGroupAndDiscipline.Add(cp);

            list = null;
            lstBCp.DataSource = listCpForGroupAndDiscipline;
        }

        private void AddItemToComboBox<T>(ComboBox comboBox, IEnumerable<T> list)
        {
            if (list.Count() != 0)
                foreach (var item in list)
                    comboBox.Items.Add(item);
            list = null;
        }

        private async void ComboBoxTeacherName_Click(object sender, EventArgs e)
        {
            comboBoxTeacherName.Items.Clear();
            comboBoxListDiscipline.Items.Clear();
            comboBoxListGroups.Items.Clear();
            await Task.Factory.StartNew(() => TeachersList = reposTeacher.GetAll());

            await Task.Factory.StartNew(() =>
            {
                InvokeUI(() =>
                {
                    AddItemToComboBox(comboBoxTeacherName, TeachersList);
                    AddItemToComboBox(cmbTerm, TermList);
                });
            });
            TeachersList.ToList().Clear();
        }

        private void comboboxListDiscipline_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisciplineName = comboBoxListDiscipline.Items[comboBoxListDiscipline.SelectedIndex].ToString();

            comboBoxListGroups.Items.Clear();
        }

        private void comboboxNameCP_SelectedIndexChanged(object sender, EventArgs e)
        {
            listStatementLine.Clear();
            CpName = comboBoxNameCP.Items[comboBoxNameCP.SelectedIndex].ToString();
            button3_Click(sender, e);

        }

        private void comboboxListGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            listCpForGroupAndDiscipline.Clear();

            GroupName = comboBoxListGroups.Items[comboBoxListGroups.SelectedIndex].ToString();

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            this.comboBoxListDiscipline.SelectedIndexChanged += new EventHandler(comboboxListDiscipline_SelectedIndexChanged);

            await Task.Factory.StartNew(() =>
            {
                InvokeUI(() =>
                {
                    var _listGroup = WorkWithDB.GetListGroupForDiscipline(DisciplineName).AsParallel();
                    if (WorkWithDB.GetListGroupForDiscipline(DisciplineName) != null)
                    {

                        AddItemToComboBox(comboBoxListGroups, _listGroup);

                    }
                    else
                    {
                        MessageBox.Show("Таких групп нет!");
                    }
                    _listGroup.ToList().Clear();
                });
            });
        }

        private void ShowInformationAboutCp(long IdCp)
        {
            var cp = reposCP.Get(IdCp);
            tbWeightPoint.Text = Convert.ToString(cp.WeightKT);
            tbWeightLek.Text = Convert.ToString(cp.WeightLek);
            tbWeightLab.Text = Convert.ToString(cp.WeightLab);
            tbWeightPrac.Text = Convert.ToString(cp.WeightPrac);
            tbWeghtMore.Text = Convert.ToString(cp.WeightMore);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            _logger.Info("Нажата кнопка '{0}'", button3.Text);
            try
            {
                await Task.Factory.StartNew(() =>
                {
                    InvokeUI(() =>
                    {
                        listStatementLine.Clear();

                        var reposStudent = RepositoryFactory<Student>.Create();

                        this.comboBoxListGroups.SelectedIndexChanged += new EventHandler(comboboxListGroup_SelectedIndexChanged);

                        var _idGroup = reposStudent.GetIdGroupForStudent(GroupName);
                        var _idCp = WorkWithDB.GetIdCp(CpName, _idGroup, DisciplineName, TermName);

                        var _cp = reposCP.Get(_idCp);

                        if (_idCp != 0 && _cp.DisciplineId == WorkWithDB.GetDisciplineId(DisciplineName))
                        {
                            foreach (var item in StatementLine.GetListStatementLine(_idCp, WorkWithDB.GetDisciplineId(DisciplineName),
                             Convert.ToInt32(reposGroup.GetIdGroupDisciplineGroup(GroupName)), WorkWithDB.GetIdTermForCp(TermName)).AsParallel())
                            {
                                listStatementLine.Add(item);
                            }
                            var repCp = reposCP.Get(_idCp);

                            tbCountLek.Text = Convert.ToString(repCp.CountLek);
                            tbCountLab.Text = Convert.ToString(repCp.CountLab);
                            tbCountPrac.Text = Convert.ToString(repCp.CountPrac);

                            ShowInformationAboutCp(_idCp);
                            _logger.Info("Информация загружена.");
                        }
                        else if (_idCp == 0)
                        {
                            _logger.Debug("Не удалось получить id контрольной точки!");
                        }
                        else
                        {
                            MessageBox.Show($"Для данной группы отсутствует '{CpName}' точка!");
                            _logger.Info("Данные не были загружены, так как у группы {0} отсутствует {1} точка по дисциплине {2} в семестре {3}",
                                GroupName, CpName, DisciplineName, TermName);
                        }
                    });

                });
            }
            catch (Exception ex)
            {
                _logger.Error("Произошла ошибка ({0}) при загрузке записей", ex.Message);
            }
        }

        private async void UpCp()
        {
            try
            {
                await Task.Factory.StartNew(() =>
                {
                    reposCP.Update(new CP(CpName, TermName, GroupName, Convert.ToInt32(tbWeightPoint.Text),
                    Convert.ToInt32(tbWeightLab.Text), Convert.ToInt32(tbWeightLek.Text),
                    Convert.ToInt32(tbWeightPrac.Text), Convert.ToInt32(tbWeghtMore.Text), Convert.ToInt32(tbCountLek.Text),
                    Convert.ToInt32(tbCountLab.Text), Convert.ToInt32(tbCountPrac.Text), DisciplineName));
                });
            }
            catch (Exception ex)
            {
                _logger.Warn("Произошла ошибка ({0}) при обновлении данных о контрольной точке.", ex.Message);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var sum = Convert.ToInt32(tbWeghtMore.Text) + Convert.ToInt32(tbWeightLab.Text) +
                    Convert.ToInt32(tbWeightLek.Text) + Convert.ToInt32(tbWeightPrac.Text);
                if (sum > 100)
                {
                    MessageBox.Show("Проверьте веса видов работ!");
                    tbWeightLek.BackColor = Color.Red;
                    tbWeightLab.BackColor = new Color( /* Color [Red] */);
                    tbWeightPrac.BackColor = Color.Red;
                    tbWeghtMore.BackColor = Color.Red;
                }

                UpCp();
                await Task.Factory.StartNew(() =>
                {
                    InvokeUI(() =>
                    {
                        var reposCpDataGeneral = RepositoryFactory<CPDataGeneral>.Create();
                        var _listCpData = reposCpDataGeneral.GetAll().AsParallel();
                        var reposStudent = RepositoryFactory<Student>.Create();
                        var _listStudentFromDb = reposStudent.GetAllStudentForGroup(GroupName);
                        var _idGroup = reposStudent.GetIdGroupForStudent(GroupName);
                        var _idCp = WorkWithDB.GetIdCp(CpName, _idGroup, DisciplineName, TermName);

                        List<CPDataGeneral> listDataGeneral = new List<CPDataGeneral>();
                        List<Student> listStudent = new List<Student>();
                        List<Student> listStudentUpdate = new List<Student>();

                        var IsBool = listStatementLine.AsParallel().Any(t => t.FIO == "");
                        _logger.Info("Список записей о студентах не содержит поля с пустыми ФИО.");

                        if (IsBool == false)
                        {

                            foreach (var item in listStatementLine.AsParallel())
                            {
                                listDataGeneral.Add(new CPDataGeneral(item.PointGeneral, item.FIO, DisciplineName, _idCp, 3, item.PointForLab,
                                   Convert.ToInt32(item.PointForLek), item.PointForPrac, item.PointForMore));
                            }

                            foreach (var itemDataGeneral in listDataGeneral.AsParallel())
                            {

                                var bl = _listCpData.Any(t => t.StudentId == reposStudent.GetIdStudent(itemDataGeneral.StudentName) &&
                                t.DisciplineId == WorkWithDB.GetDisciplineId(DisciplineName)
                                && t.CpId == WorkWithDB.GetIdCp(CpName, _idGroup, DisciplineName, TermName));
                                if (bl)
                                {
                                    reposCpDataGeneral.Update(itemDataGeneral);
                                    continue;
                                }
                                else
                                {
                                    reposCpDataGeneral.Add(itemDataGeneral);
                                    continue;
                                }
                            }
                            MessageBox.Show("Данные успешно сохранены!");
                            listDataGeneral.Clear();
                            _listCpData = null;
                            _logger.Info("Сохранение данных произошло успешно.");
                        }
                        else
                        {
                            MessageBox.Show("Проверьте заполнение поля 'ФИО' в введенных записях!");
                        }
                    });
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Недостаточно данных!");
                _logger.Warn("При сохранении данных произошла ошибка {0}", ex.Message);
            }
        }

        private void btnAddLines_Click(object sender, EventArgs e)
        {
            listStatementLine.Add(new StatementLine("", 0, 0, 0, 0, 0));
        }

        private async void btnAddGroup_Click(object sender, EventArgs e)
        {
            Form formAddGroup = new Form();
            TextBox textBoxNumberGroup = new TextBox();
            TextBox textBoxFaculty = new TextBox();
            TextBox textBoxCourse = new TextBox();
            CheckedListBox checkedListBoxDiscipline = new CheckedListBox();
            Label labelHeaderText = new Label();
            Label labelNumberGroup = new Label();
            Label labelFaculty = new Label();
            Label labelCourse = new Label();
            Label labelDiscipline = new Label();
            _logger.Info("Нажата кнопка добавления группы.");

            try
            {
                await Task.Factory.StartNew(() =>
                {
                    InvokeUI(() =>
                    {

                        //блок кода, для работы с формой
                        formAddGroup.Width = 600;
                        formAddGroup.Height = 600;
                        formAddGroup.BackColor = Color.FromArgb(57, 230, 57);
                        formAddGroup.Text = "Добавить группу";

                        //блок формы для работы с текстБоксами
                        textBoxNumberGroup.Location = new Point(300, 100);
                        textBoxNumberGroup.Size = new Size(200, 50);
                        textBoxNumberGroup.Font = new Font("Tobota", 16, FontStyle.Italic);
                        formAddGroup.Controls.Add(textBoxNumberGroup);

                        textBoxFaculty.Location = new Point(300, 200);
                        textBoxFaculty.Size = new Size(200, 50);
                        textBoxFaculty.Font = new Font("Tobota", 16, FontStyle.Italic);
                        formAddGroup.Controls.Add(textBoxFaculty);

                        textBoxCourse.Location = new Point(300, 300);
                        textBoxCourse.Size = new Size(200, 50);
                        textBoxCourse.Font = new Font("Tobota", 16, FontStyle.Italic);
                        formAddGroup.Controls.Add(textBoxCourse);

                        checkedListBoxDiscipline.Location = new Point(250, 370);
                        checkedListBoxDiscipline.Size = new Size(250, 100);
                        checkedListBoxDiscipline.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Italic);
                        foreach (var item in reposDiscipline.GetAll().AsParallel())
                        {
                            checkedListBoxDiscipline.Items.Add(item.Name);
                        }

                        formAddGroup.Controls.Add(checkedListBoxDiscipline);

                        //блок формы для работы с лэйблами
                        labelHeaderText.Location = new Point(200, 0);
                        labelHeaderText.Font = new Font("Microsoft Sans Serif", 15, FontStyle.Bold);
                        labelHeaderText.Size = new Size(250, 50);
                        labelHeaderText.Text = "Введите данные:";

                        labelNumberGroup.Location = new Point(50, 100);
                        labelNumberGroup.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                        labelNumberGroup.Size = new Size(200, 50);
                        labelNumberGroup.Text = "Номер группы: ";

                        labelFaculty.Location = new Point(50, 200);
                        labelFaculty.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                        labelFaculty.Size = new Size(200, 50);
                        labelFaculty.Text = "Факультет: ";

                        labelCourse.Location = new Point(50, 300);
                        labelCourse.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                        labelCourse.Size = new Size(200, 50);
                        labelCourse.Text = "Курс: ";

                        labelDiscipline.Location = new Point(50, 400);
                        labelDiscipline.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                        labelDiscipline.Size = new Size(200, 50);
                        labelDiscipline.Text = "Список\nдисциплин: ";


                        //Блок кода, работающий с кнопками
                        Button btnAddGroupForFormAddGroup = new Button
                        {
                            Location = new Point(200, 500),
                            Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold),
                            Size = new Size(200, 50),
                            Text = "Добавить группу"
                        };

                        btnAddGroupForFormAddGroup.MouseClick += (send, args) =>
                        {
                            OnBtnAddGroupForFormAddGroup?.Invoke(sender, EventArgs.Empty);
                        }; // Кнопка в окне добавления группы            

                        OnBtnAddGroupForFormAddGroup += (send, args) =>
                            {
                                _logger.Info("Нажата кнопка '{0}'.", btnAddGroupForFormAddGroup.Text);
                                try
                                {
                                    List<string> listDis = new List<string>();
                                    var reposGroup = RepositoryFactory<Group>.Create();

                                    foreach (var item in checkedListBoxDiscipline.CheckedItems.AsParallel())
                                    {
                                        listDis.Add(item.ToString());
                                    }

                                    reposGroup.Add(new Group(listDis, textBoxNumberGroup.Text, Convert.ToInt32(textBoxCourse.Text), textBoxFaculty.Text));
                                    MessageBox.Show("Группа успешно добавленна!");
                                    _logger.Info("Добавлена группа: {0}.", textBoxNumberGroup.Text);
                                    formAddGroup.Close();
                                    _logger.Info("Форма закрыта.");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Произошла ошибка во время добавления группы,\nПроверьте введенные данные!");
                                    _logger.Warn("Произошла ошибка при добавлении группы. {0}.", ex.Message);
                                }
                            };

                        formAddGroup.Controls.Add(btnAddGroupForFormAddGroup);
                        formAddGroup.Controls.Add(labelHeaderText);
                        formAddGroup.Controls.Add(labelNumberGroup);
                        formAddGroup.Controls.Add(labelFaculty);
                        formAddGroup.Controls.Add(labelCourse);
                        formAddGroup.Controls.Add(labelDiscipline);
                    });
                });
                formAddGroup.Show();
            }
            catch (Exception ex)
            {
                _logger.Error("Произошла ошибка при построении формы для добавления группы. {0}.", ex.Message);
            }
        }

        private void Btn_AddStudents_Click(object sender, EventArgs e)
        {
            Form formAddStudents = new Form();
            TextBox textBoxPathFile = new TextBox();

            Label labelHeaderText = new Label();
            Label labelFilePath = new Label();

            //блок кода, для работы с формой
            formAddStudents.Width = 600;
            formAddStudents.Height = 400;
            formAddStudents.BackColor = Color.FromArgb(57, 230, 57);
            formAddStudents.Text = "Добавить студентов";

            //блок формы для работы с текстБоксами
            textBoxPathFile.Location = new Point(300, 100);
            textBoxPathFile.Size = new Size(200, 50);
            textBoxPathFile.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
            formAddStudents.Controls.Add(textBoxPathFile);


            //блок формы для работы с лэйблами
            labelHeaderText.Location = new Point(200, 0);
            labelHeaderText.Font = new Font("Microsoft Sans Serif", 15, FontStyle.Bold);
            labelHeaderText.Size = new Size(250, 50);
            labelHeaderText.Text = "Введите данные:";

            labelFilePath.Location = new Point(100, 100);
            labelFilePath.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            labelFilePath.Size = new Size(200, 50);
            labelFilePath.Text = "Путь к файлу: ";


            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файлы xlsx|*.xlsx";

            //Блок кода, работающий с кнопками
            Button btnAddStudents = new Button
            {
                Location = new Point(200, 300),
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold),
                Size = new Size(200, 50),
                Text = "Добавить студентов"
            };

            Button btnSearchFile = new Button
            {
                Location = new Point(200, 200),
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold),
                Size = new Size(200, 50),
                Text = "Выбрать файл"
            };

            btnSearchFile.Click += (send, args) =>
            {
                OnBtnSearchFileClick?.Invoke(sender, EventArgs.Empty);
            };

            OnBtnSearchFileClick += (send, args) =>
            {
                try
                {                    
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //MessageBox.Show(openFileDialog.FileName);
                        textBoxPathFile.Text = openFileDialog.FileName;
                    }
                }
                catch { }
            };

            btnAddStudents.MouseClick += (send, args) =>
            {
                OnBtnAddStudents.Invoke(sender, EventArgs.Empty);
            }; // Кнопка в окне добавления группы          

           

            OnBtnAddStudents += (send, args) =>
            {
                try
                {
                    var list = Module1.ReadExcelFile(textBoxPathFile.Text);
                    var count = list.Count();

                    if (list != null)
                        for (int i = 0; i <= count - 1; i++)
                        {
                            var _idStudent = reposStud.GetIdStudent(list[i]);
                            if (_idStudent == -1)
                            {
                                reposStud.Add(new Student(list[i], GroupName, WorkWithDB.GetDisciplineId(GroupName)));
                            }
                            else
                            {
                                MessageBox.Show("Студент с таким именем уже существует!");
                            }
                        }
                    MessageBox.Show("Студенты добавлены!");
                    formAddStudents.Close();
                }
                catch
                {
                    MessageBox.Show("Что-то пошло не так!");
                }
            };

            formAddStudents.Controls.Add(btnAddStudents);
            formAddStudents.Controls.Add(labelHeaderText);
            formAddStudents.Controls.Add(labelFilePath);
            formAddStudents.Controls.Add(btnSearchFile);


            formAddStudents.Show();
        }

        private void btnAddDiscipline_Click(object sender, EventArgs e)
        {
            Form formAddDiscipline = new Form();
            TextBox textBoxNameDiscipline = new TextBox();
            ComboBox comboBoxTeacher = new ComboBox();
            Label labelHeaderText = new Label();
            Label labelNameDiscipline = new Label();
            Label labelNameTeacher = new Label();

            //блок кода, для работы с формой
            formAddDiscipline.Width = 600;
            formAddDiscipline.Height = 400;
            formAddDiscipline.BackColor = Color.FromArgb(57, 230, 57);
            formAddDiscipline.Text = "Добавить дисциплину";

            //блок формы для работы с текстБоксами
            textBoxNameDiscipline.Location = new Point(300, 100);
            textBoxNameDiscipline.Size = new Size(200, 50);
            textBoxNameDiscipline.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
            formAddDiscipline.Controls.Add(textBoxNameDiscipline);

            comboBoxTeacher.Location = new Point(300, 200);
            comboBoxTeacher.Size = new Size(250, 60);
            comboBoxTeacher.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
            comboBoxTeacher.DropDownWidth = 300;
            comboBoxTeacher.DropDownStyle = ComboBoxStyle.DropDownList;
            foreach (var item in reposTeacher.GetAll().AsParallel())
            {
                comboBoxTeacher.Items.Add(item.Name);
            }

            formAddDiscipline.Controls.Add(comboBoxTeacher);


            //блок формы для работы с лэйблами
            labelHeaderText.Location = new Point(200, 0);
            labelHeaderText.Font = new Font("Microsoft Sans Serif", 15, FontStyle.Bold);
            labelHeaderText.Size = new Size(250, 50);
            labelHeaderText.Text = "Введите данные:";

            labelNameDiscipline.Location = new Point(100, 100);
            labelNameDiscipline.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            labelNameDiscipline.Size = new Size(200, 50);
            labelNameDiscipline.Text = "Название дисциплины: ";

            labelNameTeacher.Location = new Point(100, 200);
            labelNameTeacher.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            labelNameTeacher.Size = new Size(200, 50);
            labelNameTeacher.Text = "Преподаватель: ";


            //Блок кода, работающий с кнопками
            Button btnAddDiscipline = new Button
            {
                Location = new Point(200, 300),
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold),
                Size = new Size(200, 50),
                Text = "Добавить дисциплину"
            };


            btnAddDiscipline.MouseClick += (send, args) =>
            {
                OnBtnAddDiscipline?.Invoke(sender, EventArgs.Empty);
            }; // Кнопка в окне добавления группы          

            comboBoxTeacher.SelectedValueChanged += (send, args) =>
            {
                OncomboBoxTeacher?.Invoke(sender, EventArgs.Empty);
            };

            OncomboBoxTeacher += (send, args) =>
              {
                  TeacherNameFromFormAddDiscipline = comboBoxTeacher.Items[comboBoxTeacher.SelectedIndex].ToString();
              };

            OnBtnAddDiscipline += (send, args) =>
            {
                try
                {
                    reposDiscipline.Add(new Discipline(textBoxNameDiscipline.Text, TeacherNameFromFormAddDiscipline));
                    MessageBox.Show("Дисциплина добавлена!");
                    formAddDiscipline.Close();
                }
                catch
                {
                    MessageBox.Show("Что-то пошло не так!");
                }
            };

            formAddDiscipline.Controls.Add(btnAddDiscipline);
            formAddDiscipline.Controls.Add(labelHeaderText);
            formAddDiscipline.Controls.Add(labelNameDiscipline);
            formAddDiscipline.Controls.Add(labelNameTeacher);

            formAddDiscipline.Show();
        }

        private void btnAddTeacher_Click(object sender, EventArgs e)
        {
            Form formAddTeacher = new Form();
            TextBox textBoxNameTeacher = new TextBox();
            Label labelHeaderText = new Label();
            Label labelNameTeacher = new Label();

            //блок кода, для работы с формой
            formAddTeacher.Width = 600;
            formAddTeacher.Height = 300;
            formAddTeacher.BackColor = Color.FromArgb(57, 230, 57);
            formAddTeacher.Text = "Добавить преподавателя";

            //блок формы для работы с текстБоксами
            textBoxNameTeacher.Location = new Point(300, 100);
            textBoxNameTeacher.Size = new Size(200, 50);
            textBoxNameTeacher.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
            formAddTeacher.Controls.Add(textBoxNameTeacher);

            //блок формы для работы с лэйблами
            labelHeaderText.Location = new Point(200, 0);
            labelHeaderText.Font = new Font("Microsoft Sans Serif", 15, FontStyle.Bold);
            labelHeaderText.Size = new Size(250, 50);
            labelHeaderText.Text = "Введите данные:";

            labelNameTeacher.Location = new Point(100, 100);
            labelNameTeacher.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            labelNameTeacher.Size = new Size(200, 50);
            labelNameTeacher.Text = "ФИО: ";


            //Блок кода, работающий с кнопками
            Button btnAddTeacher = new Button
            {
                Location = new Point(200, 200),
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold),
                Size = new Size(200, 50),
                Text = "Добавить преподавателя:"
            };


            btnAddTeacher.MouseClick += (send, args) =>
            {
                OnBtnAddTeacherForFormAddTeacher?.Invoke(sender, EventArgs.Empty);
            }; // Кнопка в окне добавления группы            

            OnBtnAddTeacherForFormAddTeacher += (send, args) =>
            {
                try
                {
                    var listTeacher = reposTeacher.GetAll().AsParallel();
                    bool isTeacherInDB = listTeacher.AsParallel().Any(t => t.Id == reposDiscipline.GetTeachersId(textBoxNameTeacher.Text));
                    if (!isTeacherInDB)
                    {
                        reposTeacher.Add(new Teacher(textBoxNameTeacher.Text));
                        MessageBox.Show("Преподаватель добавлен!");
                        formAddTeacher.Close();
                    }
                    else
                    {
                        MessageBox.Show("Введенный преподаватель уже внесен в базу!");
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка! Проверьте введенные данные!");
                }
            };

            formAddTeacher.Controls.Add(btnAddTeacher);
            formAddTeacher.Controls.Add(labelHeaderText);
            formAddTeacher.Controls.Add(labelNameTeacher);

            formAddTeacher.Show();
        }

        private void btnAddCp_Click(object sender, EventArgs e)
        {
            int sum = 0;
            try
            {
                sum = Convert.ToInt32(tbWeghtMore.Text) + Convert.ToInt32(tbWeightLab.Text) +
                  Convert.ToInt32(tbWeightLek.Text) + Convert.ToInt32(tbWeightPrac.Text);
            }
            catch { }

            var listTextBoxes = new List<TextBox> { tbCountLab, tbCountLek, tbCountPrac };

            var emptyIsListTextBoxes = listTextBoxes.AsParallel().Any(t => t.Text == String.Empty);

            var listCpForGroup = from cp in reposCP.GetAll()
                                 where cp.DisciplineId == WorkWithDB.GetDisciplineId(DisciplineName)
                                 where cp.GroupId == WorkWithDB.GetIdGroupDisciplineGroup(reposGroup, GroupName)
                                 where cp.TermId == WorkWithDB.GetIdTermForCp(TermName)
                                 select cp;

            var sumCp = listCpForGroup.ToList().Sum(t => t.WeightKT);

            if (emptyIsListTextBoxes || sum > 100 || sum <= 0 || sum < 100 || sumCp + Convert.ToInt32(tbWeightPoint.Text) > 100)
            {
                MessageBox.Show("Проверьте введенные данные.");
                tbCountLek.BackColor = Color.Red;
                tbCountLab.BackColor = Color.Red;
                tbCountPrac.BackColor = Color.Red;
                tbWeightLek.BackColor = Color.Red;
                tbWeightLab.BackColor = Color.Red;
                tbWeightPrac.BackColor = Color.Red;
                tbWeghtMore.BackColor = Color.Red;
            }
            else
            {
                try
                {
                    //var _idTerm = WorkWithDB.GetIdTermForCp(TermName);
                    reposCP.Add(new CP(CpName, TermName, GroupName, Convert.ToInt32(tbWeightPoint.Text),
                        Convert.ToInt32(tbWeightLab.Text), Convert.ToInt32(tbWeightLek.Text), Convert.ToInt32(tbWeightPrac.Text),
                        Convert.ToInt32(tbWeghtMore.Text), Convert.ToInt32(tbCountLek.Text),
                        Convert.ToInt32(tbCountLab.Text), Convert.ToInt32(tbCountPrac.Text), DisciplineName));
                    MessageBox.Show("Точка успешно добавлена");
                    lstBCp.DataSource = listCpForGroupAndDiscipline;
                }
                catch
                {
                    MessageBox.Show("Ошибка при добавлении контрольной точки!\nПроверьте введенные данные!");
                }
            }

            listCpForGroup = null;
            sumCp = default(int);
            sum = default(int);
        }

        private async void calcul()
        {
            for (int i = 0; i < listStatementLine.Count; i++)
            {
                int poinLek = Convert.ToInt32(dataGridView1["ColumnPointLek", i].Value);


                await Task.Factory.StartNew(() =>
                {
                    if (poinLek > Convert.ToInt32(tbCountLek.Text))
                    {
                        dataGridView1["ColumnAllPoint", i].Value = CalcPointForCp.CalcScoreGeneral(Convert.ToInt32(tbWeightLek.Text), Convert.ToInt32(tbWeightLab.Text), Convert.ToInt32(tbWeightPrac.Text), Convert.ToInt32(tbWeghtMore.Text),
                       Convert.ToInt32(dataGridView1["ColumnPointLek", i].Value), Convert.ToInt32(dataGridView1["ColumnPointLab", i].Value), Convert.ToInt32(dataGridView1["ColumnPointPrac", i].Value), Convert.ToInt32(dataGridView1["ColumnPointMore", i].Value));
                    }
                    else
                    {
                        dataGridView1["ColumnPointLek", i].Value = CalcPointForCp.Calc(Convert.ToInt32(tbCountLek.Text), Convert.ToInt32(dataGridView1["ColumnPointLek", i].Value));
                        dataGridView1["ColumnAllPoint", i].Value = CalcPointForCp.CalcScoreGeneral(Convert.ToInt32(tbWeightLek.Text), Convert.ToInt32(tbWeightLab.Text), Convert.ToInt32(tbWeightPrac.Text), Convert.ToInt32(tbWeghtMore.Text),
                            Convert.ToInt32(dataGridView1["ColumnPointLek", i].Value), Convert.ToInt32(dataGridView1["ColumnPointLab", i].Value), Convert.ToInt32(dataGridView1["ColumnPointPrac", i].Value), Convert.ToInt32(dataGridView1["ColumnPointMore", i].Value));
                    }
                });
            }
        }

        private void btnCalc_Click(object sender, EventArgs e) => calcul();

        private void tbWeight_Click(object sender, EventArgs e)
        {
            tbWeightLek.BackColor = Color.White;
            tbWeightLab.BackColor = Color.White;
            tbWeightPrac.BackColor = Color.White;
            tbWeghtMore.BackColor = Color.White;
        }

        private void tbCount_Click(object sender, EventArgs e)
        {
            tbCountLek.BackColor = Color.White;
            tbCountLab.BackColor = Color.White;
            tbCountPrac.BackColor = Color.White;
        }

        private void AddItemsTbCp()
        {
            comboBoxNameCP.Items.Add("Первая");
            comboBoxNameCP.Items.Add("Вторая");
            comboBoxNameCP.Items.Add("Третья");
        }

        private async void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            await Task.Factory.StartNew(() =>
            {
                InvokeUI(() =>
                {
                    var nameStudent = dataGridView1.CurrentCell.RowIndex;

                    var nameTypeWorkCColumnIndex = dataGridView1.CurrentCell.ColumnIndex;

                    string typeWorkName = Convert.ToString(dataGridView1.Columns[nameTypeWorkCColumnIndex].HeaderText);

                    if (typeWorkName != "Лек." && typeWorkName != "ФИО" && typeWorkName != "Итог")
                    {
                        dataGridView1.ReadOnly = true;
                        dataGridView2.Size = new Size(450, 150);
                        dataGridView2.BackgroundColor = Color.FromArgb(255, 247, 101);

                        var indexColumnFIO = dataGridView2.Columns["ColumnFIODataGrid2"].Index;

                        dataGridView2.Columns[indexColumnFIO].Width = 220;

                        dataGridView2.Visible = true;

                        var _listTurn = TurnList.GetListTurn(typeWorkName, Convert.ToString(dataGridView1["columnFIO", nameStudent].Value),
                            DisciplineName, CpName, GroupName, TermName);

                        foreach (var item in _listTurn.AsParallel())
                        {
                            listTurn.Add(item);
                        }

                        try
                        {
                            int count = dataGridView2.DisplayedRowCount(true);
                            int countLab = Convert.ToInt32(tbCountLab.Text);

                            for (int i = 0; i <= countLab - count - 1; i++)
                            {
                                listTurn.Add(new TurnList("", 0, Convert.ToString(dataGridView1["columnFIO", nameStudent].Value)));
                            }
                        }
                        catch { }
                    }
                });
            });
        }

        private async void btnCloseTurn_Click(object sender, EventArgs e)
        {
            try
            {
                await Task.Factory.StartNew(() =>
                {
                    InvokeUI(() =>
                    {
                        var nameTypeWorkCColumnIndex = dataGridView1.CurrentCell.ColumnIndex;

                        var nameStudent = dataGridView1.CurrentCell.RowIndex;

                        string typeWorkName = Convert.ToString(dataGridView1.Columns[nameTypeWorkCColumnIndex].HeaderText);

                        string columnName = Convert.ToString(dataGridView1.Columns[nameTypeWorkCColumnIndex].Name);

                        dataGridView2.Visible = false;
                        var idGroup = reposStud.GetIdGroupForStudent(GroupName);
                        foreach (var item in listTurn.AsParallel())
                        {
                            if (item.Point != 0 && item.Name != String.Empty && item.NameStudent != String.Empty)
                            {
                                var _idTurn = WorkWithDB.GetIdTurn(new Turn(Convert.ToInt32(reposStud.GetIdStudent(item.NameStudent)),
                                    WorkWithDB.GetDisciplineId(DisciplineName),
                                    Convert.ToInt32(WorkWithDB.GetIdCp(CpName, idGroup, DisciplineName, TermName)),
                                    typeWorkName, item.Point, item.Name));
                                if (_idTurn == -1)
                                {
                                    reposTurn.Add(new Turn(Convert.ToInt32(reposStud.GetIdStudent(item.NameStudent)),
                                    WorkWithDB.GetDisciplineId(DisciplineName),
                                    Convert.ToInt32(WorkWithDB.GetIdCp(CpName, idGroup, DisciplineName, TermName)),
                                    typeWorkName, item.Point, item.Name));
                                }
                                else
                                {
                                    reposTurn.Update(new Turn(Convert.ToInt32(reposStud.GetIdStudent(item.NameStudent)),
                                    WorkWithDB.GetDisciplineId(DisciplineName),
                                    Convert.ToInt32(WorkWithDB.GetIdCp(CpName, idGroup, DisciplineName, TermName)),
                                    typeWorkName, item.Point, item.Name));
                                }
                            }
                        }

                        var listWork = new List<Work>();

                        foreach (var itemTurn in listTurn.AsParallel())
                        {
                            listWork.Add(new Work(itemTurn.Name, itemTurn.Point));
                        }

                        dataGridView1[columnName, nameStudent].Value = CalcPointForCp.CalcScoreLabOrPrac(listWork); // Считаем виды работ, в которых есть разворот
                        dataGridView1.ReadOnly = false;
                        calcul();
                        listWork.Clear();
                        listTurn.Clear();
                    });
                });
            }
            catch
            {
                dataGridView1.ReadOnly = false;
                dataGridView2.Visible = false;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToString(dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].HeaderText) == "ФИО")
            {
                var _idStudent = reposStud.GetIdStudent(Convert.ToString(dataGridView1.CurrentCell.Value));
                if (_idStudent == -1)
                {
                    reposStud.Add(new Student(Convert.ToString(dataGridView1.CurrentCell.Value), GroupName,
                        WorkWithDB.GetDisciplineId(GroupName)));
                }
                else
                {
                    MessageBox.Show("Студент с таким именем уже существует!");
                }
            }
        }

        //Drawing

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(255, 247, 101);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(57, 230, 57);
        }

        private void btnAddLines_MouseEnter(object sender, EventArgs e)
        {
            btnAddLines.BackColor = Color.FromArgb(255, 247, 101);
        }

        private void btnAddLines_MouseLeave(object sender, EventArgs e)
        {
            btnAddLines.BackColor = Color.FromArgb(57, 230, 57);
        }

        private void btnAddGroup_MouseEnter(object sender, EventArgs e)
        {
            btnAddGroup.BackColor = Color.FromArgb(255, 247, 101);
        }

        private void btnAddGroup_MouseLeave(object sender, EventArgs e)
        {
            btnAddGroup.BackColor = Color.FromArgb(57, 230, 57);
        }

        private void btnAddDiscipline_MouseEnter(object sender, EventArgs e)
        {
            btnAddDiscipline.BackColor = Color.FromArgb(255, 247, 101);
        }

        private void btnAddDiscipline_MouseLeave(object sender, EventArgs e)
        {
            btnAddDiscipline.BackColor = Color.FromArgb(57, 230, 57);
        }

        private void btnAddTeacher_MouseEnter(object sender, EventArgs e)
        {
            btnAddTeacher.BackColor = Color.FromArgb(255, 247, 101);
        }

        private void btnAddTeacher_MouseLeave(object sender, EventArgs e)
        {
            btnAddTeacher.BackColor = Color.FromArgb(57, 230, 57);
        }

        private void btnAddCp_MouseEnter(object sender, EventArgs e)
        {
            btnCloseDataGrid2.BackColor = Color.FromArgb(255, 247, 101);
        }

        private void btnAddCp_MouseLeave(object sender, EventArgs e)
        {
            btnCloseDataGrid2.BackColor = Color.FromArgb(57, 230, 57);
        }

        private void btnCalc_MouseEnter(object sender, EventArgs e)
        {
            btnCalc.BackColor = Color.FromArgb(255, 247, 101);
        }

        private void btnCalc_MouseLeave(object sender, EventArgs e)
        {
            btnCalc.BackColor = Color.FromArgb(57, 230, 57);
        }

        private void btnCloseTurn_MouseEnter(object sender, EventArgs e)
        {
            btnCloseTurn.BackColor = Color.FromArgb(255, 247, 101);
        }

        private void btnCloseTurn_MouseLeave(object sender, EventArgs e)
        {
            btnCloseTurn.BackColor = Color.FromArgb(57, 230, 57);
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.FromArgb(57, 230, 57);
        }

        private void buttons_MouseEnter(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.FromArgb(255, 247, 101);
        }
    }
}
//Shuvalov Maxim