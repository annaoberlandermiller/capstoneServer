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
    public class PurchaseRequestsController : ApiController
    {
        private PRSserverContext db = new PRSserverContext();

		// LIST
		[HttpGet]
		[ActionName("List")]
		public JsonResponse List() {
			return new JsonResponse {
				Data = db.PurchaseRequests.ToList()
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
				Data = db.PurchaseRequests.Find(id)
			};
		}

		// CREATE
		[HttpPost]
		[ActionName("Create")]
		public JsonResponse Create(PurchaseRequest purchaseRequest) {
			if (purchaseRequest == null)
				return new JsonResponse {
					Result = "Failed",
					Message = "Create requires an instance of PurchaseRequest"
				};
			if (!ModelState.IsValid)
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			db.PurchaseRequests.Add(purchaseRequest);
			db.SaveChanges();
			return new JsonResponse {
				Message = "Create successful.",
				Data = purchaseRequest
			};
		}

		// CHANGE
		[HttpPost]
		[ActionName("Change")]
		public JsonResponse Change(PurchaseRequest purchaseRequest) {
			if (purchaseRequest == null)
				return new JsonResponse {
					Result = "Failed",
					Message = "Change requires an instance of PurchaseRequest"
				};
			if (!ModelState.IsValid)
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			db.Entry(purchaseRequest).State = System.Data.Entity.EntityState.Modified;
			db.SaveChanges();
			return new JsonResponse {
				Message = "Change successful.",
				Data = purchaseRequest
			};
		}

		// REMOVE
		[HttpPost]
		[ActionName("Remove")]
		public JsonResponse Remove(PurchaseRequest purchaseRequest) {
			if (purchaseRequest == null)
				return new JsonResponse {
					Result = "Failed",
					Message = "Remove requires an instance of PurchaseRequest"
				};
			if (!ModelState.IsValid)
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			db.Entry(purchaseRequest).State = System.Data.Entity.EntityState.Deleted;
			db.SaveChanges();
			return new JsonResponse {
				Message = "Remove successful.",
				Data = purchaseRequest
			};
		}

		// REMOVE
		[HttpGet]
		[ActionName("RemoveId")]
		public JsonResponse Remove(int? id) {
			if (id == null)
				return new JsonResponse {
					Result = "Failed",
					Message = "RemoveId requires a PurchaseRequest.Id"
				};
			var purchaseRequest = db.PurchaseRequests.Find(id);
			if (purchaseRequest == null)
				return new JsonResponse {
					Result = "Failed",
					Message = $"No purchaseRequest has Id of {id}"
				};
			db.PurchaseRequests.Remove(purchaseRequest);
			db.SaveChanges();
			return new JsonResponse {
				Message = "Remove successful.",
				Data = purchaseRequest
			};
		}
	}
}