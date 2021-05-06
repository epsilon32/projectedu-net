using Projectedu.API.Library.Helpers;
using Projectedu.API.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projectedu.API.Library.DataAccess
{
    public class UserData : IUserData
    {

        private ISqlDataAccess _dataAccess;

        public UserData(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public List<UserModel> GetUserByNamePass(string userName, string password)
        {
            var parameters = new { userName = userName, password = password };
            return _dataAccess.LoadData<UserModel, dynamic>("dbo.spUser_GetByUserPass", parameters);
        }

        public UserModel GetById(int id)
        {
            return _dataAccess.LoadData<UserModel, dynamic>("dbo.spUser_Lookup", new { Id = id }).FirstOrDefault();
        }


    }
}
