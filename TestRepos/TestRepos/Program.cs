using System;
using System.Diagnostics;
using TestRepos;
using TestRepos.Model;
using TestRepos.Repos;

namespace _repo
{
    class Program
    {
        static void Main(string[] args)
        {            
            var repositoryTeacher = RepositoryFactory<Teacher>.Create();           
            var repositoryDiscipline = RepositoryFactory<Discipline>.Create();            
            var repository = RepositoryFactory<Student>.Create();
            var repositoryDataGeneral = RepositoryFactory<CPDataGeneral>.Create();
            var repositoryCP = RepositoryFactory<CP>.Create();
            var repositoryGroup = RepositoryFactory<Group>.Create();
            var repositoryTurn = RepositoryFactory<Turn>.Create();

            Stopwatch sw = new Stopwatch();
            sw.Start();
            var id = repository.GetIdGroupForStudent("Пиб-17и1");
            sw.Stop();
            Console.WriteLine($"Айди группы:{id} | Выполнено за: {sw.Elapsed.Milliseconds} мс.");
            Console.ReadKey();

           
        }
    }
}
