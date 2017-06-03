using EShop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;

namespace EShop.DAL.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        public IUnitOfWork _UnitOfWork { get; set; }

        internal DbContext _context { get; set; }
        internal DbSet<TEntity> dbSet { get; set; }

        public GenericRepository(IUnitOfWork unitofwork)
        {
            _UnitOfWork = unitofwork;

            _context = unitofwork.Context;
            dbSet = _context.Set<TEntity>();
        }




        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
                                        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            // 取得所有資料
            IQueryable<TEntity> query = dbSet;

            // 如果有Where條件篩選
            if (filter != null)
                query = query.Where(filter);

            // 如果有排序
            if (orderBy != null)
                return orderBy(query);
            else
                return query;

        }

        /// <summary>取得某筆資料</summary>
        /// <param name="id">PRIMARY KEY </param>
        /// <returns></returns>
        public TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        /// <summary>新增一筆資料</summary>
        /// <param name="entity"></param>
        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
            _context.SaveChanges();
        }

        /// <summary>修改資料</summary>
        /// <param name="entity"></param>
        public void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        /// <summary>刪除某筆資料 by ID</summary>
        /// <param name="id">PRIMARY KEY </param>
        public void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
            _context.SaveChanges();
        }

        /// <summary>刪除某筆資料 by Entity</summary>
        /// <param name="entity"></param>
        public void Delete(TEntity entity)
        {
            //假如Entity處於Detached狀態，就先Attach起來，這樣才能順利移除
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
            _context.SaveChanges();
        }





        #region 釋放Repository方法 (已改實作在UnitOfWork)
        //public void Dispose()
        //{
        //    this.Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        if (this._context != null)
        //        {
        //            this._context.Dispose();
        //            this._context = null;
        //        }
        //    }
        //}

        #endregion


    }
}