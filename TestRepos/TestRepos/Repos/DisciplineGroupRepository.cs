using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using TestRepos.Model;

namespace TestRepos.Repos
{
    public class DisciplineGroupRepository : IRepository<DisciplineGroup>
    {
        public const string connectionString = "Data Source=Students.db";

        public void Add(DisciplineGroup entity)
        {
            throw new NotImplementedException();
        }

        public DisciplineGroup Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DisciplineGroup> GetAll()
        {
            List<DisciplineGroup> _listDisciplineGroup = new List<DisciplineGroup>();

            using (var _connection = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand(_connection))
            {
                _connection.Open();
                cmd.CommandText = "SELECT * FROM DisciplineGroup";
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _listDisciplineGroup.Add(new DisciplineGroup(Convert.ToInt32(reader["id"]),                        
                        Convert.ToInt32(reader["id_discipline"]),
                        Convert.ToInt32(reader["id_group"])));
                }
            }
            return _listDisciplineGroup;
        }

        public void Update(DisciplineGroup entity)
        {
            throw new NotImplementedException();
        }
    }
}
