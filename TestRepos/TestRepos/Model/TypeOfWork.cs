using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRepos.Model
{
    public class TypeOfWork
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public TypeOfWork(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"Вид работы: {Name} - Id: {ID}";
        }
    }
}
