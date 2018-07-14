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
	public class UsersController : ApiController {
		private PRSserverContext db = new PRSserverContext();

		//USERNAME AND PASSWORD AUTHENTICATION
		[HttpGet]
		public JsonResponse Authenticate(string username, string password) {
			if (username == null || password == null)
				return new JsonResponse {Message = "Authentication failed - did you enter your username AND password?" };
			var user = db.Users.SingleOrDefault(u => u.Username == username && u.Password == password);
			if (user == null)
				return new JsonResponse { Message = "Authentication failed. Are you sure the username and password correct? Are you sure you have an acccount? " };
			return new JsonResponse { Data = user };
		}

		// LIST
		[HttpGet]
		[ActionName("List")]
		public JsonResponse List() {
			return new JsonResponse {
				Data = db.Users.ToList()
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
				Data = db.Users.Find(id)
			};
		}

		// CREATE
		[HttpPost]
		[ActionName("Create")]
		public JsonResponse Create(User user) {
			if (user == null)
				return new JsonResponse {
					Result = "Failed",
					Message = "Create requires an instance of User"
				};
			if (!ModelState.IsValid)
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			db.Users.Add(user);
			db.SaveChanges();
			return new JsonResponse {
				Message = "Create successful.",
				Data = user
			};
		}

		// CHANGE
		[HttpPost]
		[ActionName("Change")]
		public JsonResponse Change(User user) {
			if (user == null)
				return new JsonResponse {
					Result = "Failed",
					Message = "Change requires an instance of User"
				};
			if (!ModelState.IsValid)
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			db.Entry(user).State = System.Data.Entity.EntityState.Modified;
			db.SaveChanges();
			return new JsonResponse {
				Message = "Change successful.",
				Data = user
			};
		}

		// REMOVE
		[HttpPost]
		[ActionName("Remove")]
		public JsonResponse Remove(User user) {
			if (user == null)
				return new JsonResponse {
					Result = "Failed",
					Message = "Remove requires an instance of User"
				};
			if (!ModelState.IsValid)
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			db.Entry(user).State = System.Data.Entity.EntityState.Deleted;
			db.SaveChanges();
			return new JsonResponse {
				Message = "Remove successful.",
				Data = user
			};
		}

		// REMOVE
		[HttpGet]
		[ActionName("RemoveId")]
		public JsonResponse Remove(int? id) {
			if (id == null)
				return new JsonResponse {
					Result = "Failed",
					Message = "RemoveId requires a User.Id"
				};
			var user = db.Users.Find(id);
			if (user == null)
				return new JsonResponse {
					Result = "Failed",
					Message = $"No user has Id of {id}"
				};
			db.Users.Remove(user);
			db.SaveChanges();
			return new JsonResponse {
				Message = "Remove successful.",
				Data = user
			};
		}
	}
}