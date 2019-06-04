using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestRepos.Model;
using NLog;

namespace TestRepos
{
    public static class WorkWithDB
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        // Метод для репозитория студентов, позволяет получить id группы
        public static long GetIdGroupForStudent(this IRepository<Student> repositoryStude, string numberGroup)
        {
            int _idGroups = -1;
            try
            {
                var outThread = Task.Factory.StartNew(() =>
                {
                    var repositoryGroup = RepositoryFactory<Group>.Create();

                    var _listGroup = repositoryGroup.GetAll().AsParallel().ToList();

                    int count = _listGroup.AsParallel().Count();

                    for (int i = 0; i <= count - 1; i++)
                    {
                        var number = _listGroup[i].Number;
                        if (number == numberGroup)
                        {
                            _idGroups = _listGroup[i].Id;
                            break;
                        }
                    }

                    _listGroup.Clear();
                    repositoryGroup = null;
                    count = default(int);
                });

                outThread.Wait();
            }
            catch { }
            return _idGroups;
        }

        public static long GetIdStudentForCPDataGeneral(this IRepository<CPDataGeneral> repositoryCPData, string studentName)
        {
            long _idStudent = -1;

            using (var outThread = Task.Factory.StartNew(() =>
             {
                 var repositoryStudent = RepositoryFactory<Student>.Create();

                 var _listStudent = repositoryStudent.GetAll().ToArray();
                 var count = _listStudent.Count();

                 var innerThread = Task.Factory.StartNew(() =>
                 {
                     for (int i = 0; i <= count - 1; i++)
                     {
                         var name = _listStudent[i].Name;
                         if (name == studentName)
                         {
                             _idStudent = _listStudent[i].Id;
                             break;
                         }

                         else
                         {
                             continue;
                         }
                     }
                 }, TaskCreationOptions.AttachedToParent);
             }))
            {
                outThread.Wait();
            }
            return _idStudent;
        }

        //Метод для репозитория общих данных КТ, позволяет получить id дисциплины
        public static int GetIdDisciplineForCPDataGeneral(this IRepository<CPDataGeneral> general, string nameDiscipline)
        {
            int _idDiscipline = -1;

            using (var outThread = Task.Factory.StartNew(() =>
             {
                 var repositoryDiscipline = RepositoryFactory<Discipline>.Create();

                 var _listDiscipline = repositoryDiscipline.GetAll();

                 var innerThread = Task.Factory.StartNew(() =>
                 {
                     foreach (var item in _listDiscipline)
                     {
                         if (item.Name == nameDiscipline)
                         {
                             _idDiscipline = item.ID;
                             break;
                         }

                         else
                         {
                             continue;
                         }
                     }
                 }, TaskCreationOptions.AttachedToParent);
             }))
            {
                outThread.Wait();
            }

            return _idDiscipline;
        }

        //Метод для репозитория студента, который позволяет получить id студента
        public static long GetIdStudent(this IRepository<Student> repos, string nameStudent)
        {
            long _id = -1;

            try
            {
                using (var outThread = Task.Factory.StartNew(() =>
                 {
                     var _list = repos.GetAll().AsParallel().ToArray();
                     var _count = _list.Count() - 1;
                     for (int i = 0; i <= _count; i++)
                     {
                         var _name = _list[i].Name;
                         if (_name == nameStudent)
                         {
                             _id = _list[i].Id;
                             break;
                         }
                     }
                 }))
                {
                    outThread.Wait();
                }
            }
            catch { }
            return _id;
        }

