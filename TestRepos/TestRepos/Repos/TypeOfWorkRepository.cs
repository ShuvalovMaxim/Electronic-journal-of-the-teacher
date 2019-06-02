using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using TestRepos.Model;
using TestRepos;

namespace TestRepos.Repos
{
    public class TypeOfWorkRepository : IRepository<TypeOfWork>
    {
        public const string connectionString = "Data Source=Students.db";

        public void Add(TypeOfWork entity)
        {
            throw new NotImplementedException();
        }

        public TypeOfWork Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TypeOfWork> GetAll()
        {
            List<TypeOfWork> _listType = new List<TypeOfWork>();
            using (var _connection = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand(_connection))
            {
                _connection.Open();
                cmd.CommandText = "SELECT * FROM typeOfWork";
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _listType.Add(new TypeOfWork(Convert.ToInt32(reader["id"]), Convert.ToString(reader["name"])));
                }
            }
            return _listType;
        }

        public void Update(TypeOfWork entity)
        {
            throw new NotImplementedException();
        }
    }
}
