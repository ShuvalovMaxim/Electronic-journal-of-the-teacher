using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using TestRepos.Model;

namespace TestRepos.Repos
{
    class StatementRepository : IRepository<Statement>
    {
        public const string connectionString = "Data Source=Students.db";

        private List<Statement> _listStatement = new List<Statement>();

        private Statement statement { get; set; }

        public void Add(Statement entity)
        {
            if (_listStatement.Any(o => o.ID == entity.ID))
                throw new Exception();
            _listStatement.Add(entity);

            using (var _connection = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand(_connection))
            {
                _connection.Open();

                foreach (var item in _listStatement)
                {                    
                    cmd.Parameters.AddWithValue("@Id", item.ID);                   
                    cmd.Parameters.AddWithValue("@IdTeacher", item.TeacherId);
                    cmd.CommandText = "insert or replace into Statement (id, teacher_id) VALUES (@Id, @IdTeacher)";
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public Statement Get(long id)
        {
            using (var _connection = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand(_connection))
            {
                _connection.Open();
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.CommandText = "SELECT * FROM Statement WHERE student_id = @Id";
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    statement = new Statement(Convert.ToInt32(reader["id"]),
                        Convert.ToInt32(reader["teacher_id"]));
                }
            }
            return statement;
        }

        public IEnumerable<Statement> GetAll()
        {
            List<Statement> _listStatement = new List<Statement>();

            using (var _connection = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand(_connection))
            {
                _connection.Open();
                cmd.CommandText = "SELECT * FROM Statement";
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _listStatement.Add(new Statement(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["teacher_id"])));
                }
            }
            return _listStatement;
        }

        public void Update(Statement entity)
        {
            if (Get(entity.ID) == null)
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
                    cmd.Parameters.AddWithValue("@TeacherID", entity.TeacherId);
                    cmd.CommandText = "UPDATE Statement SET teacher_id = @TeacherID WHERE id = @Id";
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
