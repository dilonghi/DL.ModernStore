using DL.ModernStore.Domain.Commands.Inputs;
using DL.ModernStore.Domain.Commands.Results;
using DL.ModernStore.Domain.Entities;
using DL.ModernStore.Domain.Repositories;
using DL.ModernStore.Domain.Services;
using DL.ModernStore.Domain.ValueObjects;
using DL.ModernStores.Shared.Commands;
using FluentValidator;

namespace DL.ModernStore.Domain.Commands.Handlers
{
    public class CustomerCommandHandler : Notifiable,
        ICommandHandler<RegisterCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailService _emailService;

        public CustomerCommandHandler(ICustomerRepository customerRepository, IEmailService emailService)
        {
            _customerRepository = customerRepository;
            _emailService = emailService;
        }

        
        public ICommandResult Handle(RegisterCustomerCommand command)
        {
            // Passo 1. Verifica se cliente existe
            if (_customerRepository.DocumentExists(command.Document))
            {
                AddNotification("Customer", "Cliente não encontrado");
                return null;
            }

            // Passo 2. Gerar o novo clienet
            var name = new Name(command.FirstName, command.LastName);
            var email = new Email(command.Email);
            var document = new Document(command.Document);
            var user = new User(command.Username, command.Password, command.ConfirmPassword);
            var customer = new Customer(name, document, email, user);

            AddNotifications(name.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(user.Notifications);
            AddNotifications(customer.Notifications);

            // Passo 3. Persistir no banco
            if (IsValid())
                _customerRepository.Save(customer);

            // Passo 4. Enviar email de boas vindas
            _emailService.Send(customer.Name.ToString(), 
                customer.Email.Address, 
                "Bem vindo", 
                "");

            // Passo 6. Retornar algo
            return new RegisterCustomerCommandResult(customer.Id, customer.Name.ToString());
        }
    }
}
