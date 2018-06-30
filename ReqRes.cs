using System;
using Newtonsoft.Json;

namespace OrderSoft {
	public struct Request {
		[JsonProperty("test")]
		public bool Test { get; set; }
	}
	
	public struct Response {
		[JsonProperty("ordersoft_version")]
		public string ServerVersion { get; set; }
		[JsonProperty("reason")]
		public string reason { get; set; }
	}
}