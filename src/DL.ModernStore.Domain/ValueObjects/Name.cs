using FluentValidator;

namespace DL.ModernStore.Domain.ValueObjects
{
    public class Name : Notifiable
    {
        protected Name() { }

        public Name(string firtName, string lastName)
        {
            FirtName = firtName;
            LastName = lastName;

            new ValidationContract<Name>(this)
                .IsRequired(x => x.FirtName, "Nome é obrigatório")
                .HasMaxLenght(x => x.FirtName, 60, "Máximo de {1} caracteres")
                .HasMinLenght(x => x.FirtName, 3, "Mínimo de {1} caracteres")
                .IsRequired(x => x.LastName, "Nome é obrigatório")
                .HasMaxLenght(x => x.LastName, 60, "Máximo de {1} caracteres")
                .HasMinLenght(x => x.LastName, 3, "Mínimo de {1} caracteres");
        }

        public string FirtName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{ FirtName } { LastName }";
        }
    }
}
