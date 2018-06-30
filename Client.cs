using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace OrderSoft {
	public class Response {
		public string ordersoft_version { get; set; }
		public string reason { get; set; }
	}

	public class OSClient {
		public const string CLIENT_ID = "dotnet";

		private static readonly HttpClient httpClient = new HttpClient();
		private string sessionId;
		private Uri endpoint;

		public OSClient() {
			httpClient.DefaultRequestHeaders.Add("client", CLIENT_ID);
		}

		public async void init(string newUrl) {
			endpoint = new Uri(Path.Combine(newUrl, "api/"));

			var vals = new Dictionary<string,bool> {};
			vals.Add("test", true);
			var response = await sendRequest("test", vals);
			var yes = response.StatusCode == HttpStatusCode.OK;
			Console.WriteLine(yes.ToString() + response.StatusCode.ToString());

			string responseContent = await response.Content.ReadAsStringAsync();
			Console.WriteLine(responseContent);
			Response initResponse = JsonConvert.DeserializeObject<Response>(responseContent);
			Console.WriteLine(initResponse.ordersoft_version);
		}

		private Task<HttpResponseMessage> sendRequest (String relativeUrl, 
		  Dictionary<string,bool> bodyVals) {
			var urlToPost = new Uri(endpoint, relativeUrl);

			// Add sessionId if initialised, else warn
			Console.WriteLine(httpClient.DefaultRequestHeaders);
			if (sessionId == null) {
				Console.Write("Attempting to POST ");
				Console.Write(relativeUrl);
				Console.WriteLine(" with no sessionId");
			} else {
				httpClient.DefaultRequestHeaders.Add("sessionId", sessionId);
			}

			// Convert dict to JSON, StringContent
			var bodyJSON = JsonConvert.SerializeObject(bodyVals);
			var bodyContent = new StringContent(bodyJSON, Encoding.UTF8, 
			  "application/json");

			return httpClient.PostAsync(urlToPost, bodyContent); // TODO handle get/delete
		}
	}
}
