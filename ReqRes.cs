using System;
using Newtonsoft.Json;

namespace OrderSoft {
	public class RequestBody { 	}

	public class TestRequestBody : RequestBody {
		[JsonProperty("test")]
		public bool Test { get; set; }
	}

	public class Response {
		[JsonProperty("ordersoft_version")]
		public string ServerVersion { get; set; }
		[JsonProperty("reason")]
		public string Reason { get; set; }
	}
}