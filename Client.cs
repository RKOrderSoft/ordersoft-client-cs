using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderSoft {
	public class OSClient {
		public const string CLIENT_ID = "dotnet";

		private static readonly HttpClient httpClient = new HttpClient();
		private Uri endpoint;
		private string sessionId;

		public OSClient (string serverIP) {
			Console.WriteLine(serverIP);
			endpoint = new Uri(Path.Combine(serverIP, "api/"));
			Console.WriteLine(endpoint.ToString());

			isOrdersoftServer(endpoint);
		}

		/*public async void authenticate(string username, string password) {
			// TODO
			return;
		}*/

		private async void isOrdersoftServer(Uri toCheck) {
			// Check that IP is indeed that of an OrderSoft server
			var vals = new Dictionary<string,string> {};
			var response = await requestToServer("test", vals);
			var responseText = await response.Content.ReadAsStringAsync();
			Console.WriteLine(responseText);
		}

		private Task<HttpResponseMessage> requestToServer (String relativeUrl, Dictionary<string,string> bodyVals) {
			var urlToPost = new Uri(endpoint, relativeUrl);

			bodyVals.Add("client", CLIENT_ID);
			if (sessionId == null) {
				Console.WriteLine("Attempting to POST " + relativeUrl + " with no sessionId");
			} else {
				bodyVals.Add("sessionId", sessionId);
			}
			Console.WriteLine(bodyVals);
			Console.WriteLine(JsonConvert.SerializeObject(bodyVals));

			// Convert dict to JSON, StringContent
			var bodyContent = new StringContent(JsonConvert.SerializeObject(bodyVals), Encoding.UTF8, "application/json");

			return httpClient.PostAsync(urlToPost, bodyContent);
			//return response.Content.ReadAsStringAsync();
		}
	}
}
