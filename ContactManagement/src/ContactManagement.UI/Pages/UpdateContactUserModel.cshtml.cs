using System.Security.Cryptography;
using ContactManagement.Domain.Entities;
using ContactManagement.Domain.Entities.Enum;
using ContactManagement.Domain.Interface.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContactManagement.UI.Pages
{
    public class UpdateContactUserModelModel : PageModel
    {
	    private readonly IContactUserRepository _contactUserRepository;

		[BindProperty]
		public ContactUser ContactUser { get; set; }

		public UpdateContactUserModelModel(IContactUserRepository contactUserRepository)
	    {
		    _contactUserRepository = contactUserRepository;
	    }

	    public void OnGet(int id)
	    {
		    ContactUser = _contactUserRepository.Get(id);
	    }

	    public void OnPost()
	    {
		    var result = ContactUser.Validate(Action.Update);

		    if (!result.IsValid)
		    {
			    foreach (var validationFailure in result.Errors)
			    {
				    ModelState.AddModelError("ContactUser." + validationFailure.PropertyName, validationFailure.ErrorMessage);
			    }
		    }
		    else
		    {
			    _contactUserRepository.Update(ContactUser);
			    Response.Redirect("/Index");
		    }
		}
    }
}
