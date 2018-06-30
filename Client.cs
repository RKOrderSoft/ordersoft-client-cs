using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace OrderSoft {
	public class OSClient {
		public const string CLIENT_ID = "dotnet";

		private static readonly HttpClient httpClient = new HttpClient();
		private string sessionId;
		private Uri endpoint;

		public OSClient () {
			httpClient.DefaultRequestHeaders.Add("client", CLIENT_ID);
		}

		/// <summary>
		///   Check if newUrl is an OrderSoft server and, if it is, set endpoint.
		/// </summary>
		public async void init (string newUrl) {
			endpoint = new Uri(Path.Combine(newUrl, "api/"));

			var vals = new Request();
			vals.Test = true;
			var response = await sendRequest("test", vals);
			var yes = response.StatusCode == HttpStatusCode.OK;
			Console.WriteLine(yes.ToString() + response.StatusCode.ToString());

			string responseContent = await response.Content.ReadAsStringAsync();
			responseContent = parseResponse(responseContent);
			Console.WriteLine(responseContent);
			Response initResponse = JsonConvert.DeserializeObject<Response>(responseContent);
			Console.WriteLine(initResponse.ServerVersion);
		}

		/// <summary>
		///   Parse string received from server so JsonConvert can use it
		///   TODO find a better way of doing this??
		/// </summary>
		private static string parseResponse (string inString) {
			return inString.Trim('"').Replace("\\", "");
		}

		/// <summary>
		///   Sends request to endpoint/relativeUrl, using bodyVals
		/// </summary>
		private Task<HttpResponseMessage> sendRequest (String relativeUrl, 
		  Request bodyVals) {
			var urlToPost = new Uri(endpoint, relativeUrl);

			// Convert dict to JSON, StringContent
			var bodyJSON = JsonConvert.SerializeObject(bodyVals);
			var bodyContent = new StringContent(bodyJSON, Encoding.UTF8, 
			  "application/json");

			return httpClient.PostAsync(urlToPost, bodyContent); // TODO handle get/delete
		}
	}
}
