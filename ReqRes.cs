using System;
using Newtonsoft.Json;

namespace OrderSoft {

	// ===============
	// Request objects
	// ===============

	public class RequestBody { 	}

	public class TestRequest : RequestBody {
		[JsonProperty("test")]
		public bool Test;
	}

	public class LoginRequest : RequestBody {
		[JsonProperty("username")]
		public string Username;

		[JsonProperty("password")]
		public string Password;
	}

	public class GetOrderRequest : RequestBody {
		[JsonProperty("orderId")]
		public string OrderId;

		[JsonProperty("tableNumber")]
		public int TableNumber;
	}

	public class SetOrderRequest : RequestBody {
		[JsonProperty("order")]
		public OrderObject Order;
	}

	public class GetDishesRequest : RequestBody {
		[JsonProperty("dishId")]
		public int DishId;

		[JsonProperty("category")]
		public string Category;

		[JsonProperty("minPrice")]
		public float minPrice;

		[JsonProperty("maxPrice")]
		public float maxPrice;
	}

	// ================
	// Response objects
	// ================

	public class Response {
		[JsonProperty("ordersoft_version")]
		public string ServerVersion;

		[JsonProperty("reason")]
		public string Reason;
	}

	public class LoginResponse : Response {
		[JsonProperty("sessionId")]
		public string SessionId;

		[JsonProperty("accessLevel")]
		public int AccessLevel;
	}

	public class GetOrderResponse : Response {
		[JsonProperty("order")]
		public OrderObject Order;
	}

	public class SetOrderResponse : Response {
		[JsonProperty("orderId")]
		public string OrderId;
	}

	public class OpenOrdersResponse : Response {
		public string[] OpenOrders;

		[JsonProperty("openOrders")]
		public string OpenOrdersString {
			get { return String.Join(",", OpenOrders); }
			set { OpenOrders = value.Split(','); }
		}
	}

	public class UnpaidOrdersResponse : Response {
		public string[] UnpaidOrders;

		[JsonProperty("unpaidOrders")]
		public string UnpaidOrdersString {
			get { return String.Join(",", UnpaidOrders); }
			set { UnpaidOrders = value.Split(','); }
		}
	}

	public class GetDishesResponse : Response {
		[JsonProperty("results")]
		public DishObject[] Results;
	}
}