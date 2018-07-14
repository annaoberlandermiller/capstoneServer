using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRSserver.Models {
	public class PurchaseRequest {
		public int Id { get; set; }
		public int UserId { get; set; }

		[Required]
		[StringLength(80)]
		public string RequestDescription { get; set; }

		[Required]
		[StringLength(255)]
		public string RequestJustification { get; set; } 
		public decimal Total { get; set; } = 0;

		[Required]
		[StringLength(15)]
		public string Status { get; set; }

		[Required]
		[StringLength(30)]
		public string DeliveryMode { get; set; }
		public bool Active { get; set; } = true;

		[StringLength(80)]
		public string ReasonForRejection { get; set; }

		public virtual List<PurchaseRequestLineItem> PurchaseRequestLineItems { get; set; } //this allows us to get all the line items for the request

		public virtual User User { get; set; }

		public PurchaseRequest() { }
	}
}