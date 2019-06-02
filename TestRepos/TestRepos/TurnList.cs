using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRepos.Model;
using TestRepos.Repos;
using TestRepos;

namespace TestRepos
{
    public class TurnList
    {
        public string Name { get; set; }
        public int Point { get; set; }
        public string NameStudent { get; set; }

        public TurnList(string name, int point, string nameStudent)
        {
            Name = name;
            Point = point;
            NameStudent = nameStudent;
        }

        public static List<TurnList> GetListTurn(string nameTypeWork, string nameStudent, 
            string nameDiscipline, string nameCp, string nameGroup, string nameTerm)
        {
            List<TurnList> list = new List<TurnList>();
            var reposTurn = RepositoryFactory<Turn>.Create();
            var reposStud = RepositoryFactory<Student>.Create();
            var reposDiscip = RepositoryFactory<Discipline>.Create();
            var reposCp = RepositoryFactory<CP>.Create();

            var idGroup = reposStud.GetIdGroupForStudent(nameGroup);
            var idStudent = reposStud.GetIdStudent(nameStudent);
            var idDiscipline = WorkWithDB.GetDisciplineId(nameDiscipline);
            var idCp = WorkWithDB.GetIdCp(nameCp, idGroup, nameDiscipline, nameTerm);

            var _listTurn = reposTurn.GetAll();

            foreach (var item in _listTurn)
            {
                if (item.EntityCpDataShort.IdCp == idCp && item.EntityCpDataShort.IdDiscipline == idDiscipline
                    && item.EntityCpDataShort.IdStudent == idStudent && item.TypeOfWorkId == item.GetTypeId(nameTypeWork))
                {
                    list.Add(new TurnList(item.Name, item.Point, nameStudent));                    
                }
                else
                {
                    continue;
                }
            }

            return list;

        }

    }
}
