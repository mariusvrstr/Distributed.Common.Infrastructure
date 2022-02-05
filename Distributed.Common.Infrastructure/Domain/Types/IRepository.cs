namespace Distributed.Common.Infrastructure.Domain.Types;

public interface IRepository<T>
       where T : IDatabaseEntity
{
    T GetById(Guid id);
    IList<T> FindAll();
    T Add(T entity);
    T Update(Guid id, T entity);
    void Remove(Guid id);
    void Save();
}