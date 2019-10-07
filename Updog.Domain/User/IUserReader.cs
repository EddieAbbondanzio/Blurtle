using System.Threading.Tasks;

namespace Updog.Domain {
    public interface IUserReader : IReader<UserReadView> {
        #region Publics
        Task<UserReadView?> FindById(int id);
        Task<UserReadView?> FindByUsername(string username);
        Task<UserReadView?> FindByPost(int postId);
        Task<UserReadView?> FindByComment(int commentId);
        #endregion
    }
}