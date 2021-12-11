using AutoMapper;
using Broot.DB.Entities.DataContext;
using Broot.Model;
using Broot.Model.UserModel;
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
            var result = new General<Model.UserModel.UserCreateModel>() { IsSuccess=false};
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
                    result.TotalCount++;
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
        public General<UserLoginModel> Login(UserLoginModel loginUser)
        {
            var result = new General<Model.UserModel.UserLoginModel>() { IsSuccess = false };
            var model = mapper.Map<Broot.DB.Entities.User>(loginUser);
            using (var srv = new BrootContext())
            {
                result.Entity = loginUser;
                if (srv.User.Any(u => !u.IsDeleted && u.IsActive && u.UserName == loginUser.UserName && u.Password == loginUser.Password))
                {
                    result.IsSuccess = true;
                }
                else
                {
                    result.ExceptionMessage = "Giris basarisiz, kullanici adini ya da sifreyi kontrol edin!";
                    result.TotalCount++;
                }
            }
            return result;
        }   
    }
}
