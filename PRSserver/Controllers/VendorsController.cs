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
    public class VendorsController : ApiController
    {
        private PRSserverContext db = new PRSserverContext();

		// LIST
		[HttpGet]
		[ActionName("List")]
		public JsonResponse List() {
			return new JsonResponse {
				Data = db.Vendors.ToList()
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
				Data = db.Vendors.Find(id)
			};
		}

		// CREATE
		[HttpPost]
		[ActionName("Create")]
		public JsonResponse Create(Vendor vendor) {
			if (vendor == null)
				return new JsonResponse {
					Result = "Failed",
					Message = "Create requires an instance of Vendor"
				};
			if (!ModelState.IsValid)
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			db.Vendors.Add(vendor);
			db.SaveChanges();
			return new JsonResponse {
				Message = "Create successful.",
				Data = vendor
			};
		}

		// CHANGE
		[HttpPost]
		[ActionName("Change")]
		public JsonResponse Change(Vendor vendor) {
			if (vendor == null)
				return new JsonResponse {
					Result = "Failed",
					Message = "Change requires an instance of Vendor"
				};
			if (!ModelState.IsValid)
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			db.Entry(vendor).State = System.Data.Entity.EntityState.Modified;
			db.SaveChanges();
			return new JsonResponse {
				Message = "Change successful.",
				Data = vendor
			};
		}

		// REMOVE
		[HttpPost]
		[ActionName("Remove")]
		public JsonResponse Remove(Vendor vendor) {
			if (vendor == null)
				return new JsonResponse {
					Result = "Failed",
					Message = "Remove requires an instance of Vendor"
				};
			if (!ModelState.IsValid)
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			db.Entry(vendor).State = System.Data.Entity.EntityState.Deleted;
			db.SaveChanges();
			return new JsonResponse {
				Message = "Remove successful.",
				Data = vendor
			};
		}

		// REMOVE
		[HttpGet]
		[ActionName("RemoveId")]
		public JsonResponse Remove(int? id) {
			if (id == null)
				return new JsonResponse {
					Result = "Failed",
					Message = "RemoveId requires a Vendor.Id"
				};
			var vendor = db.Vendors.Find(id);
			if (vendor == null)
				return new JsonResponse {
					Result = "Failed",
					Message = $"No vendor has Id of {id}"
				};
			db.Vendors.Remove(vendor);
			db.SaveChanges();
			return new JsonResponse {
				Message = "Remove successful.",
				Data = vendor
			};
		}

	}
}