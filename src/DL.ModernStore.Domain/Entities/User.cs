using System;

namespace DL.ModernStore.Domain.Entities
{
    public class User
    {
        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public Guid Id { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public bool Active { get; private set; }


        public void Activate() => Active = true;
        public void Deactivate() => Active = false;


    }
}
