using EShop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.DAL.Repository
{
    public class DbContextFactory : IDbContextFactory
    {

        private readonly string _ConnectionString;

        public DbContextFactory(string connectionString)
        {
            this._ConnectionString = connectionString;
        }

        private DbContext _dbContext;

        private DbContext DbContext
        {
            get
            {
                if (this._dbContext == null)
                {
                    Type t = typeof(DbContext);
                    this._dbContext =
                        (DbContext)Activator.CreateInstance(t, this._ConnectionString);
                }
                return _dbContext;
            }
        }

        public DbContext GetDbContext()
        {
            return this.DbContext;
        }
    }
}
