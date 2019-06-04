using System;
using TestRepos;
using TestRepos.Repos;
using TestRepos.Model;

// Фабрика репозиториев. Позволяет инкапсулировать создание экземпляров репозиториев.
// Таким образом, конкретная реализация интерфейса репозитория создаётся в одном месте
// и может быть легко подменена на другую.
public static class RepositoryFactory<T>
{
  public static IRepository<T> Create()
  {
        if (typeof(T) == typeof(Student))
            return new StudentRepository() as IRepository<T>;
        else if (typeof(T) == typeof(Group))
            return new GroupRepository() as IRepository<T>;
        else if (typeof(T) == typeof(Teacher))
            return new TeacherRepository() as IRepository<T>;
        else if (typeof(T) == typeof(Discipline))
            return new DisciplineRepository() as IRepository<T>;
        else if (typeof(T) == typeof(CPDataGeneral))
            return new CPDataGeneralRepository() as IRepository<T>;
        else if (typeof(T) == typeof(CP))
            return new CPRepository() as IRepository<T>;
        else if (typeof(T) == typeof(Term))
            return new TermRepository() as IRepository<T>;
        else if (typeof(T) == typeof(DisciplineGroup))
            return new DisciplineGroupRepository() as IRepository<T>;
        else if (typeof(T) == typeof(Turn))
            return new TurnRepository() as IRepository<T>;
        else if (typeof(T) == typeof(TypeOfWork))
            return new TypeOfWorkRepository() as IRepository<T>;
        throw new Exception();
  }
}
