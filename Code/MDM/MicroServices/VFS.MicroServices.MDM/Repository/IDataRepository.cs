using System.Collections.Generic;

namespace VFS.MicroServices.MDM.Repository
{
    public interface IDataRepository<TEntity, U> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(U id);
        int Add(TEntity b);
        int Update(U id, TEntity b);
        int Delete(U id);
        
    }
}
