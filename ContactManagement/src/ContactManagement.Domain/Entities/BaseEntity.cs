using ContactManagement.Domain.Entities.Enum;
using FluentValidation.Results;

namespace ContactManagement.Domain.Entities
{
    public abstract class BaseEntity
    {
        public abstract ValidationResult Validate(Action action);
    }
}