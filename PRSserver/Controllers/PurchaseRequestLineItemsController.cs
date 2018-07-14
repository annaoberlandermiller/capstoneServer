using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PRSserver.Models;
using PRSserver.Scripts;

namespace PRSserver.Controllers
{
    public class PurchaseRequestLineItemsController : ApiController
    {
        private PRSserverContext db = new PRSserverContext();

		//CALCULATES LINE ITEM TOTAL
		private void RecalcLineItemTotal(int purchaseRequestId) {
			var pr = db.PurchaseRequests.Find(purchaseRequestId);
			if (pr == null) return;
			var lines = db.PurchaseRequestLineItems
				.Where(li => li.PurchaseRequestId == purchaseRequestId);
			pr.Total = lines.Sum(li => li.Quantity * li.Product.Price);
			db.SaveChanges();
		}

		// LIST
		[HttpGet]
		[ActionName("List")]
		public JsonResponse List() {
			return new JsonResponse {
				Data = db.PurchaseRequestLineItems.ToList()
			};
		}

		// GET
		[HttpGet]
		[ActionName("Get")]
		public JsonResponse Get(int? id) {
			if (id == null)
				return new JsonResponse {
					Result = "Failed",
					Message = "Get requires an Id"
				};
			return new JsonResponse {
				Data = db.PurchaseRequestLineItems.Find(id)
			};
		}

		// CREATE
		[HttpPost]
		[ActionName("Create")]
		public JsonResponse Create(PurchaseRequestLineItem purchaseRequestLineItem) {
			if (purchaseRequestLineItem == null)
				return new JsonResponse {
					Result = "Failed",
					Message = "Create requires an instance of PurchaseRequestLineItem"
				};
			if (!ModelState.IsValid)
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			db.PurchaseRequestLineItems.Add(purchaseRequestLineItem);
			db.SaveChanges();
			return new JsonResponse {
				Message = "Create successful.",
				Data = purchaseRequestLineItem
			};
		}

		// CHANGE
		[HttpPost]
		[ActionName("Change")]
		public JsonResponse Change(PurchaseRequestLineItem purchaseRequestLineItem) {
			if (purchaseRequestLineItem == null)
				return new JsonResponse {
					Result = "Failed",
					Message = "Change requires an instance of PurchaseRequestLineItem"
				};
			if (!ModelState.IsValid)
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			db.Entry(purchaseRequestLineItem).State = System.Data.Entity.EntityState.Modified;
			db.SaveChanges();
			return new JsonResponse {
				Message = "Change successful.",
				Data = purchaseRequestLineItem
			};
		}

		// REMOVE
		[HttpPost]
		[ActionName("Remove")]
		public JsonResponse Remove(PurchaseRequestLineItem purchaseRequestLineItem) {
			if (purchaseRequestLineItem == null)
				return new JsonResponse {
					Result = "Failed",
					Message = "Remove requires an instance of PurchaseRequestLineItem"
				};
			if (!ModelState.IsValid)
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			db.Entry(purchaseRequestLineItem).State = System.Data.Entity.EntityState.Deleted;
			db.SaveChanges();
			return new JsonResponse {
				Message = "Remove successful.",
				Data = purchaseRequestLineItem
			};
		}

		// REMOVE
		[HttpGet]
		[ActionName("RemoveId")]
		public JsonResponse Remove(int? id) {
			if (id == null)
				return new JsonResponse {
					Result = "Failed",
					Message = "RemoveId requires a PurchaseRequestLineItem.Id"
				};
			var purchaseRequestLineItem = db.PurchaseRequestLineItems.Find(id);
			if (purchaseRequestLineItem == null)
				return new JsonResponse {
					Result = "Failed",
					Message = $"No purchaseRequestLineItem has Id of {id}"
				};
			db.PurchaseRequestLineItems.Remove(purchaseRequestLineItem);
			db.SaveChanges();
			return new JsonResponse {
				Message = "Remove successful.",
				Data = purchaseRequestLineItem
			};
		}
	}
}