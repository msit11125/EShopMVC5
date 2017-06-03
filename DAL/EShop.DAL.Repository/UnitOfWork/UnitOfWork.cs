using EShop.DAL.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.DAL.Repository
{
    /// <summary>
    /// UnitOfWork 用途: Transaction
    /// 從Controller注入IUnitOfWork
    /// Service功能皆完成時呼叫SaveChanges
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _context;
        private IDbContextFactory DbContextFactory;

        public DbContext Context
        {
            get
            {
                if (this._context != null)
                {
                    return this._context;
                }
                this._context = DbContextFactory.GetDbContext();
                return _context;
            }
        }
        #region 暫時無法使用 DbContextFactory
        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="factory"></param> 
        //public UnitOfWork(IDbContextFactory factory)
        //{
        //    this.DbContextFactory = factory;
        //}
        #endregion
        public UnitOfWork(DbContext context)
        {
            this._context = context;
        }
        public int SaveChanges()
        {
            return Context.SaveChanges();
        }



        #region Dispose 釋放物件方法
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.Context.Dispose();
                    this._context = null;
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
