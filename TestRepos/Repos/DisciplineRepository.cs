using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace TestRepos.Repos
{
    public class DisciplineRepository : IRepository<Discipline>
    {
        public const string connectionString = "Data Source=Students.db";

        private List<Discipline> _databaseDiscipline = new List<Discipline>();

        Discipline discipline { get; set; }

        public void Add(Discipline entity)
        {
            if (_databaseDiscipline.Any(o => o.Name == entity.Name))
                throw new Exception();
            _databaseDiscipline.Add(entity);

            using (var _connection = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand(_connection))
            {
                _connection.Open();
                foreach (var item in _databaseDiscipline)
                {
                    cmd.Parameters.AddWithValue("@Name", item.Name);                    
                    cmd.Parameters.AddWithValue("@TeachersId", this.GetTeachersId(item.TeacherName));
                    cmd.CommandText = "insert into Discipline (discipline_abr, discipline_teachers_id) VALUES (@Name, @TeachersId)";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Discipline Get(long id)
        {
            using (var _connection = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand(_connection))
            {
                _connection.Open();
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.CommandText = "SELECT * FROM Discipline WHERE discipline_id = @Id";
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    discipline = new Discipline(Convert.ToInt32(reader["discipline_id"]),
                        Convert.ToString(reader["discipline_abr"]), Convert.ToInt32(reader["discipline_teachers_id"]));
                }
            }
            return discipline;
        }

        public IEnumerable<Discipline> GetAll()
        {
            List<Discipline> _discipline = new List<Discipline>();

            using (var _connection = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand(_connection))
            {
                _connection.Open();
                cmd.CommandText = "SELECT * FROM Discipline";
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _discipline.Add(new Discipline(Convert.ToInt32(reader["discipline_id"]),
                        Convert.ToString(reader["discipline_abr"]), Convert.ToInt32(reader["discipline_teachers_id"])));
                }
            }
            return _discipline;
        }       

        public void Update(Discipline entity)
        {
            if(Get(entity.ID) == null)
            {
                throw new Exception();
            }

            using (var _connection = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand(_connection))
            {
                _connection.Open();
                if (entity != null)
                {
                    cmd.Parameters.AddWithValue("@Id", entity.ID);
                    cmd.Parameters.AddWithValue("@Name", entity.Name);
                    cmd.Parameters.AddWithValue("@TeacherId", entity.Name);
                    cmd.CommandText = "UPDATE Discipline SET discipline_abr = @Name, discipline_teachers_id = @TeacherId WHERE discipline_id = @Id";
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
