using FluentValidation;
using FluentValidation.Results;
using OK.Tech.Domain.Entities;
using OK.Tech.Domain.Notifications;
using OK.Tech.Domain.Repositories;
using System.Linq;

namespace OK.Tech.App
{
    public abstract class AppBase
    {
        private readonly INotifier _notifier;

        public AppBase(IUnitOfWork unitOfWork, INotifier notifier)
        {
            UnitOfWork = unitOfWork;
            _notifier = notifier;
        }

        protected IUnitOfWork UnitOfWork { get; }

        protected bool Validate<TValidator, TEntity>(TValidator validator, TEntity entity) where TValidator : AbstractValidator<TEntity> where TEntity : Entity
        {
            var validationResult = validator.Validate(entity);

            Notify(validationResult);

            return validationResult.IsValid;
        }

        protected void Notify(ValidationResult validationResult)
        {
            validationResult.Errors.ToList().ForEach((e) => { Notify(e.ErrorMessage); });
        }

        protected void Notify(string message)
        {
            _notifier.Handle(new Notification(message));
        }
    }
}