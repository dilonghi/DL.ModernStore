using DL.ModernStores.Shared.Commands;
using System;

namespace DL.ModernStore.Domain.Commands.Results
{
    public class RegisterCustomerCommandResult : ICommandResult
    {
        public RegisterCustomerCommandResult()
        {
        }

        public RegisterCustomerCommandResult(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
