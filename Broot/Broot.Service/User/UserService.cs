using AutoMapper;
using Broot.DB.Entities.DataContext;
using Broot.Model;
using Broot.Model.UserModel;
using System.Collections.Generic;
using System.Linq;

namespace Broot.Service.User
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        
        public UserService(IMapper _mapper)
        {
            mapper = _mapper;
        }

        // Inserting a new user
        public General<Model.UserModel.UserCreateModel> Insert(Broot.Model.UserModel.UserCreateModel newUser)
        {
            var result = new General<Model.UserModel.UserCreateModel>() { IsSuccess = false };
            var model = mapper.Map<Broot.DB.Entities.User>(newUser);
            using (var srv = new BrootContext())
            {
                // We could use try catch blocks but it will increase our memory usage.
                // Also we trying to insert to just one table it's not necessary to use try catch blocks
                // because we could handle errors easily.

                // And one more thing is we could use transaction but it becomes costly too. 

                // Checking the user email exists in db
                if (srv.User.Any(u => u.Email == newUser.Email && u.IsActive))
                {
                    result.ExceptionMessage = "Bu mail adresiyle kayitli bir kullanici var.";
                }
                else
                {
                    model.Idatetime = System.DateTime.Now;
                    model.IsActive = true;
                    srv.User.Add(model);
                    srv.SaveChanges();
                    result.Entity = mapper.Map<Broot.Model.UserModel.UserCreateModel>(model);
                    result.IsSuccess = true;
                }
            }
            return result;
        }



        // Login user.
        //public General<UserLoginModel> Login(UserLoginModel loginUser)
        //{
        //    var result = new General<Model.UserModel.UserLoginModel>() { IsSuccess = false };
        //    using (var srv = new BrootContext())
        //    {
        //        result.Entity = loginUser;
        //        if (srv.User.Any(u => !u.IsDeleted && u.IsActive && u.UserName == loginUser.UserName && u.Password == loginUser.Password))
        //        {
        //            result.IsSuccess = true;
        //        }
        //        else
        //        {
        //            result.ExceptionMessage = "Giris basarisiz, kullanici adini ya da sifreyi kontrol edin!";
        //        }
        //    }
        //    return result;
        //}

        public General<Broot.Model.UserModel.UserLoginModel> Login(Broot.Model.LoginModel.Login loginUser)
        {
            General<Broot.Model.UserModel.UserLoginModel> result = new();
            using (var srv = new BrootContext())
            {
                var _data = srv.User.FirstOrDefault(u => !u.IsDeleted && u.IsActive
                && u.UserName == loginUser.UserName && u.Password == loginUser.Password);
                if (_data is not null)
                {
                    result.IsSuccess = true;
                    result.Entity = mapper.Map<Broot.Model.UserModel.UserLoginModel>(_data);
                }
            }

            return result;
        }


        // Update user.
        //public General<UserUpdateModel> Update(UserUpdateModel updatedUser, int id, int updater)
        //{
        //    var result = new General<Model.UserModel.UserUpdateModel>() { IsSuccess = false };
        //    using (var srv = new BrootContext())
        //    {
        //        var user = srv.User.SingleOrDefault(u => u.Id == id);
        //        // Checking user exists
        //        if (user is null)
        //        {
        //            result.ExceptionMessage = "Verilen id numarasiyla iliskili bir kullanici bulunamadi.";
        //            return result;
        //        }

        //        // Updating user values
        //        user.Name = updatedUser.Name != default ? updatedUser.Name : user.Name;
        //        user.UserName = updatedUser.UserName != default ? updatedUser.UserName : user.UserName;
        //        user.Email = updatedUser.Email != default ? updatedUser.Email : user.Email;
        //        user.Password = updatedUser.Password != default ? updatedUser.Password : user.Password;
        //        user.Uuser = updater;
        //        user.Udatetime = System.DateTime.Now;

        //        // Saving user with new values to db
        //        srv.SaveChanges();

        //        // Updating result
        //        result.Entity = mapper.Map<UserUpdateModel>(user);
        //        result.IsSuccess = true;
        //    }
        //    return result;
        //}

        // Delete user.
        //public General<UserDeleteModel> Delete(int id, int updater)
        //{
        //    var result = new General<Model.UserModel.UserDeleteModel>() { IsSuccess = false };
        //    using (var srv = new BrootContext())
        //    {
        //        var user = srv.User.SingleOrDefault(u => u.Id == id);

        //        // Checking if user exists
        //        if (user is null)
        //        {
        //            result.ExceptionMessage = "Bu id ile bir kullanici bulunamadi!";
        //            return result;
        //        }

        //        if (user.IsDeleted)
        //        {
        //            result.ExceptionMessage = "Bu kullanici zaten silinmis!";
        //            return result;
        //        }

        //        // Deactivating user account
        //        user.IsDeleted = true;
        //        user.IsActive = false;
        //        user.Udatetime = System.DateTime.Now;
        //        user.Uuser = updater;

        //        // Saving user with new values to db
        //        srv.SaveChanges();

        //        // Updating result values
        //        result.Entity = mapper.Map<UserDeleteModel>(user);
        //        result.IsSuccess = true;
        //    }
        //    return result;
        //}

        // Get users.
        //public General<UserGetModel> Get()
        //{
        //    var result = new General<Model.UserModel.UserGetModel>() { IsSuccess = false };
        //    using (var srv = new BrootContext())
        //    {
        //        var users = srv.User.Where(u => u.IsActive && !u.IsDeleted).OrderBy(u => u.Id);

        //        if (users is null)
        //        {
        //            result.ExceptionMessage = "Kullanici verileri cekilemedi!";
        //            return result;
        //        }

        //        // Mapping users
        //        result.List = mapper.Map<List<UserGetModel>>(users);
        //        result.TotalCount = users.Count();
        //        result.IsSuccess = true;
        //    }

        //    return result;
        //}
    }
}
