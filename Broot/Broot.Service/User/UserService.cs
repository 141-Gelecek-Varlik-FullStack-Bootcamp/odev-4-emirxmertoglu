using AutoMapper;
using Broot.DB.Entities.DataContext;
using Broot.Model;
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

        // Login user with username and password.
        public bool Login(string userName, string password)
        {
            bool result = false;
            using (var srv = new BrootContext())
            {
                // Checking is there any user with username and password parameters.
                // Also the user is not deleted and active.
                result = srv.User.Any(user => !user.IsDeleted && user.IsActive && user.UserName == userName && user.Password == password);
            }

            return result;
        }

        // Inserting a new user
        public General<Model.UserModel.User> Insert(Broot.Model.UserModel.User newUser)
        {
            var result = new General<Model.UserModel.User>() { IsSuccess=false};
            var model = mapper.Map<Broot.DB.Entities.User>(newUser);
            using (var srv = new BrootContext())
            {
                // We could use try catch blocks but it will increase our memory usage.
                // Also we trying to insert to just one table it's not necessary to use try catch blocks
                // because we could handle errors easily.

                // And one more thing is we could use transaction but it becomes costly too. 

                model.Idatetime = System.DateTime.Now;
                srv.User.Add(model);
                srv.SaveChanges();
                result.Entity = mapper.Map<Broot.Model.UserModel.User>(model);
                result.IsSuccess = true;
            }
            return result;
        }
    }
}
