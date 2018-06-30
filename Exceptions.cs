using System;

namespace OrderSoft {
	public class NotOrderSoftServerException : Exception {
		public NotOrderSoftServerException () {}
		public NotOrderSoftServerException (string message) : base(message) {}
		public NotOrderSoftServerException (string message, Exception inner) : base(message, inner) {}
	}
}