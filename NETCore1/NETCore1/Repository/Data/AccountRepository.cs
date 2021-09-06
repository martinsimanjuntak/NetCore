using NETCore1.Context;
using NETCore1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore1.Repository.Data
{
    public class AccountRepository : GeneralRepository<MyContext, Account, string>
    {
        private readonly MyContext myContext;
        public AccountRepository (MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }


        public int Login(LoginModel loginVM)
        {
            var emailCheck = myContext.Persons.Where(x => x.Email.Equals(loginVM.Email));
            var passwordCheck = myContext.Accounts.Where(x => x.Password.Equals(loginVM.Password));


            if (emailCheck.Count() != 0)
            {
                if (passwordCheck.Count() != 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 2;
            }
            
           
        }
    }
}
