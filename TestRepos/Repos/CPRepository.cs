using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using TestRepos.Model;

namespace TestRepos.Repos
{
    public class CPRepository : IRepository<CP>
    {
        public const string connectionString = "Data Source=Students.db";

        private List<CP> _databaseStub = new List<CP>();

        private CP cp { get; set; }

        public void Add(CP entity)
        {           
            _databaseStub.Add(entity);

            using (var _connection = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand(_connection))
            {
                _connection.Open();

                foreach (var item in _databaseStub)
                {                   
                    cmd.Parameters.AddWithValue("@Name", item.Name);                   
                    cmd.Parameters.AddWithValue("@TermId", WorkWithDB.GetIdTermForCp(item.TermName));
                    cmd.Parameters.AddWithValue("@WeightKT", item.WeightKT);
                    cmd.Parameters.AddWithValue("@WeightLab", item.WeightLab);
                    cmd.Parameters.AddWithValue("@WeightLek", item.WeightLek);
                    cmd.Parameters.AddWithValue("@WeightPrac", item.WeightPrac);
                    cmd.Parameters.AddWithValue("@WeightMore", item.WeightMore);
                    cmd.Parameters.AddWithValue("@GroupId", this.GetIdGroupForCP(item.GroupName));
                    cmd.Parameters.AddWithValue("@CountLek", entity.CountLek);
                    cmd.Parameters.AddWithValue("@CountLab", entity.CountLab);
                    cmd.Parameters.AddWithValue("@CountPrac", entity.CountPrac);
                    cmd.Parameters.AddWithValue("@IdDiscipline", WorkWithDB.GetDisciplineId(entity.NameDiscipline));

                    cmd.CommandText = "insert or replace into CP (name,  " +
                        "term_id, weight_lab, weight_lek, weight_prac, weight_more, weight_kt, group_id, countLek, countLab, countPrac, discipline_id) VALUES" +
                        " (@Name, @TermId, @WeightLab, @WeightLek, @WeightPrac, @WeightMore, @WeightKT, @GroupId, @CountLek, @CountLab, @CountPrac, @IdDiscipline)";
                    cmd.ExecuteNonQuery();

                }
            }
            _databaseStub.Clear();
        }

        public CP Get(long id)
        {
            using (var _connection = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand(_connection))
            {
                _connection.Open();
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.CommandText = "SELECT * FROM CP WHERE id = @Id";
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cp = new CP(Convert.ToInt32(reader["id"]), Convert.ToString(reader["name"]), Convert.ToString(reader["_from"]),
                        Convert.ToString(reader["_to"]), Convert.ToInt32(reader["term_id"]), Convert.ToInt32(reader["weight_kt"]),
                        Convert.ToInt32(reader["weight_lab"]), Convert.ToInt32(reader["weight_lek"]), Convert.ToInt32(reader["weight_prac"]), 
                        Convert.ToInt32(reader["weight_more"]), Convert.ToInt32(reader["group_id"]), Convert.ToInt32(reader["countLek"]),
                        Convert.ToInt32(reader["countLab"]), Convert.ToInt32(reader["countPrac"]), Convert.ToInt32(reader["discipline_id"]));
                }
            }
            return cp;
        }

        public IEnumerable<CP> GetAll()
        {
            List<CP> _listCP = new List<CP>();

            using (var _connection = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand(_connection))
            {
                _connection.Open();
                cmd.CommandText = "SELECT * FROM CP";
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _listCP.Add(new CP(Convert.ToInt32(reader["id"]), Convert.ToString(reader["name"]), Convert.ToString(reader["_from"]),
                        Convert.ToString(reader["_to"]), Convert.ToInt32(reader["term_id"]), Convert.ToInt32(reader["weight_kt"]),
                        Convert.ToInt32(reader["weight_lab"]), Convert.ToInt32(reader["weight_lek"]), Convert.ToInt32(reader["weight_prac"]),
                        Convert.ToInt32(reader["weight_more"]), Convert.ToInt32(reader["group_id"]), Convert.ToInt32(reader["countLek"]), 
                        Convert.ToInt32(reader["countLab"]), Convert.ToInt32(reader["countPrac"]), Convert.ToInt32(reader["discipline_id"])));
                }
            }
            return _listCP;
        }

        public void Update(CP entity)
        {           
            using (var _connection = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand(_connection))
            {
                _connection.Open();
                if (entity != null)
                {
                    var _idGroup = this.GetIdGroupForCP(entity.GroupName);
                    cmd.Parameters.AddWithValue("@Id", WorkWithDB.GetIdCp(entity.Name, _idGroup, entity.NameDiscipline, entity.TermName));
                    cmd.Parameters.AddWithValue("@Name", entity.Name);
                    cmd.Parameters.AddWithValue("@From", entity.From);
                    cmd.Parameters.AddWithValue("@To", entity.To);
                    cmd.Parameters.AddWithValue("@TermId", entity.TermId);
                    cmd.Parameters.AddWithValue("@WeightKT", entity.WeightKT);
                    cmd.Parameters.AddWithValue("@WeightLab", entity.WeightLab);
                    cmd.Parameters.AddWithValue("@WeightLek", entity.WeightLek);
                    cmd.Parameters.AddWithValue("@WeightPrac", entity.WeightPrac);
                    cmd.Parameters.AddWithValue("@WeightMore", entity.WeightMore);
                    cmd.Parameters.AddWithValue("@GroupId", this.GetIdGroupForCP(entity.GroupName));
                    cmd.Parameters.AddWithValue("@CountLek", entity.CountLek);
                    cmd.Parameters.AddWithValue("@CountLab", entity.CountLab);
                    cmd.Parameters.AddWithValue("@CountPrac", entity.CountPrac);                    

                    cmd.CommandText = "UPDATE CP SET weight_lab = @WeightLab, weight_lek = @WeightLek, " +
                        "weight_prac = @WeightPrac, weight_more = @WeightMore, weight_kt = @WeightKT, " +
                        "countLek = @CountLek, countLab = @CountLab, countPrac = @CountPrac WHERE id = @Id";
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
