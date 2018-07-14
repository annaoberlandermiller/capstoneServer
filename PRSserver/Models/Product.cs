using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PRSserver.Models {
	public class Product {
		public int Id { get; set; }
		public int VendorId { get; set; }

		[Required]
		[StringLength(30)]
		[Index("IDX_ProductCode", IsUnique = true)]
		public string PartNumber{ get; set; }

		[Required]
		[StringLength(30)]
		public string Name { get; set; }

		[Required]
		public decimal Price { get; set; }

		[Required]
		[StringLength(20)]
		public string Unit { get; set; }

		
		public string PhotoPath { get; set; }
		public bool Active { get; set; }

		public virtual Vendor Vendor { get; set; }

		public Product() { }
	}
}