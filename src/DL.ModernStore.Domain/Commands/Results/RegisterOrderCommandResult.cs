using DL.ModernStores.Shared.Commands;

namespace DL.ModernStore.Domain.Commands.Results
{
    public class RegisterOrderCommandResult : ICommandResult
    {
        public RegisterOrderCommandResult()
        {
        }

        public RegisterOrderCommandResult(string number)
        {

        }

        public string Number { get; set; }
    }
}
