using System.Data.SQLite;
using TestRepos;
using TestRepos.Model;

public class Student
{

    public long Id { get; internal set; }

    public string Name { get; internal set; }

    public EntityGroupShort entityGroupShort { get; internal set; }

    public Student() { }

    public Student(string name, string numberGroup, long idGroup)
    {
        Name = name;
        entityGroupShort = new EntityGroupShort(idGroup, numberGroup);
    }

    public Student(long id, string name, EntityGroupShort _entityGroupShort) // Конструктор, для считывания данных из базы
    {
        Id = id;
        Name = name;
        entityGroupShort = _entityGroupShort;
        //entityGroupShort = _entityGroupShort ?? throw new System.ArgumentNullException(nameof(_entityGroupShort));
    }

    public override string ToString()
    {
        return $"Студент {Name} ({Id}) {entityGroupShort.NumberGroup}";
    }
}
