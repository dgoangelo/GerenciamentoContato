using ContactManagement.Domain.Entities;
using ContactManagement.Domain.Entities.Enum;
using ContactManagement.Domain.Interface.Repository;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContactManagement.UI.Pages
{
    public class CreateContactUserModel : PageModel
    {
	    [BindProperty]
	    public ContactUser ContactUser { get; set; }

		private readonly IContactUserRepository _contactUserRepository;

		public CreateContactUserModel(IContactUserRepository contactUserRepository)
		{
			_contactUserRepository = contactUserRepository;
		}

		public void OnGet()
        {

        }

		public void OnPost()
		{
			var result = ContactUser.Validate(Action.Create);

			var existEmail = _contactUserRepository.Exist(c => c.Email == ContactUser.Email);
			if (existEmail)
			{
				result.Errors.Add(new ValidationFailure("Email", "Existe email no banco de dados"));
			}
			
			if (!result.IsValid)
			{
				foreach (var validationFailure in result.Errors)
				{
					ModelState.AddModelError("ContactUser." + validationFailure.PropertyName, validationFailure.ErrorMessage);
				}
			}
			else
			{
				_contactUserRepository.Add(ContactUser);
				Response.Redirect("Index");
			}
		}
    }
}
