using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRepos.Model
{
    public class CP
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string TermName { get; set; }
        public long TermId { get; set; }
        public long GroupId { get; set; }
        public string GroupName { get; set; }
        public int WeightKT { get; set; }
        public int WeightLab { get; set; }
        public int WeightLek { get; set; }
        public int WeightPrac { get; set; }
        public int WeightMore { get; set; }
        public int CountLek { get; set; }
        public int CountLab { get; set; }
        public int CountPrac { get; set; }       
        public int DisciplineId { get; set; }
        public string NameDiscipline { get; set; }

        public CP(string name, string termName, string groupName,
            int weightKT, int weightLab, int weightLek, int weightPrac, 
            int weightMore, int countLek, int countLab, int countPrac, string nameDiscipline)
        {
            Name = name;
            TermName = termName;
            GroupName = groupName;
            WeightKT = weightKT;
            WeightLab = weightLab;
            WeightLek = weightLek;
            WeightPrac = weightPrac;
            WeightMore = weightMore;
            CountLek = countLek;
            CountLab = countLab;
            CountPrac = countPrac;
            NameDiscipline = nameDiscipline;
        }


        public CP(long id, string name, string from, string to, long termId,
            int weightKT, int weightLab, int weightLek, int weightPrac, int weightMore, 
            long groupId, int countLek, int countLab, int countPrac, int idDiscipline)
        {
            ID = id;
            GroupId = groupId;
            Name = name;
            From = from;
            To = to;
            TermId = termId;            
            WeightKT = weightKT;
            WeightLab = weightLab;
            WeightLek = weightLek;
            WeightPrac = weightPrac;
            WeightMore = weightMore;
            CountLek = countLek;
            CountLab = countLab;
            CountPrac = countPrac;
            DisciplineId = idDiscipline;
        }

        public override string ToString()
        {
            return $"*{Name} - {WeightKT}%";
        }

    }
}
