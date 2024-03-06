using Rayson.BusinessInterface;
using SqlSugar;

namespace Rayson.BusinessService
{
    public class UserService : BaseService, IUserService
    {
        /// <summary>
        /// 支持构造函数注入
        /// </summary>
        /// <param name="client"></param>
        public UserService(ISqlSugarClient client) : base(client)
        {
        }

        public void DeleteUser()
        {
            throw new NotImplementedException();
        }
    }
}
