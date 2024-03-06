namespace Rayson.BusinessInterface
{
    /// <summary>
    /// 每个service各自的接口，支持内部个性化实现
    /// </summary>
    public interface IUserService: IBaseService
    {
        public void DeleteUser();
    }
}
