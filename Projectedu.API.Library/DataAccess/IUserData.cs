using Projectedu.API.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projectedu.API.Library.DataAccess
{
    public interface IUserData
    {
        List<UserModel> GetUserByNamePass(string userName, string password);
        UserModel GetById(int id);
    }
}