        public static long GetIdTermForCp(string nameTermAndYear)
        {
            long _idTerm = -1;
            try
            {
                string[] str = nameTermAndYear.Split('|');
                var reposTerm = RepositoryFactory<Term>.Create();
                var _listTerm = reposTerm.GetAll().ToList();
                int count = _listTerm.Count();

                for (int i = 0; i <= count - 1; i++)
                {
                    if (str[0] == _listTerm[i].Name && str[1] == _listTerm[i].StudyYear)
                    {
                        _idTerm = _listTerm[i].ID;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            catch { }
            return _idTerm;
        }

        public static long GetIdGroupForCP(this IRepository<CP> cp, string groupName)
        {
            long _id = -1;
            try
            {
                var reposGroup = RepositoryFactory<Group>.Create();
                foreach (var item in reposGroup.GetAll().AsParallel())
                {
                    if (item.Number == groupName)
                    {
                        _id = item.Id;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            catch { }
            return _id;
        }

        //Метод для репозитория дисциплин, позволяет получить id преподавателя        
        public static long GetTeachersId(this IRepository<Discipline> repositoryDis, string nameTeacher)
        {
            long _idTeacher = 0;
            try
            {
                var repositoryTeachers = RepositoryFactory<Teacher>.Create();
                var listTeachers = repositoryTeachers.GetAll();
                foreach (var item in listTeachers.AsParallel())
                {
                    if (item.Name == nameTeacher)
                    {
                        _idTeacher = item.Id;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            catch { }
            return _idTeacher;
        }

        //Метод для репозитория группы. который позволяет внести данные в таблицу DisciplineGroup
        public static List<long> GetDisciplineGroup(this IRepository<Group> repositoryGroup, List<string> nameDiscipline)
        {
            var reposDisc = RepositoryFactory<Discipline>.Create();
            var listDisc = reposDisc.GetAll();
            var listGroup = repositoryGroup.GetAll();
            List<long> _listIdDisc = new List<long>();
            if (listDisc != null && listGroup != null)
            {
                foreach (var itemDisc in listDisc)
                {
                    foreach (var itemNameDisc in nameDiscipline)
                        if (itemNameDisc == itemDisc.Name)
                        {
                            _listIdDisc.Add(itemDisc.ID);
                        }
                }
            }
            listDisc = null;
            listGroup.ToList().Clear();
            return _listIdDisc;
        }

        //Метод для репозитория группы. который позволяет внести данные в таблицу DisciplineGroup
        public static long GetIdGroupDisciplineGroup(this IRepository<Group> repositoryGroup, string nameGroup)
        {
            long _idGroup = -1;
            try
            {
                var listGroup = repositoryGroup.GetAll();
                foreach (var itemGroup in listGroup)
                {
                    if (nameGroup == itemGroup.Number)
                    {
                        _idGroup = itemGroup.Id;
                    }
                }
            }
            catch
            {
                return -1;
            }

            return _idGroup;
        }

        //Метод, позволяющий получить id Дисциплины по ее названию
        public static int GetDisciplineId(string nameDiscipline)
        {
            var reposDis = RepositoryFactory<Discipline>.Create();
            var _listDis = reposDis.GetAll();
            int _idDis = -1;
            foreach (var item in _listDis)
            {
                if (item.Name == nameDiscipline)
                {
                    _idDis = item.ID;
                }
            }

            return _idDis;
        }
        // Метод, который позволяет получить студентов конкретной группы
        public static IEnumerable<Student> GetAllStudentForGroup(this IRepository<Student> repositoryStudent, string nameGroup)
        {
            List<Student> listStudentForGroup = new List<Student>();
            var _idGroup = repositoryStudent.GetIdGroupForStudent(nameGroup);
            var listStudent = repositoryStudent.GetAll();
            var repositoryGroup = RepositoryFactory<Group>.Create();
            var listGroup = repositoryGroup.GetAll();

            var listStudentsForGroup = from _student in listStudent
                                       where _student.entityGroupShort.ID == _idGroup
                                       select _student;

            return listStudentsForGroup;
        }
        // Метод, который позволят получить список дисциплин, которые ведет конкретный преподаватель
        public static IEnumerable<Discipline> GetAllDisciplineForTeacher(string nameTeacher)
        {
            IEnumerable<Discipline> listDisciplineForTeacher = null;

            var outThread = Task.Factory.StartNew(() =>
            {
                var repositoryTeacher = RepositoryFactory<Teacher>.Create();
                var listTeacher = repositoryTeacher.GetAll();
                var repositoryDiscipline = RepositoryFactory<Discipline>.Create();
                var listDiscipline = repositoryDiscipline.GetAll();

                var innerThread = Task.Factory.StartNew(() =>
                {
                    listDisciplineForTeacher = from _listTeacher in listTeacher
                                               from _listDiscipline in listDiscipline
                                               where _listTeacher.Name == nameTeacher
                                               where _listDiscipline.TeachersId == _listTeacher.Id
                                               select _listDiscipline;
                }, TaskCreationOptions.AttachedToParent);

            });

            outThread.Wait();

            return listDisciplineForTeacher;
        }
        public static IEnumerable<CP> GetAllCpForGroupAndDiscipline(string nameGroup, string nameDiscipline, string nameTerm)
        {
            IEnumerable<CP> listCpForGroup = null;
            var reposStudent = RepositoryFactory<Student>.Create();
            var outThread = Task.Factory.StartNew(() =>
            {
                var _idGroup = reposStudent.GetIdGroupForStudent(nameGroup);
                var _idTerm = WorkWithDB.GetIdTermForCp(nameTerm);
                var _idDiscipline = GetDisciplineId(nameDiscipline);
                var repositoryCp = RepositoryFactory<CP>.Create();
                var listCp = repositoryCp.GetAll();

                var innerThread = Task.Factory.StartNew(() =>
                {
                    listCpForGroup = from Cp in listCp
                                     where Cp.GroupId == _idGroup
                                     where Cp.DisciplineId == _idDiscipline
                                     where Cp.TermId == _idTerm
                                     select Cp;
                }, TaskCreationOptions.AttachedToParent);

            });

            outThread.Wait();

            return (IEnumerable<CP>)listCpForGroup;
        }
        // Метод, который позволяет получить список групп конкретной дисциплины
        public static IEnumerable<Group> GetListGroupForDiscipline(string nameDicipline)
        {
            var reposDisc = RepositoryFactory<Discipline>.Create();
            var _listDisc = reposDisc.GetAll();
            var reposDG = RepositoryFactory<DisciplineGroup>.Create();
            var _listDG = reposDG.GetAll();
            var reposGroup = RepositoryFactory<Group>.Create();
            var _listGroup = reposGroup.GetAll();

            var _listGroupForDiscipline = from itemDisc in _listDisc
                                          from itemDG in _listDG
                                          from itemGr in _listGroup
                                          where itemDisc.Name == nameDicipline && itemDG.DisciplineID == itemDisc.ID
                                          && itemGr.Id == itemDG.GroupID
                                          select itemGr;

            return _listGroupForDiscipline;
        }
        public static long GetIdCp(string nameCp, long idGroup, string nameDiscipline, string termName)
        {
            var reposCp = RepositoryFactory<CP>.Create();
            var _listCp = reposCp.GetAll();
            long _id;
            try
            {
                long _termId = WorkWithDB.GetIdTermForCp(termName);
                var cp = _listCp.First(o => o.GroupId == idGroup
                && o.Name == nameCp
                && o.DisciplineId == GetDisciplineId(nameDiscipline)
                && o.TermId == _termId);
                _id = cp.ID;
            }
            catch (Exception ex)
            {
                _logger.Error("Ошибка при получении id контрольной точки. {0}.", ex.ToString());
                _id = 0;
            }
            return _id;
        }
        public static int GetTypeId(this Turn turn, string nameWork)
        {
            if (turn == null)
            {
                throw new ArgumentNullException(nameof(turn));
            }

            var reposTypeWork = RepositoryFactory<TypeOfWork>.Create();

            var _listType = reposTypeWork.GetAll();

            var typeWork = _listType.FirstOrDefault(t => t.Name == nameWork);

            return typeWork.ID;
        }
        public static int GetIdTurn(Turn turn)
        {
            var _id = -1;
            var repos = RepositoryFactory<Turn>.Create();
            var list = repos.GetAll();


            foreach (var item in repos.GetAll())
            {
                if (item.EntityCpDataShort.IdCp == turn.EntityCpDataShort.IdCp &&
            item.Name == turn.Name && item.EntityCpDataShort.IdDiscipline == turn.EntityCpDataShort.IdDiscipline &&
            item.EntityCpDataShort.IdStudent == turn.EntityCpDataShort.IdStudent && item.TypeOfWorkId == turn.TypeOfWorkId)
                {
                    _id = item.ID;
                    break;
                }
                else
                {
                    continue;
                }
            }

            return _id;
        }
    }
}
