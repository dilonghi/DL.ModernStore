using DL.ModernStores.Shared.Commands;
using System;

namespace DL.ModernStore.Domain.Commands.Inputs
{
    public class RegisterOrderItemCommand : ICommand
    {
        public Guid Product { get; set; }
        public int Quantity { get; set; }


    }
}
