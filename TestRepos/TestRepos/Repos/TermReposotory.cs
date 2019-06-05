using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using TestRepos.Model;

namespace TestRepos.Repos
{
    public class TermRepository : IRepository<Term>
    {
        public const string connectionString = "Data Source=Students.db";

        private List<Term> _listTerm = new List<Term>();

        private Term term { get; set; }

        public void Add(Term entity)
        {
            
            _listTerm.Add(entity);

            using (var _connection = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand(_connection))
            {
                _connection.Open();

                foreach (var item in _listTerm)
                {                    
                    cmd.Parameters.AddWithValue("@Name", item.Name);
                    cmd.Parameters.AddWithValue("@StudyYear", item.StudyYear);
                    cmd.CommandText = "insert into Term (id, name, study_year) VALUES (@Id, @Name, @StudyYear)";
                    cmd.ExecuteNonQuery();

                }
            }

            _listTerm.Clear();
        }

        public Term Get(long id)
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
                    term = new Term(Convert.ToInt32(reader["id"]), Convert.ToString(reader["name"]), Convert.ToString(reader["study_year"]));
                }
            }
            return term;
        }

        public IEnumerable<Term> GetAll()
        {
            List<Term> _listTerm = new List<Term>();

            using (var _connection = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand(_connection))
            {
                _connection.Open();
                cmd.CommandText = "SELECT * FROM Term";
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _listTerm.Add(new Term(Convert.ToInt32(reader["id"]), Convert.ToString(reader["name"]),
                        Convert.ToString(reader["study_year"])));
                }
            }
            return _listTerm;
        }

        public void Update(Term entity)
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
                    cmd.Parameters.AddWithValue("@Name", entity.Name);
                    cmd.Parameters.AddWithValue("@StudyYear", entity.StudyYear);
                    cmd.CommandText = "UPDATE Term SET name = @Name, study_year = @StudyYear WHERE id = @Id";
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
