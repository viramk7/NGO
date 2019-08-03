using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NGOWorld.Data.Repository.Generic
{
    public partial interface IRepository<TEntity> where TEntity : class
    {
        #region Methods

        TEntity GetById(object id);

        void Insert(TEntity entity);

        void Insert(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void Update(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);

        void Delete(IEnumerable<TEntity> entities);

        void DeleteById(object id);

        #endregion

        #region Properties

        IQueryable<TEntity> Table { get; }

        IQueryable<TEntity> TableNoTracking { get; }

        #endregion
    }
}
