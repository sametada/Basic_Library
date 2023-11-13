using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebApplication_01.Models
{
	public class ApplicationUser : IdentityUser
	{

		[Required]
		public int Ogrencino { get; set; }

		public string? Adres { get; set; }
		public string? Fakulte { get; set; }
		public string? Bolum { get; set; }


	}
}
