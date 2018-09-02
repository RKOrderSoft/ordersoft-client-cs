using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace OrderSoft {
	public class OrderObject {
		public DateTime TimeSubmitted;
		public DateTime TimeCompleted;
		public DateTime TimePaid;
		public string[] Dishes;

		[JsonProperty("orderId")]
		public string OrderId;

		[JsonProperty("dishes")]
        public string DishesString {
            get { return String.Join(",", Dishes); }
            set { Dishes = value.Split(','); }
		}

		[JsonProperty("notes")]
		public string Notes;

		[JsonProperty("timeSubmitted")]
		public string TimeSubmittedString {
			get { return TimeSubmitted.ToString("yyyy-MM-dd HH:mm:ss", 
				System.Globalization.CultureInfo.InvariantCulture); }
			set { TimeSubmitted = DateTime.ParseExact(value, "yyyy-MM-dd HH:mm:ss", 
				System.Globalization.CultureInfo.InvariantCulture); }
		}

		[JsonProperty("timeCompleted")]
		public string TimeCompletedString {
			get { return TimeCompleted.ToString("yyyy-MM-dd HH:mm:ss", 
				System.Globalization.CultureInfo.InvariantCulture); }
			set { TimeCompleted = DateTime.ParseExact(value, "yyyy-MM-dd HH:mm:ss", 
				System.Globalization.CultureInfo.InvariantCulture); }
		}

		[JsonProperty("timePaid")]
		public string TimePaidString {
			get { return TimePaid.ToString("yyyy-MM-dd HH:mm:ss", 
				System.Globalization.CultureInfo.InvariantCulture); }
			set { TimePaid = DateTime.ParseExact(value, "yyyy-MM-dd HH:mm:ss", 
				System.Globalization.CultureInfo.InvariantCulture); }
		}

		[JsonProperty("serverId")]
		public string ServerId;

		[JsonProperty("tableNumber")]
		public int TableNumber;

		[JsonProperty("amtPaid")]
		public float AmtPaid;
	}

	public class DishObject {
		public string[] Sizes;

		[JsonProperty("dishId")]
		public int DishId;

		[JsonProperty("name")]
		public string Name;

		[JsonProperty("basePrice")]
		public float BasePrice;

		[JsonProperty("upgradePrice")]
		public float UpgradePrice;

		[JsonProperty("sizes")]
		public string SizesString {
			get { return String.Join(",", Sizes); }
			set { Sizes = value.Split(','); }
		}

		[JsonProperty("category")]
		public string Category;

		[JsonProperty("image")]
		public string Image;

		[JsonProperty("description")]
		public string Description;
	}
}