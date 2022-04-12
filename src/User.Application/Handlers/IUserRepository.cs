using System.Threading.Tasks;

namespace User.Application.Handlers
{
    public interface IUserRepository
    {
        Task AddAsync(object userEntitiy);
    }
}