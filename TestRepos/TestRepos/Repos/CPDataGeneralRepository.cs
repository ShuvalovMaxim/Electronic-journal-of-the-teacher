using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace TestRepos.Model
{
    public class CPDataGeneralRepository : IRepository<CPDataGeneral>
    {
        public const string connectionString = "Data Source=Students.db";

        private List<CPDataGeneral> _databaseStub = new List<CPDataGeneral>();

        private CPDataGeneral dataGeneral { get; set; }

        public void Add(CPDataGeneral entity)
        {
            _databaseStub.Add(entity);

            using (var _connection = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand(_connection))
            {
                _connection.Open();

                foreach (var item in _databaseStub)
                {
                    cmd.Parameters.AddWithValue("@ScoreGeneral", item.ScoreGeneral);
                    cmd.Parameters.AddWithValue("@StudentId", this.GetIdStudentForCPDataGeneral(item.StudentName));
                    cmd.Parameters.AddWithValue("@DisciplineId", this.GetIdDisciplineForCPDataGeneral(item.NameDiscipline));
                    cmd.Parameters.AddWithValue("@CpId", item.CpId);
                    cmd.Parameters.AddWithValue("@StatementId", item.StatementId);
                    cmd.Parameters.AddWithValue("@PointLab", item.PointLab);
                    cmd.Parameters.AddWithValue("@PointLek", item.PointLek);
                    cmd.Parameters.AddWithValue("@PointPrac", item.PointPrac);
                    cmd.Parameters.AddWithValue("@PointMore", item.PointMore);
                    cmd.CommandText = "insert or replace into CPDataGeneral (score_general, student_id, discipline_id, " +
                        "cp_id, statement_id, point_lab, point_lek, point_prac, point_more) VALUES (@ScoreGeneral , " +
                        "@StudentId, @DisciplineId, @CpId, @StatementId, @PointLab, @PointLek, @PointPrac, @PointMore)";
                    cmd.ExecuteNonQuery();

                }
            }

            _databaseStub.Clear();
        }

        public CPDataGeneral Get(long id)
        {

            using (var _connection = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand(_connection))
            {
                _connection.Open();
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.CommandText = "SELECT * FROM CPDataGeneral WHERE id = @Id";
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dataGeneral = new CPDataGeneral(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["score_general"]), Convert.ToInt32(reader["student_id"]),
                        Convert.ToInt32(reader["discipline_id"]), Convert.ToInt32(reader["cp_id"]), Convert.ToInt32(reader["statement_id"]),
                        Convert.ToInt32(reader["point_lek"]), Convert.ToInt32(reader["point_lab"]), Convert.ToInt32(reader["point_prac"]), Convert.ToInt32(reader["point_more"]));
                }
            }
            return dataGeneral;
        }

        public IEnumerable<CPDataGeneral> GetAll()
        {

            List<CPDataGeneral> _dataGeneral = new List<CPDataGeneral>();
            try
            {
                using (var _connection = new SQLiteConnection(connectionString))
                using (var cmd = new SQLiteCommand(_connection))
                {
                    _connection.Open();
                    cmd.CommandText = "SELECT * FROM CPDataGeneral";
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        _dataGeneral.Add(new CPDataGeneral(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["score_general"]), Convert.ToInt32(reader["student_id"]),
                            Convert.ToInt32(reader["discipline_id"]), Convert.ToInt32(reader["cp_id"]), Convert.ToInt32(reader["statement_id"]),
                            Convert.ToInt32(reader["point_lab"]), Convert.ToInt32(reader["point_lek"]), Convert.ToInt32(reader["point_prac"]), Convert.ToInt32(reader["point_more"])));
                    }
                }
            }
            catch { }

            return _dataGeneral;
        }

        public void Update(CPDataGeneral entity)
        {
            try
            {
                using (var _connection = new SQLiteConnection(connectionString))
                using (var cmd = new SQLiteCommand(_connection))
                {
                    _connection.Open();
                    if (entity != null)
                    {
                        cmd.Parameters.AddWithValue("@ScoreGeneral", entity.ScoreGeneral);
                        cmd.Parameters.AddWithValue("@Id", entity.ID);
                        cmd.Parameters.AddWithValue("@StudentId", this.GetIdStudentForCPDataGeneral(entity.StudentName));
                        cmd.Parameters.AddWithValue("@DisciplineId", this.GetIdDisciplineForCPDataGeneral(entity.NameDiscipline));
                        cmd.Parameters.AddWithValue("@CpId", entity.CpId);
                        cmd.Parameters.AddWithValue("@StatementId", entity.StatementId);
                        cmd.Parameters.AddWithValue("@PointLab", entity.PointLab);
                        cmd.Parameters.AddWithValue("@PointLek", entity.PointLek);
                        cmd.Parameters.AddWithValue("@PointPrac", entity.PointPrac);
                        cmd.Parameters.AddWithValue("@PointMore", entity.PointMore);
                        cmd.CommandText = "UPDATE CPDataGeneral SET score_general = @ScoreGeneral, point_lek = @PointLek,  point_lab = @PointLab, " +
                            " point_prac = @PointPrac,  point_more = @PointMore, student_id = @StudentId WHERE student_id = @StudentId And discipline_id = @DisciplineId" +
                            " And cp_id = @CpId";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch { }
        }
    }
}
