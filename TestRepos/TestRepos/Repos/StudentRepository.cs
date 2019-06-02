using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using TestRepos.Model;
using TestRepos;

public class StudentRepository : IRepository<Student> {
    public const string connectionString = "Data Source=Students.db";

    // Имитация базы данных.
    private List<Student> _databaseStub = new List<Student> ();

    private Student student { get; set; }

    public StudentRepository () { }

    public void Add (Student entity) {

        _databaseStub.Add (entity);

        using (var _connection = new SQLiteConnection (connectionString))
        using (var cmd = new SQLiteCommand (_connection)) {
            _connection.Open ();

            foreach (var item in _databaseStub) {
                cmd.Parameters.AddWithValue ("@Name", item.Name);               
                cmd.Parameters.AddWithValue ("@NumberGroup", item.entityGroupShort.NumberGroup);
                cmd.Parameters.AddWithValue("@IdGroup", this.GetIdGroupForStudent(item.entityGroupShort.NumberGroup));
                cmd.CommandText = "insert or replace into Students (student_name, student_number_group, student_group_id) VALUES (@Name, @NumberGroup, @IdGroup)";
                cmd.ExecuteNonQuery ();

            }
        }
        _databaseStub.Clear();
    }

    public Student Get (long id) {

        using (var _connection = new SQLiteConnection (connectionString))
        using (var cmd = new SQLiteCommand (_connection)) {
            _connection.Open ();
            cmd.Parameters.AddWithValue ("@Id", id);
            cmd.CommandText = "SELECT * FROM Students WHERE student_id = @Id";
            SQLiteDataReader reader = cmd.ExecuteReader ();
            while (reader.Read ()) {
                student = new Student (Convert.ToInt32 (reader["student_id"]),
                    Convert.ToString (reader["student_name"]), new EntityGroupShort(
                    Convert.ToInt32(reader["student_group_id"]), Convert.ToString(reader["student_number_group"])));
            }
        }
        return student;
    }

    public IEnumerable<Student> GetAll () {
        List<Student> _students = new List<Student> ();

        using (var _connection = new SQLiteConnection (connectionString))
        using (var cmd = new SQLiteCommand (_connection)) {
            _connection.Open ();
            cmd.CommandText = "SELECT * FROM Students";
            SQLiteDataReader reader = cmd.ExecuteReader ();
            while (reader.Read ()) {
                _students.Add (new Student (Convert.ToInt32 (reader["student_id"]), Convert.ToString (reader["student_name"]), new EntityGroupShort(
                    Convert.ToInt32(reader["student_group_id"]), Convert.ToString(reader["student_number_group"]))));
            }
        }
        return _students;
    }

    public void Update (Student entity) {        

        if(Get(entity.Id) == null)
        {
            throw new Exception();
        }

        using (var _connection = new SQLiteConnection (connectionString))
        using (var cmd = new SQLiteCommand (_connection)) {
            _connection.Open ();
            if (entity != null) {
                cmd.Parameters.AddWithValue ("@Id", entity.Id);
                cmd.Parameters.AddWithValue ("@Name", entity.Name);
                cmd.CommandText = "UPDATE Students SET student_name = @Name WHERE student_id = @Id";
                cmd.ExecuteNonQuery ();
            }
        }
        
    }
    
}