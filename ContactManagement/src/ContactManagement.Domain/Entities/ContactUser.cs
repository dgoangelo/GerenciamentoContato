using ContactManagement.Domain.Entities.Enum;
using ContactManagement.Domain.Validator;
using FluentValidation.Results;

namespace ContactManagement.Domain.Entities
{
    public class ContactUser : BaseEntity
    {
        public int Id { get; set; }
        public string Contact { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public override ValidationResult Validate(Action action)
        {
            return new ContactUserValidator(action).Validate(this);
        }
    }
}