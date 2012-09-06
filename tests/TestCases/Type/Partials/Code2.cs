using System;
using System.Html;

namespace TypeTests {

    public partial class DerivedMergedMembersClass {

        public DerivedMergedMembersClass() {
            this.Name = this.Bar + base.Bar + "Name";
        }

        public string this[string s] {
            get {
                return s;
            }
        }

        public void SomeMethod() {
            Element e1 = Document.GetElementById(this.Bar);
            Element e2 = Document.GetElementById(this.Name);
            Element e3 = Document.GetElementById(base.Bar);

            string s = TestMethod() + base.TestMethod();
        }
    }
}
