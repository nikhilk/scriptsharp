// Twitter.cs
//

// https://dev.twitter.com/anywhere/begin

using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace TwitterApi {

    public delegate void TwitterCallback(TwitterObject twitterObject);

    [Imported]
    [IgnoreNamespace]
    [ScriptName("twttr")]
    public static class Twitter {

        public static void Anywhere(TwitterCallback callback) {
        }
    }

    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class TweetBoxOptions {

        public TweetBoxOptions() {
        }

        public TweetBoxOptions(params object[] nameValuePairs) {
        }

        [IntrinsicProperty]
        public bool Counter {
            get;
            set;
        }

        [IntrinsicProperty]
        public TweetBoxData Data {
            get;
            set;
        }

        [IntrinsicProperty]
        public string DefaultContent {
            get;
            set;
        }

        [IntrinsicProperty]
        public int Height {
            get;
            set;
        }

        [IntrinsicProperty]
        public string Label {
            get;
            set;
        }

        [ScriptName("onTweet")]
        [IntrinsicProperty]
        public TweetCallback Callback {
            get;
            set;
        }

        [IntrinsicProperty]
        public int Width {
            get;
            set;
        }
    }

    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class TweetBoxData {

        public TweetBoxData() {
        }

        public TweetBoxData(params object[] nameValuePairs) {
        }

        [ScriptName("lat")]
        [IntrinsicProperty]
        public double Latitude {
            get;
            set;
        }

        [ScriptName("lon")]
        [IntrinsicProperty]
        public double Longitude {
            get;
            set;
        }
    }


    public delegate void TweetCallback(string text, string htmlText);

    [Imported]
    [IgnoreNamespace]
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
