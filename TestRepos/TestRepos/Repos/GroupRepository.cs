using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;

namespace TestRepos
{
    public class GroupRepository : IRepository<Group>
    {
        public const string connectionString = "Data Source=Students.db";

        private List<Group> _databaseGroup = new List<Group>();

        Group group { get; set; }

        public void Add(Group entity)
        {
            if (_databaseGroup.Any(o => o.Number == entity.Number))
                throw new Exception();
            _databaseGroup.Add(entity);

            using (var _connection = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand(_connection))
            {
                _connection.Open();
                foreach (var item in _databaseGroup)
                {
                    cmd.Parameters.AddWithValue("@Number", item.Number);
                    cmd.Parameters.AddWithValue("@Faculty", item.Faculty);
                    cmd.Parameters.AddWithValue("@Cours", item.Course);                                                         
                    cmd.CommandText = "insert into Groups (group_number, group_faculty, group_course) " +
                        "VALUES (@Number, @Faculty, @Cours)";
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.AddWithValue("@Id", this.GetIdGroupDisciplineGroup(item.Number));
                    var _listDisc = this.GetDisciplineGroup(item.NameDiscipline);

                    if (_listDisc != null)
                    {
                        foreach (var itemDisc in _listDisc)
                        {
                            cmd.Parameters.AddWithValue("@DisciplineId", itemDisc);
                            cmd.CommandText = "insert into DisciplineGroup (id_group, id_discipline) " +
                                "VALUES (@Id, @DisciplineId)";
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public Group Get(long id)
        {
            using (var _connection = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand(_connection))
            {
                _connection.Open();
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.CommandText = "SELECT * FROM Groups WHERE group_id = @Id";
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    group = new Group(Convert.ToString(reader["group_number"]), Convert.ToString(reader["group_faculty"]),
                        Convert.ToInt32(reader["group_course"]), Convert.ToInt32(reader["group_id"]));
                }
            }
            return group;
        }

        public IEnumerable<Group> GetAll()
        {
            List<Group> _groups = new List<Group>();

            using (var _connection = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand(_connection))
            {
                _connection.Open();
                cmd.CommandText = "SELECT * FROM Groups";
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _groups.Add(new Group(Convert.ToString(reader["group_number"]),
                        Convert.ToString(reader["group_faculty"]),
                        Convert.ToInt32(reader["group_course"]),
                        Convert.ToInt32(reader["group_id"])));
                }
            }
            return _groups;
        }       

        public void Update(Group entity)
        {
            if(Get(entity.Id) == null)
            {
                throw new Exception();
            }

            using (var _connection = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand(_connection))
            {
                _connection.Open();
                if (entity != null)
                {
                    cmd.Parameters.AddWithValue("@Id", entity.Id);
                    cmd.Parameters.AddWithValue("@Name", entity.Number);
                    cmd.Parameters.AddWithValue("@Faculty", entity.Faculty);
                    cmd.Parameters.AddWithValue("@Course", entity.Course);
                    cmd.CommandText = "UPDATE Groups SET group_number = @Name, group_faculty = @Faculty, group_course = @Course WHERE group_id = @Id";
                    cmd.ExecuteNonQuery();
                }
            }
        }     
    }
}



