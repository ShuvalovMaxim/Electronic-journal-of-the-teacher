using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRepos.Model
{
    public class CPDataGeneral
    {
        public long ID { get; set; }
        public int ScoreGeneral { get; set; }
        public string StudentName { get; set; }
        public long StudentId { get; set; }
        public string NameDiscipline { get; set; }
        public long DisciplineId { get; set; }
        public string NameCP { get; set; }
        public long CpId { get; set; }
        public long StatementId { get; set; }
        public int PointLab { get; set; }
        public int PointLek { get; set; }
        public int PointPrac { get; set; }
        public int PointMore { get; set; }        


        public CPDataGeneral(int scoreGeneral, string studentName, string disciplineName,
           long cpId , long statementId, int pointLab, int pointLek, int pointPrac, int pointMore)
        {
            ScoreGeneral = scoreGeneral;
            StudentName = studentName;
            NameDiscipline = disciplineName;
            CpId = cpId;
            StatementId = statementId;
            PointLab = pointLab;
            PointLek = pointLek;
            PointPrac = pointPrac;
            PointMore = pointMore;            
        }

        public CPDataGeneral(int id, int scoreGeneral, int studentID, long disciplineID,
            long cpId, long statementId, int pointLab, int pointLek, int pointPrac, int pointMore)
        {
            ID = id;
            ScoreGeneral = scoreGeneral;
            StudentId = studentID;
            DisciplineId = disciplineID;
            CpId = cpId;
            StatementId = statementId;
            PointLab = pointLab;
            PointLek = pointLek;
            PointPrac = pointPrac;
            PointMore = pointMore;            
        }

        public override string ToString()
        {
            var reposStudent = RepositoryFactory<Student>.Create();
            var reposDisc = RepositoryFactory<Discipline>.Create();
            return $"Данные точки: {ID} {reposDisc.Get(DisciplineId).Name} {reposStudent.Get(StudentId).Name} ({ScoreGeneral})";
        }
    }
}
