namespace DebtMan.DomainModel.Repositories
{
    public interface IGenericRepository<TEntity, in TId> where TEntity : class
    {
        TEntity FindById(TId id);
        TEntity FindByIdAndLock(TId id);
        TEntity[] FindAll();
        TEntity MakePersistent(TEntity entity);
        void MakeTransient(TEntity entity);
    }
}
