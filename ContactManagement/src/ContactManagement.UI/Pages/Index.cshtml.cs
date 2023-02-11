using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContactManagement.Domain.Entities;
using ContactManagement.Domain.Interface.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagement.UI.Pages
{
	public class IndexModel : PageModel
	{
		public IEnumerable<ContactUser> ContactUsers { get; set; }

		private readonly IContactUserRepository _contactUserRepository;

		public IndexModel(IContactUserRepository contactUserRepository)
		{
			_contactUserRepository = contactUserRepository;
		}

		public void OnGet()
		{
			ContactUsers = _contactUserRepository.GetAll();
		}

		public void OnPostDelete(int id)
		{
			_contactUserRepository.Delete(id);
			OnGet();
		}
	}
}
