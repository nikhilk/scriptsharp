// CustomValidationMethodHandler.cs
//

using System;
using System.Collections.Generic;
using System.Html;

namespace jQueryApi.Validation
{
	public delegate bool CustomValidationMethodHandler(string value, Element element, object [] parameters);
}
