using DL.ModernStore.Domain.Commands;
using DL.ModernStore.Domain.Entities;
using DL.ModernStore.Domain.Repositories;
using DL.ModernStores.Shared.Commands;
using FluentValidator;

namespace DL.ModernStore.Domain.CommandHansdlers
{
    public class OrderCommandHandler : Notifiable, 
        ICommandHandler<RegisterOrderCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderCommandHandler(ICustomerRepository customerRepository,
            IProductRepository productRepository,
            IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }


        public void Handle(RegisterOrderCommand command)
        {
            // Instancia o cliente (Lendo do repositorio)
            var customer = _customerRepository.Get(command.Customer);

            // Gera um novo pedido
            var order = new Order(customer, command.DeliveryFee, command.Discount);
      
            // Adicionar itens no Pedido
            foreach (var item in command.Items)
            {
                var product = _productRepository.Get(item.Product);
                order.AddItem(new OrderItem(product, item.Quantity));                
            }

            // Adicionar as notificacoes  do pedido no Handler
            AddNotifications(order.Notifications);

            // Persiste no banco
            if (order.IsValid())
                _orderRepository.Save(order);
        }

    }
}
