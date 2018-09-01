using System;

namespace OrderSoft {
	public class NotOrderSoftServerException : Exception {
		public NotOrderSoftServerException () {}
		public NotOrderSoftServerException (string message) : base(message) {}
		public NotOrderSoftServerException (string message, Exception inner) : base(message, inner) {}
	}

	public class NotInitiatedException : Exception {
		public NotInitiatedException () {}
		public NotInitiatedException (string message) : base(message) {}
		public NotInitiatedException (string message, Exception inner) : base(message, inner) {}
	}

	public class IncorrectDetailsException : Exception {
		public IncorrectDetailsException () {}
		public IncorrectDetailsException (string message) : base(message) {}
		public IncorrectDetailsException (string message, Exception inner) : base(message, inner) {}
	}

	public class UnauthenticatedException : Exception {
		public UnauthenticatedException () {}
		public UnauthenticatedException (string message) : base(message) {}
		public UnauthenticatedException (string message, Exception inner) : base(message, inner) {}
	}
}