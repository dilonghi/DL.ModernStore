using DL.ModernStore.Domain.ValueObjects;
using DL.ModernStores.Shared.Entities;
using System;

namespace DL.ModernStore.Domain.Entities
{
    public class Customer : Entity
    {
        protected Customer() { }

        public Customer(Name name, Document document, Email email, User user)
        {
            Name = name;
            Document = document;
            Email = email;
            BirthDate = null;
            User = user;

            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public DateTime? BirthDate { get; private set; }     
        public User User { get; set; }


        public void Update(Name name, DateTime birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }

    }
}
