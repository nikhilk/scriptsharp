// Class1.cs
//

using System;
using System.Collections.Generic;
using KnockoutApi;

namespace App {

    public sealed class AppModel {

        public readonly Observable<string> FirstName;
        public readonly Observable<string> LastName;

        public readonly ComputedObservable<string> FullName;

        public AppModel() {
            FirstName = Knockout.Observable<string>(String.Empty);
            LastName = Knockout.Observable<string>(String.Empty);

            FullName = Knockout.Computed<string>(ComputeFullName);
        }

        private string ComputeFullName() {
            return FirstName.GetValue() + " " + LastName.GetValue();
        }
    }
}
