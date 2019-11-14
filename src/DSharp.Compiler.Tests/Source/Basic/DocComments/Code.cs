using System;
using System.Html;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace BasicTests {

    /// <summary>
    /// Represents a card suit.
    /// </summary>
    public enum Suit {

        /// <summary>
        /// The hearts.
        /// </summary>
        Heart = 0,

        /// <summary>
        /// The spades.
        /// </summary>
        Spade = 1,

        /// <summary>
        /// The clubs.
        /// </summary>
        Club = 2,

        /// <summary>
        /// The diamonds.
        /// </summary>
        Diamond = 3,
    }

    /// <summary>
    /// Represents a color.
    /// </summary>
    internal enum Color {

        Red = 0,

        /// <summary>
        /// The color green.
        /// </summary>
        Green = 1,
    }

    /// <summary>
    /// Represents a base class.
    /// </summary>
    public class BaseClass {

        /// <summary>
        /// A constant field.
        /// </summary>
        public const uint ConstantField = 3;

        /// <summary>
        /// A static field.
        /// </summary>
        public static string StaticField;

        /// <summary>
        /// An instance field.
        /// </summary>
        public int InstanceField;

        /// <summary>
        /// A private field.
        /// </summary>
        private Element domElement;

        /// <summary>
        /// Initializes a new instance of the BaseClass class.
        /// </summary>
        /// <param name="domElement">The parent element.</param>
        /// <param name="name">The name.</param>
        /// <param name="count">The count.</param>
        public BaseClass(Element domElement, string name, int count) {
            this.domElement = domElement;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name {
            get { return null; }
            set { }
        }

        /// <summary>
        /// Gets or sets the element.
        /// </summary>
        public Element DOMElement {
            get { return null; }
            set { }
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        public int Count {
            get { return 0; }
        }

        /// <summary>
        /// Gets the private name.
        /// </summary>
        private string PrivateName {
            get { return null; }
        }

        /// <summary>
        /// Gets the total count.
        /// </summary>
        public static int TotalCount {
            get { return 0; }
        }

        /// <summary>
        /// Adds or removes a delegate for the Initialized event.
        /// </summary>
        public event EventHandler Initialized;

        /// <summary>
        /// Gets item by identifiers.
        /// </summary>
        /// <param name="ids">The identifiers.</param>
        /// <returns>The item.</returns>
        public string this[int[] ids] {
            get {
                return null;
            }
        }

        /// <summary>
        /// Empty method.
        /// </summary>
        public void Method1() {
        }

        /// <summary>
        /// Method with return value.
        /// </summary>
        /// <returns>The string.</returns>
        public string Method2() {
            return null;
        }

        /// <summary>
        /// Method with params.
        /// </summary>
        /// <param name="first">The first name.</param>
        /// <param name="last">The last name.</param>
        public virtual void Method3(string first, string last) {
        }

        /// <summary>
        /// Method with both params and return value.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns>The set of names.</returns>
        public string[] Method4(int count) {
            return null;
        }

        /// <summary>
        /// Raises the Initialized event.
        /// </summary>
        protected internal void OnInitialized() {
            if (this.Initialized != null) {
            }
        }

        /// <summary>
        /// Private method.
        /// </summary>
        /// <param name="count">The count.</param>
        private void PrivateMethod(int count) {
        }

        /// <summary>
        /// A static method.
        /// </summary>
        /// <param name="length">The length.</param>
        public static void StaticMethod(int length) {
        }
    }

    /// <summary>
    /// Represents a derived class.
    /// </summary>
    public class DerivedClass : BaseClass {

        /// <summary>
        /// Internal constructor.
        /// </summary>
        internal DerivedClass()
            : base(null, null, 0) {
        }

        /// <summary>
        /// Overriden method with params.
        /// </summary>
        /// <param name="first">The first name.</param>
        /// <param name="last">The last name.</param>
        public override void Method3(string first, string last) {
        }
    }

    /// <summary>
    /// An internal class.
    /// </summary>
    internal class InternalClass {
    }

    internal class InternalClassWithNoComments {
    }

    /// <summary>
    /// Represents a record.
    /// </summary>
    [ScriptObject]
    public sealed class RecordClass {

        /// <summary>
        /// Gets or sets a count.
        /// </summary>
        public int Count;

        /// <summary>
        /// Initializes a new instance of the RecordClass class.
        /// </summary>
        /// <param name="count">A count.</param>
        public RecordClass(int count) {
        }
    }

    /// <summary>
    /// Represents an interface.
    /// </summary>
    public interface IInterface {

        /// <summary>
        /// Executes code.
        /// </summary>
        void Execute();
    }
}
