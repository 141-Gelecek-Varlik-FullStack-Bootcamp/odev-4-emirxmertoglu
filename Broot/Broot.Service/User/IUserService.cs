using Broot.Model;

namespace Broot.Service.User
{
    public interface IUserService
    {
        // Adding UserService methods to reach in UserController
        public General<Broot.Model.UserModel.UserCreateModel> Insert(Broot.Model.UserModel.UserCreateModel newUser);
        public General<Broot.Model.UserModel.UserLoginModel> Login(Broot.Model.UserModel.UserLoginModel loginUser);
    }
}
