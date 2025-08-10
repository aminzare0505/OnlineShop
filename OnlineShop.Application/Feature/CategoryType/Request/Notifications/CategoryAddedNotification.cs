using MediatR;
using OnlineShop.Application.Dto.Category;
using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Feature.CategoryType.Request.Notifications
{
    public record CategoryAddedNotification(Category Category) : INotification;
}
