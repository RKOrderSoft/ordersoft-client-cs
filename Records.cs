using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace OrderSoft {
	public class OrderObject {
        [JsonIgnore]
        public DateTime? TimeSubmitted { get; set; }
        [JsonIgnore]
		public DateTime? TimeCompleted { get; set; }
        [JsonIgnore]
		public DateTime? TimePaid { get; set; }
        [JsonIgnore]
		public string[] Dishes { get; set; }

        [JsonProperty("orderId")]
		public string OrderId { get; set; }

        [JsonProperty("dishes")]
        public string DishesString {
            get { return String.Join(",", Dishes); }
            set { Dishes = value.Split(','); }
		}

		[JsonProperty("notes")]
		public string Notes { get; set; }

        [JsonProperty("timeSubmitted")]
		public string TimeSubmittedString {
            get { if (!TimeSubmitted.HasValue) return null;
                return TimeSubmitted.Value.ToString("yyyy-MM-dd HH:mm:ss", 
				System.Globalization.CultureInfo.InvariantCulture); }
			set { TimeSubmitted = DateTime.ParseExact(value, "yyyy-MM-dd HH:mm:ss", 
				System.Globalization.CultureInfo.InvariantCulture); }
		}

		[JsonProperty("timeCompleted")]
		public string TimeCompletedString {
            get { if (!TimeCompleted.HasValue) return null;
                return TimeCompleted.Value.ToString("yyyy-MM-dd HH:mm:ss", 
				System.Globalization.CultureInfo.InvariantCulture); }
			set { TimeCompleted = DateTime.ParseExact(value, "yyyy-MM-dd HH:mm:ss", 
				System.Globalization.CultureInfo.InvariantCulture); }
		}

		[JsonProperty("timePaid")]
		public string TimePaidString {
            get { if (!TimePaid.HasValue) return null;
                return TimePaid.Value.ToString("yyyy-MM-dd HH:mm:ss", 
				System.Globalization.CultureInfo.InvariantCulture); }
			set { TimePaid = DateTime.ParseExact(value, "yyyy-MM-dd HH:mm:ss", 
				System.Globalization.CultureInfo.InvariantCulture); }
		}

		[JsonProperty("serverId")]
		public string ServerId { get; set; }

        [JsonProperty("tableNumber")]
		public int TableNumber { get; set; }

        [JsonProperty("amtPaid")]
		public float? AmtPaid { get; set; }
    }

	public class DishObject {
        [JsonIgnore]
		public string[] Sizes { get; set; }

        [JsonProperty("dishId")]
		public int DishId { get; set; }

        [JsonProperty("name")]
		public string Name { get; set; }

        [JsonProperty("basePrice")]
		public float BasePrice { get; set; }

        [JsonProperty("upgradePrice")]
		public float UpgradePrice { get; set; }

        [JsonProperty("sizes")]
		public string SizesString {
			get {
                if (Sizes == null) return null;
                return String.Join(",", Sizes);
            }
			set {
                if (SizesString != null){
                    Sizes = value.Split(',');
                }
            }
		}

		[JsonProperty("category")]
		public string Category { get; set; }

        [JsonProperty("image")]
		public string Image { get; set; }

        [JsonProperty("description")]
		public string Description { get; set; }
    }

	public class UserObject {
		[JsonIgnore]
		public DateTime? DateAdded { get; set; }

        [JsonProperty("userId")]
		public string UserId { get; set; }

        [JsonProperty("username")]
		public string Username { get; set; }

        [JsonProperty("accessLevel")]
		public int AccessLevel { get; set; }

        [JsonProperty("dateAdded")]
		public string DateAddedString {
			get { if (!DateAdded.HasValue) return null;
                return DateAdded.Value.ToString("yyyy-MM-dd HH:mm:ss", 
				System.Globalization.CultureInfo.InvariantCulture); }
			set { DateAdded = DateTime.ParseExact(value, "yyyy-MM-dd HH:mm:ss", 
				System.Globalization.CultureInfo.InvariantCulture); }
		}
	}
}