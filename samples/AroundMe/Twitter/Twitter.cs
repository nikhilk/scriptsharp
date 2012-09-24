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

        [ScriptProperty]
        public bool Counter {
            get;
            set;
        }

        [ScriptProperty]
        public TweetBoxData Data {
            get;
            set;
        }

        [ScriptProperty]
        public string DefaultContent {
            get;
            set;
        }

        [ScriptProperty]
        public int Height {
            get;
            set;
        }

        [ScriptProperty]
        public string Label {
            get;
            set;
        }

        [ScriptName("onTweet")]
        [ScriptProperty]
        public TweetCallback Callback {
            get;
            set;
        }

        [ScriptProperty]
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
        [ScriptProperty]
        public double Latitude {
            get;
            set;
        }

        [ScriptName("lon")]
        [ScriptProperty]
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
