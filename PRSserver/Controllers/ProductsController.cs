﻿using System;
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
	public class ProductsController : ApiController {
		private PRSserverContext db = new PRSserverContext();
		// LIST
		[HttpGet]
		[ActionName("List")]
		public JsonResponse List() {
			return new JsonResponse {
				Data = db.Products.ToList()
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
				Data = db.Products.Find(id)
			};
		}

		// CREATE
		[HttpPost]
		[ActionName("Create")]
		public JsonResponse Create(Product product) {
			if (product == null)
				return new JsonResponse {
					Result = "Failed",
					Message = "Create requires an instance of Product"
				};
			if (!ModelState.IsValid)
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			db.Products.Add(product);
			db.SaveChanges();
			return new JsonResponse {
				Message = "Create successful.",
				Data = product
			};
		}

		// CHANGE
		[HttpPost]
		[ActionName("Change")]
		public JsonResponse Change(Product product) {
			if (product == null)
				return new JsonResponse {
					Result = "Failed",
					Message = "Change requires an instance of Product"
				};
			if (!ModelState.IsValid)
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			db.Entry(product).State = System.Data.Entity.EntityState.Modified;
			db.SaveChanges();
			return new JsonResponse {
				Message = "Change successful.",
				Data = product
			};
		}

		// REMOVE

		[HttpPost]
		[ActionName("Remove")]
		public JsonResponse Remove(Product product) {
			if (product == null)
				return new JsonResponse {
					Result = "Failed",
					Message = "Remove requires an instance of Product"
				};
			if (!ModelState.IsValid)
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			db.Entry(product).State = System.Data.Entity.EntityState.Deleted;
			db.SaveChanges();
			return new JsonResponse {
				Message = "Remove successful.",
				Data = product
			};
		}

		// REMOVE
		[HttpGet]
		[ActionName("RemoveId")]
		public JsonResponse Remove(int? id) {
			if (id == null)
				return new JsonResponse {
					Result = "Failed",
					Message = "RemoveId requires a Product.Id"
				};
			var product = db.Products.Find(id);
			if (product == null)
				return new JsonResponse {
					Result = "Failed",
					Message = $"No product has Id of {id}"
				};
			db.Products.Remove(product);
			db.SaveChanges();
			return new JsonResponse {
				Message = "Remove successful.",
				Data = product
			};



		}
	}
}