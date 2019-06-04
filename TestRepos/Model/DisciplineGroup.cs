using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRepos.Model
{
    public class DisciplineGroup
    {
        public long ID { get; set; }
        public long DisciplineID { get; set; }
        public long GroupID { get; set; }

        public DisciplineGroup(long id, long disciplineID, long groupID)
        {
            ID = id;
            DisciplineID = disciplineID;
            GroupID = groupID;
        }
    }
}
