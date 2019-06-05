using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRepos.Model
{
    public class EntityGroupShort
    {
        public long ID { get; internal set; }
        public string NumberGroup { get; set; }

        public EntityGroupShort(long id, string numberGroup)
        {
            ID = id;
            NumberGroup = numberGroup;
        }

    }
}
