using FluentValidator;

namespace DL.ModernStore.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        protected Email() { }

        public Email(string address)
        {
            Address = address;

            new ValidationContract<Email>(this)
                .IsRequired(x => x.Address, "Email é obrigatório")
                .IsEmail(x => x.Address, "Email está inválido");
        }

        public string Address { get; private set; }
    }
}
