using System;
using System.Collections.Generic;
using System.Html;
using System.Runtime.CompilerServices;
using System.Serialization;
using jQueryApi;

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
            string s5 = jQuery.ExtendDictionary<string, int>(d, d)["abc"].ToString(10);
            int keys = d.Count;
            bool b = d.ContainsKey("abc");
            d.Remove("abc");
            
            foreach (KeyValuePair<string, int> de in d) {
            }
            
            jQuery.AjaxRequest<string>("http://example.com").Success(delegate(string html) {
                Window.Alert(html);
            });
            
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
