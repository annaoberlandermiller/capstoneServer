using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRSserver.Models {
	public class PurchaseRequestLineItem {
		public int Id { get; set; }

		public int PurchaseRequestId { get; set; }

		public int ProductId { get; set; }

		public int Quantity { get; set; }

		[JsonIgnore] 
		public virtual Product Product { get; set; }

		public virtual PurchaseRequest PurchaseRequest { get; set; }

		public PurchaseRequestLineItem () { }
	}
}