using Broot.Model;

namespace Broot.Service.User
{
    public interface IUserService
    {
        // Adding UserService methods to reach in UserController
        public General<Broot.Model.UserModel.User> Insert(Broot.Model.UserModel.User newUser);
    }
}
