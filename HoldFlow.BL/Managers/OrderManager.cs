
using HoldFlow.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace HoldFlow.BL.Managers
{
    public class OrderManager : Manager<Order>, IOrderManager
    {
        private readonly IOrderRepository _repository;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public OrderManager(UserManager<User> userManager, SignInManager<User> signInManager, IOrderRepository repository) : base(repository)
        {
            _repository = repository;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<GetOrderDto> GetOrderById(int id)
        {
            var entity = await _repository.FirstOrDefaultAsync(x=>x.Id==id,o=>o.User);
            if (entity == null)
                return null;
            var orderDto = new GetOrderDto
            {
                OrderId = id,
                Date = entity.Date,
                Status = entity.Status,
                TotalPrice = entity.TotalPrice,
                UserId = entity.UserId,
                Username = entity.User.UserName,
                Items = entity.Items.Select(x => new OrderItemDto
                {
                    Id = x.Id,
                    PackageId = x.PackageId,
                    Quantity = x.Quantity,
                    Price = x.Price,
                }).ToList()
            };
            return orderDto;

        }

        public async Task<IEnumerable<GetOrderDto>> GetOrders()
        {
            var entities = await _repository.GetAllAsync(null,x=>x.User);
            var orderDtos = entities.Select(e => new GetOrderDto
            {
                OrderId= e.Id,
                Date= e.Date,
                Status = e.Status,
                TotalPrice = e.TotalPrice,
                UserId=e.UserId,
                Username = e.User.UserName,
                Items = e.Items.Select(x => new OrderItemDto
                {
                    Id = x.Id,
                    PackageId = x.PackageId,
                    Quantity = x.Quantity,
                    Price = x.Price,
                }).ToList()
            });

            return orderDtos;
        }


        public async Task<StatusOrderDto> ConfirmOrder(int orderId)
        {
            try
            {
                var order = await _repository.FirstOrDefaultAsync(x => x.Id == orderId);

                if (order == null)
                {
                    return new StatusOrderDto { Message = "Order not found" };
                }

                order.Status = Status.Success;
                return new StatusOrderDto { Message = "Order confirmed successfully" };
            }
            catch (Exception)
            {
                return new StatusOrderDto { Message = "An error occurred while confirming the order." };
            }
        }

        

        public async Task<StatusOrderDto> DenyOrder(int orderId)
        {
            try
            {
                var order = await _repository.FirstOrDefaultAsync(x => x.Id == orderId);

                if (order == null)
                {
                    return new StatusOrderDto { Message = "Order not found" };
                }

                order.Status = Status.Deny;
                return new StatusOrderDto { Message = "Order Denied " };
            }
            catch (Exception)
            {
                return new StatusOrderDto { Message = "An error occurred while Denying the order." };
            }
        }


    }
}