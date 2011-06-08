namespace Trakker.Data.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Trakker.Data.Repositories;
    using System.Security.Cryptography;

    public class UserService : IUserService
    {
        protected IUserRepository _userRepository;
        protected ITicketRepository _ticketRepository;

        public UserService(IUserRepository userRepository, ITicketRepository ticketRepository)
        {
            _userRepository = userRepository;
            _ticketRepository = ticketRepository;
        }

        #region User
        public User GetUserById(int id)
        {
            return _userRepository.GetUsers().Where(x => x.Id == id).SingleOrDefault<User>() ?? null;
        }

        public User GetUserByEmail(string email)
        {
            return _userRepository.GetUsers().Where(x => x.Email == email).SingleOrDefault<User>() ?? null;
        }

        public IList<User> GetAllUsers()
        {
            return _userRepository.GetUsers().ToList<User>();
        }

        public Paginated<User> GetAllUsersPaginated(int page, int pageSize)
        {
            return _userRepository.GetUsers().AsPaginated<User>(page, pageSize);
        }

        public void Save(User user)
        {
            if (user.Id == 0)
            {
                user.Created = DateTime.Now;
                user.Salt = Auth.SaltGenerator();
                user.Password = Auth.HashPassword(user.Password, user.Salt);
            }

            _userRepository.Save(user);
        }
        #endregion

       #region Roles
       public IList<Role> GetAllRoles()
       {
           return _userRepository.GetRoles().ToList<Role>();
       }

       public void Save(Role role)
       {
           _userRepository.Save(role);
       }
       #endregion

    }
}
