using NETCore1.Context;
using NETCore1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore1.Repository.Data
{
    public class RoleAccountRepository : GeneralRepository<MyContext, RoleAccount, int>
    {
        public RoleAccountRepository(MyContext myContext) : base(myContext)
        {
        }
    }
}
