using EShop.BLL.Interfaces;
using EShop.DAL.Interfaces;
using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.BLL.Service.Service
{
    public class EmployeeService: IEmployeeService
    {
        IRepository<Account> _account;
        public EmployeeService(IRepository<Account> account)
        {
            _account = account;
        }
        public bool Login(string username,string password)
        {
            var loginState = _account.Get().Any(user => user.UserName.Equals(username
                , StringComparison.OrdinalIgnoreCase) && user.Password == password);
            return loginState;
        }
    }
}
