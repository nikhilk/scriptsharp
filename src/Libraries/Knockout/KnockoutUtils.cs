using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace KnockoutApi
{
    [Imported]
    [IgnoreNamespace]
    [ScriptName("ko.utils")]
    public static class KnockoutUtils
    {
        public static T[] ArrayGetDistinctValues<T>(IEnumerable<T> array) {
            return null;
        }

        public static T[] ArrayFilter<T>(IEnumerable<T> array, Func<T, bool> predicate) {
            return null;
        }

        public static T[] MakeArray<T>(IEnumerable<T> array) {
            return null;
        }

        [AlternateSignature] public extern static T UnwrapObservable<T>(T array);
        [AlternateSignature] public extern static T UnwrapObservable<T>(Observable<T> array);
        public static T[] UnwrapObservable<T>(ObservableArray<T> array) {
            return null;
        }

        public static void PostJson(object urlOrForm, object data, Dictionary options) {
            return;
        }

        public static T ParseJson<T>(string jsonString) {
            return default(T);
        }

        public static string stringifyJson(object obj) {
            return null;
        }

        public static int[] Range(int min, int max) {
            return null;
        }
    }
}