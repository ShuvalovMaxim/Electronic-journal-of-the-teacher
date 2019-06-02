using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRepos.Model
{
    public class EntityCpDataShort
    {
        public int IdStudent { get; set; }
        public int IdDiscipline { get; set; }
        public int IdCp { get; set; }

        public EntityCpDataShort(int stud, int disc, int cp)
        {
            IdStudent = stud;
            IdDiscipline = disc;
            IdCp = cp;
        }

    }
}
