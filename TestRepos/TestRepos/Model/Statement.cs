using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRepos.Model
{
    public  class Statement
    {
        public long ID { get; set; }
        public long TeacherId { get; set; }

        public Statement(long id, long teacherId)
        {
            ID = id;
            TeacherId = teacherId;
        }
    }
}
