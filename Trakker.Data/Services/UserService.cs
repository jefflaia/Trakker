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


        #endregion

        #region Roles

        #endregion

    }
}
