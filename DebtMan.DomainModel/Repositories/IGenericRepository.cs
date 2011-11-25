using System;

namespace DebtMan.DomainModel.Repositories
{
    public interface IGenericRepository<T, ID>
    {
        T FindById(ID id);
        T FindByIdAndLock(ID id);
        T[] FindAll();
        T MakePersistent(T entity);
        void MakeTransient(T entity);
    }
}
