using NECTicket.TicketManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NECTicket.TicketManagement.Application.Contracts.Persistence
{
    public interface IOrderRepository:IAsyncRepository<Order>
    {
    }
}
