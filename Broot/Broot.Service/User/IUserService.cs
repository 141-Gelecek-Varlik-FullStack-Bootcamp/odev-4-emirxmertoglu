using Broot.Model;

namespace Broot.Service.User
{
    public interface IUserService
    {
        // Adding UserService methods to reach in UserController

        // Insert user.
        public General<Broot.Model.UserModel.UserCreateModel> Insert(Broot.Model.UserModel.UserCreateModel newUser);

        // Login user.
        //public General<Broot.Model.UserModel.UserLoginModel> Login(Broot.Model.UserModel.UserLoginModel loginUser);
        public General<Broot.Model.UserModel.UserLoginModel> Login(Broot.Model.LoginModel.Login loginUser);

        // Update user.
        public General<Broot.Model.UserModel.UserUpdateModel> Update(Broot.Model.UserModel.UserUpdateModel updatedUser, int id, int updater);

        // Delete user.
        public General<Broot.Model.UserModel.UserDeleteModel> Delete(int id, int updater);

        // Get users.
        public General<Broot.Model.UserModel.UserGetModel> Get();

    }
}
