using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PRSserver.Models {
	public class User {
		public int Id { get; set; }

		
		[StringLength(30)]
		[Index("IDX_Username", IsUnique = true)]
		public string Username { get; set; }

	
		[StringLength(30, MinimumLength = 8, ErrorMessage ="Passwords must be at least 8 characters long, and have no more than 30 characters.")]
		public string Password { get; set; }

		[Required]
		[StringLength(30)]
		public string FirstName { get; set; }

		[Required]
		[StringLength(30)]
		public string LastName { get; set; }

		[Required]
		[StringLength(12, MinimumLength = 10, ErrorMessage ="The area code is required.")]
		public string Phone { get; set; }

		[Required]
		[StringLength(80)]
		public string Email { get; set; }

		public bool Reviewer { get; set; }
		public bool Admin { get; set; }
		public bool Active { get; set; }

		public User() { }
	}
}