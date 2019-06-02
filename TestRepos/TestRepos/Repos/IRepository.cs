using System.Collections.Generic;

// Интерфейс репозитория, параметризованный тип.
// Для ознакомления: https://blog.byndyu.ru/2011/01/domain-driven-design-repository.html
public interface IRepository<T>
{
  void Add(T entity);
  T Get(long id);
  IEnumerable<T> GetAll();
  void Update(T entity);
}
