using System.Collections.Generic;
using System.Linq;
using TestRepos.Model;

namespace TestRepos
{
    public class StatementLine
    {
        public string FIO { get; set; }
        public string PointForLek { get; set; }
        public int PointForLab { get; set; }
        public int PointForPrac { get; set; }
        public int PointForMore { get; set; }
        public int PointGeneral { get; set; }
        public int IdCpDat { get; set; }

        public StatementLine() { }

        public StatementLine(string fio, int lek, int lab, int prac, int more, int general, int idCpData)
        {
            FIO = fio;
            PointForLek = lek.ToString();
            PointForLab = lab;
            PointForPrac = prac;
            PointForMore = more;
            PointGeneral = general;
            IdCpDat = idCpData;
        }

        public StatementLine(string fio, int lek, int lab, int prac, int more, int general)
        {
            FIO = fio;
            PointForLek = lek.ToString();
            PointForLab = lab;
            PointForPrac = prac;
            PointForMore = more;
            PointGeneral = general;
        }

        public static IEnumerable<StatementLine> GetListStatementLine(long numberCP, int disciplineId, int groupId, long termId)
        {
            List<StatementLine> list = new List<StatementLine>();
            var reposCpDataGeneral = RepositoryFactory<CPDataGeneral>.Create();
            var reposStudent = RepositoryFactory<Student>.Create();
            var reposCP = RepositoryFactory<CP>.Create();
            var cp = reposCP.GetAll().AsParallel();
            var _listCpData = reposCpDataGeneral.GetAll().AsParallel();
            var _listStudent = reposStudent.GetAll().AsParallel();

            foreach (var itemStudent in _listStudent.AsParallel())
            {
                foreach (var itemCpData in _listCpData.AsParallel())
                {
                    foreach (var itemCP in cp.AsParallel())
                    {

                        if (itemStudent.Id == itemCpData.StudentId
                            && itemCpData.DisciplineId == disciplineId 
                            && itemStudent.entityGroupShort.ID == groupId 
                            && groupId == itemCP.GroupId && itemCP.DisciplineId == disciplineId && itemCpData.CpId == itemCP.ID 
                            && itemCP.ID == numberCP && itemCP.TermId == termId)
                        {
                            list.Add(new StatementLine(itemStudent.Name, itemCpData.PointLek, itemCpData.PointLab, itemCpData.PointPrac, itemCpData.PointMore, itemCpData.ScoreGeneral));
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }

            List<StatementLine> listNonCpDataGeneral = new List<StatementLine>();

            foreach (var itemStudent in _listStudent.AsParallel())
            {
                if (list.Any(t => t.FIO == itemStudent.Name))
                {
                    continue;
                }
                else if (!list.Any(t => t.FIO == itemStudent.Name) && itemStudent.entityGroupShort.ID == groupId)
                {
                    listNonCpDataGeneral.Add(new StatementLine(itemStudent.Name, 0, 0, 0, 0, 0));

                }
            }


            IEnumerable<StatementLine> statementLine = listNonCpDataGeneral.AsParallel().Concat(list.AsParallel());

            return statementLine.ToList<StatementLine>();

        }
    }
}
