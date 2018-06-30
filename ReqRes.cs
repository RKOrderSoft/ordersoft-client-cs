using System;
using Newtonsoft.Json;

namespace OrderSoft {
	public class RequestBody { 	}

	public class TestRequestBody : RequestBody {
		[JsonProperty("test")]
		public bool Test { get; set; }
	}

	public class LoginRequestBody : RequestBody {
		[JsonProperty("username")]
		public string Username;
		[JsonProperty("password")]
		public string Password;
	}

	public class Response {
		[JsonProperty("ordersoft_version")]
		public string ServerVersion { get; set; }
		[JsonProperty("reason")]
		public string Reason { get; set; }
	}

	public class LoginResponse : Response {
		[JsonProperty("sessionId")]
		public string SessionId;
		[JsonProperty("accessLevel")]
		public int AccessLevel;
	}
}