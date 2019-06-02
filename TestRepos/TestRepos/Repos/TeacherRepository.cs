using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace TestRepos
{
    public class TeacherRepository : IRepository<Teacher>
    {
        public const string connectionString = "Data Source=Students.db";
        
        private List<Teacher> _databaseStub = new List<Teacher>();

        private Teacher teacher { get; set; }

        public TeacherRepository() { }

        public void Add(Teacher entity)
        {            
            _databaseStub.Add(entity);

            using (var _connection = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand(_connection))
            {
                _connection.Open();

                foreach (var item in _databaseStub)
                {
                    cmd.Parameters.AddWithValue("@Name", item.Name);                                                        
                    cmd.CommandText = "insert or replace into Teachers (teachers_name) VALUES (@Name)";
                    cmd.ExecuteNonQuery();
                }
            }

            _databaseStub.Clear();
        }

        public Teacher Get(long id)
        {

            using (var _connection = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand(_connection))
            {
                _connection.Open();
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.CommandText = "SELECT * FROM Teachers WHERE teachers_id = @Id";
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    teacher = new Teacher(Convert.ToInt32(reader["teachers_id"]),
                        Convert.ToString(reader["teahers_name"]));
                }
            }
            return teacher;
        }

        public IEnumerable<Teacher> GetAll()
        {
            List<Teacher> _teachers = new List<Teacher>();

            using (var _connection = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand(_connection))
            {
                _connection.Open();
                cmd.CommandText = "SELECT * FROM Teachers";
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _teachers.Add(new Teacher(Convert.ToInt32(reader["teachers_id"]), 
                        Convert.ToString(reader["teachers_name"])));                   
                }
            }
            return _teachers;
        }

        public void Update(Teacher entity)
        {
            if (Get(entity.Id)==null){
                throw new Exception();
            }
            
            using (var _connection = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand(_connection))
            {
                _connection.Open();
                if (entity != null)
                {
                    cmd.Parameters.AddWithValue("@Id", entity.Id);
                    cmd.Parameters.AddWithValue("@Name", entity.Name);
                    cmd.CommandText = "UPDATE Teachers SET teachers_name = @Name WHERE teachers_id = @Id";
                    cmd.ExecuteNonQuery();
                }
            }
            
        }       
    }
}
