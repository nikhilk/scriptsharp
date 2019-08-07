using System;
using System.Collections.Generic;
using System.Html;
using System.Runtime.CompilerServices;
using System.Serialization;

[assembly: ScriptAssembly("test")]

namespace ExpressionTests {

    public class Foo {
    
        public List<int> _numbers;
        public Func<int, string> _func;
        
        public Foo() {
            _numbers = new List<int>();
            
            string s = _numbers[10].ToString(10);
            string s2 = _numbers.GetEnumerator().Current.ToString(10);
            string s3 = _numbers.Reduce<int>(delegate(int accumulated, int item) { return accumulated + item; }, 0).ToString(10);
            
            string s4 = _func(10).EncodeUriComponent();
            
            Func<int, string> f2 = _func;
            f2(11).Trim();
            
            Dictionary<string, int> d = new Dictionary<string, int>();
            int keys = d.Keys.Count;
            bool b = d.ContainsKey("abc");
            d.Remove("abc");
            
            foreach (KeyValuePair<string, int> de in d) {
            }
            
            string json = "";
            Foo f = Json.ParseData<Foo>(json).Setup().Run().Cleanup();
            
            string name = Document.GetElementById("nameTB").As<InputElement>().Value;
        }
        
        public Foo Cleanup() {
            return this;
        }
        
        public Foo Run() {
            return this;
        }
        
        public Foo Setup() {
            return this;
        }
    }
}
