using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using backend.Utility.Database;

namespace backend.Helpers
{
    public class UserHelper
    {
        public virtual async Task<UserModel> GetUserDetails(int userId)
        {
            return new UserModel();
        }
    }
}