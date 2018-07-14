using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRSserver.Models {
	public class Vendor {
		public int Id { get; set; }

		[Required]
		[StringLength(4, MinimumLength =4, ErrorMessage ="Codes must be 4 characters long.")]
		public string Code { get; set; }

		[Required]
		[StringLength(20)]
		public string Name { get; set; }

		[Required]
		[StringLength(30)]
		public string Address { get; set; }

		[Required]
		[StringLength(30)]
		public string City { get; set; }

		[Required]
		[StringLength(2)]
		public string State { get; set; }

		[Required]
		public string Zip { get; set; }

		[Required]
		[StringLength(12, MinimumLength = 10, ErrorMessage = "The area code is required.")]
		public string Phone { get; set; }

		[Required]
		[StringLength(80)]
		public string Email { get; set; }

		public bool Preapproved { get; set; }
		public bool Active { get; set; }

		public Vendor() {}
	}
}