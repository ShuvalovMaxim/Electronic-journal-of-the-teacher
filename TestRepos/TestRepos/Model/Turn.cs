using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRepos.Model
{
    public class Turn
    {
        public int ID { get; set; }        
        public EntityCpDataShort EntityCpDataShort { get; set; }
        public int TypeOfWorkId { get; set; }
        public string TypeWorkName { get; set; }
        public int Point { get; set; }
        public string Name { get; set; }

        public Turn(int studentId, int discId, int idCp,string typeWorkName, int point, string name)
        {
            EntityCpDataShort = new EntityCpDataShort(studentId, discId, idCp);
            TypeWorkName = typeWorkName;
            TypeOfWorkId = this.GetTypeId(typeWorkName);
            Point = point;
            Name = name;
        }

        public Turn(int id, int typeWorkId, int point, string name, EntityCpDataShort entityCpDataShort)
        {
            ID = id;
            EntityCpDataShort = entityCpDataShort;
            TypeOfWorkId = typeWorkId;
            Point = point;
            Name = name;
        }

    }
}
