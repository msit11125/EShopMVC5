using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get;}


        /// <summary>
        /// 儲存所有異動。
        /// </summary>
        int SaveChanges();

    }
}
