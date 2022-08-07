using Microsoft.AspNetCore.Identity;
using myPosGift.Infrastructure.Data;
using myPosGift.Infrastructure.Data.DateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myPosGift.Core.Services
{
    public class BaseService
    {
        public BaseService(UserManager<User> userManager, ApplicationDbContext context)
        {
            this.Context = context;
            this.UserManager = userManager;
        }
        public ApplicationDbContext Context { get; set; }
        public UserManager<User> UserManager { get; set; }
    }
}
