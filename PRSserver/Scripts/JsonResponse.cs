﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRSserver.Scripts {
	public class JsonResponse {
			public string Result { get; set; } = "Ok";
			public string Message { get; set; } = "Success";
			public object Data { get; set; }
			public object Error { get; set; }

		public JsonResponse() { }
	}
}