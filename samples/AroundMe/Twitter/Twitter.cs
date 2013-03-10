// Twitter.cs
//

// https://dev.twitter.com/anywhere/begin

using System;
using System.Runtime.CompilerServices;

namespace TwitterApi {

    public delegate void TwitterCallback(TwitterObject twitterObject);

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("twttr")]
    public static class Twitter {

        public static void Anywhere(TwitterCallback callback) {
        }
    }

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Object")]
    public sealed class TweetBoxOptions {

        public TweetBoxOptions() {
        }

        public TweetBoxOptions(params object[] nameValuePairs) {
        }

        [ScriptField]
        public bool Counter {
            get;
            set;
        }

        [ScriptField]
        public TweetBoxData Data {
            get;
            set;
        }

        [ScriptField]
        public string DefaultContent {
            get;
            set;
        }

        [ScriptField]
        public int Height {
            get;
            set;
        }

        [ScriptField]
        public string Label {
            get;
            set;
        }

        [ScriptName("onTweet")]
        [ScriptField]
        public TweetCallback Callback {
            get;
            set;
        }

        [ScriptField]
        public int Width {
            get;
            set;
        }
    }

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Object")]
    public sealed class TweetBoxData {

        public TweetBoxData() {
        }

        public TweetBoxData(params object[] nameValuePairs) {
        }

        [ScriptName("lat")]
        [ScriptField]
        public double Latitude {
            get;
            set;
        }

        [ScriptName("lon")]
        [ScriptField]
        public double Longitude {
            get;
            set;
        }
    }


    public delegate void TweetCallback(string text, string htmlText);

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public sealed class TwitterObject {

        private TwitterObject() {
        }

        public void TweetBox() {
        }

        public void TweetBox(TweetBoxOptions options) {
        }

        [ScriptName("")]
        public TwitterObject Select(string selector) {
            return null;
        }
    }
}
