using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

namespace jQueryApi.Validation
{
	[Imported]
	[IgnoreNamespace]
	[ScriptName("Object")]
	public sealed class ValidationMessageOptions : Record
	{
		/// <summary>
		/// Makes the element require a certain file extension
		/// </summary>
		[IntrinsicProperty]
		public object Accept {
			get	{
				return null;
			}
			set	{
			}
		}

		/// <summary>
		/// Makes the element require a creditcard number
		/// </summary>
		[IntrinsicProperty]
		[ScriptName("creditcard")]
		public object CreditCard {
			get	{
				return false;
			}
			set	{
			}
		}

		/// <summary>
		/// Makes the element require a date
		/// </summary>
		[IntrinsicProperty]
		public object Date {
			get	{
				return false;
			}
			set	{
			}
		}

		/// <summary>
		/// Makes the element require a ISO date
		/// </summary>
		[IntrinsicProperty]
		[ScriptName("dateISO")]
		public object DateISO {
			get {
				return false;
			}
			set	{
			}
		}

		/// <summary>
		/// Makes the element require digits only
		/// </summary>
		[IntrinsicProperty]
		public object Digits {
			get	{
				return false;
			}
			set	{
			}
		}

		/// <summary>
		/// Makes the element require a valid email address
		/// </summary>
		[IntrinsicProperty]
		public object Email	{
			get {
				return false;
			}
			set	{
			}
		}

		/// <summary>
		/// Requires the element to be the same as another one
		/// </summary>
		[IntrinsicProperty]
		public object EqualTo {
			get {
				return null;
			}
			set {
			}
		}

		/// <summary>
		/// Makes the element require a given maximum
		/// </summary>
		[IntrinsicProperty]
		public object Max {
			get {
				return 0;
			}
			set {
			}
		}

		/// <summary>
		/// Makes the element require a given maximum length
		/// </summary>
		[IntrinsicProperty]
		public object MaxLength {
			get {
				return 0;
			}
			set	{
			}
		}

		/// <summary>
		/// Makes the element require given minimum
		/// </summary>
		[IntrinsicProperty]
		public object Min {
			get {
				return 0;
			}
			set	{
			}
		}

		/// <summary>
		/// Makes the element require a given minimum length
		/// </summary>
		[IntrinsicProperty]
		public object MinLength {
			get	{
				return 0;
			}
			set {
			}
		}

		/// <summary>
		/// Makes the element require a decimal number
		/// </summary>
		[IntrinsicProperty]
		public object Number {
			get	{
				return false;
			}
			set	{
			}
		}

		[IntrinsicProperty]
		[ScriptName("phoneUS")]
		public object PhoneUS {
			get	{
				return false;
			}
			set	{
			}
		}

		/// <summary>
		/// Makes the value require a given value range
		/// </summary>
		[IntrinsicProperty]
		public object Range {
			get {
				return null;
			}
			set	{
			}
		}

		/// <summary>
		/// Makes the element require a given value range
		/// </summary>
		[IntrinsicProperty]
		public object RangeLength {
			get	{
				return null;
			}
			set	{
			}
		}

		/// <summary>
		/// Requests a resource to check the element for validity
		/// </summary>
		[IntrinsicProperty]
		public object Remote {
			get	{
				return null;
			}
			set	{
			}
		}
	
		/// <summary>
		/// Makes the element always required
		/// </summary>
		[IntrinsicProperty]
		public object Required {
			get{
				return false;
			}
			set	{
			}
		}

		/// <summary>
		/// Makes the element require a valid url
		/// </summary>
		[IntrinsicProperty]
		public object Url {
			get	{
				return false;
			}
			set {
			}
		}

	}
}
