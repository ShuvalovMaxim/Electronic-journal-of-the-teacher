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
    public class TurnRepository : IRepository<Turn>
    {
        public const string connectionString = "Data Source=Students.db";

        private List<Turn> _databaseStub = new List<Turn>();

        private Turn turn { get; set; }

        public void Add(Turn entity)
        {
            _databaseStub.Add(entity);
            using (var _connection = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand(_connection))
            {
                _connection.Open();

                foreach (var item in _databaseStub)
                {
                    cmd.Parameters.AddWithValue("@IdStudent", item.EntityCpDataShort.IdStudent);
                    cmd.Parameters.AddWithValue("@IdDiscipline", item.EntityCpDataShort.IdDiscipline);
                    cmd.Parameters.AddWithValue("@IdCp", item.EntityCpDataShort.IdCp);
                    cmd.Parameters.AddWithValue("@TypeWork", item.GetTypeId(item.TypeWorkName)); 
                    cmd.Parameters.AddWithValue("@Point", item.Point);
                    cmd.Parameters.AddWithValue("@Name", item.Name);
                    cmd.CommandText = "insert or replace into Turn (student_id, id_discipline, id_cp,typeOfWork_id, point, name) " +
                        "VALUES (@IdStudent, @IdDiscipline, @IdCp, @TypeWork, @Point, @Name)";
                    cmd.ExecuteNonQuery();                   
                }
                _databaseStub.Clear();
            }
        }

        public Turn Get(long id)
        {
            using (var _connection = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand(_connection))
            {
                _connection.Open();
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.CommandText = "SELECT * FROM Turn WHERE id = @Id";
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    turn = new Turn(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["typeOfWork_id"]), 
                        Convert.ToInt32(reader["point"]), Convert.ToString(reader["name"]), 
                        new EntityCpDataShort(Convert.ToInt32(reader["student_id"]), Convert.ToInt32(reader["id_discipline"]),
                        Convert.ToInt32(reader["id_cp"])));
                }
            }
            return turn;
        }

        public IEnumerable<Turn> GetAll()
        {
            List<Turn> _listTurn = new List<Turn>();
            using (var _connection = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand(_connection))
            {
                _connection.Open();                
                cmd.CommandText = "SELECT * FROM Turn";
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _listTurn.Add(new Turn(Convert.ToInt32(reader["id"]),
                        Convert.ToInt32(reader["typeOfWork_id"]), Convert.ToInt32(reader["point"]), Convert.ToString(reader["name"]),
                        new EntityCpDataShort(Convert.ToInt32(reader["student_id"]), Convert.ToInt32(reader["id_discipline"]),
                        Convert.ToInt32(reader["id_cp"]))));
                }
            }
            return _listTurn;
        }

        public void Update(Turn entity)
        {           

            using (var _connection = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand(_connection))
            {
                _connection.Open();
                if (entity != null)
                {
                    cmd.Parameters.AddWithValue("@Id", entity.ID);                   
                    cmd.Parameters.AddWithValue("@IdStudent", entity.EntityCpDataShort.IdStudent);
                    cmd.Parameters.AddWithValue("@IdDiscipline", entity.EntityCpDataShort.IdDiscipline);
                    cmd.Parameters.AddWithValue("@IdCp", entity.EntityCpDataShort.IdCp);
                    cmd.Parameters.AddWithValue("@TypeWork", entity.GetTypeId(entity.TypeWorkName));
                    cmd.Parameters.AddWithValue("@Point", entity.Point);
                    cmd.Parameters.AddWithValue("@Name", entity.Name);
                    cmd.CommandText = "UPDATE Turn SET point = @Point WHERE student_id = @IdStudent And id_discipline = @IdDiscipline And" +
                        " id_cp = @IdCp And name = @Name And typeOfWork_id = @TypeWork";
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
