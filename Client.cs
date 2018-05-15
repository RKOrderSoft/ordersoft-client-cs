using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.IO;
using System.Collections.Generic;

namespace OrderSoft {
	public class OSClient {
		private static readonly HttpClient theClient = new HttpClient();
		private Uri endpoint;

		public OSClient (string serverIP) {
			Console.WriteLine(serverIP);
			endpoint = new Uri(Path.Combine(serverIP, "api/test"));
			Console.WriteLine(endpoint.ToString());

			isOrdersoftServer(endpoint);
		}

		private static async void isOrdersoftServer(Uri toCheck) {
			// Check that IP is indeed that of an OrderSoft server
			var testBodyVals = new Dictionary<string, string> { { "client", "dotnet" } };
			var testBody = new FormUrlEncodedContent(testBodyVals);
			var res = await theClient.PostAsync(toCheck, testBody);
			var resStr = await res.Content.ReadAsStringAsync();
			Console.WriteLine(resStr);
		}
	}
}
