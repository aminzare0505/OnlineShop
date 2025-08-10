using MediatR;
using OnlineShop.Application.Feature.CategoryType.Request.Notifications;
using OnlineShop.Domain.IRepositories;
using OnlineShop.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Feature.CategoryType.Handler.Notifications
{
    public class EmailHandler : INotificationHandler<CategoryAddedNotification>
    {
        private readonly ICategoryRepository _categoryRepository;

        public EmailHandler(ICategoryRepository categoryRepository) => _categoryRepository = categoryRepository;

        public async Task Handle(CategoryAddedNotification notification, CancellationToken cancellationToken)
        {
            await _categoryRepository.EventOccured(notification.Category, "Email sent");
            await Task.CompletedTask;
        }
    }
}
