 using System.Runtime.CompilerServices;
using NonStandard;

namespace System
{
    public sealed partial class String
    {
        /// <summary>
        /// Retrieves the character at the specified position.
        /// </summary>
        /// <param name="index">The specified 0-based position.</param>
        /// <returns>The character within the string.</returns>
        [Obsolete(ObsoleteConsts.MESSAGE_ON_OBSOLETE, ObsoleteConsts.ERROR_ON_OBSOLETE)]
        public extern char CharAt(int index);

        /// <summary>
        /// Retrieves the character code of the character at the specified position.
        /// </summary>
        /// <param name="index">The specified 0-based position.</param>
        /// <returns>The character code of the character within the string.</returns>
        [Obsolete(ObsoleteConsts.MESSAGE_ON_OBSOLETE, ObsoleteConsts.ERROR_ON_OBSOLETE)]
        public extern int CharCodeAt(int index);

        /// <summary>
        /// Returns the unencoded version of a complete encoded URI.
        /// </summary>
        /// <returns>The unencoded string.</returns>
        // this is not part of CLR. Should this go into an abstraction?
        [ScriptAlias("decodeURI")]
        public extern string DecodeUri();

        /// <summary>
        /// Returns the unencoded version of a single part or component of an encoded URI.
        /// </summary>
        /// <returns>The unencoded string.</returns>
        // this is not part of CLR. Should this go into an abstraction?
        [ScriptAlias("decodeURIComponent")]
        public extern string DecodeUriComponent();

        /// <summary>
        /// Encodes the complete URI.
        /// </summary>
        /// <returns>The encoded string.</returns
        // this is not part of CLR. Should this go into an abstraction?
        [ScriptAlias("encodeURI")]
        public extern string EncodeUri();

        /// <summary>
        /// Encodes a single part or component of a URI.
        /// </summary>
        /// <returns>The encoded string.</returns>
        // this is not part of CLR. Should this go into an abstraction?
        [ScriptAlias("encodeURIComponent")]
        public extern string EncodeUriComponent();

        /// <summary>
        /// Encodes a string by replacing punctuation, spaces etc. with their escaped equivalents.
        /// </summary>
        /// <returns>The escaped string.</returns>
        // this is not part of CLR. Should this go into an abstraction?
        [ScriptAlias("escape")]
        public extern string Escape();

        [DSharpScriptMemberName("string")]
        [Obsolete(ObsoleteConsts.MESSAGE_ON_OBSOLETE, ObsoleteConsts.ERROR_ON_OBSOLETE)]
        public extern static string FromChar(char ch, int count);

        [Obsolete(ObsoleteConsts.MESSAGE_ON_OBSOLETE, ObsoleteConsts.ERROR_ON_OBSOLETE)]
        public extern static string FromCharCode(int charCode);

        [Obsolete(ObsoleteConsts.MESSAGE_ON_OBSOLETE, ObsoleteConsts.ERROR_ON_OBSOLETE)]
        public extern static string FromCharCode(params int[] charCodes);

        [Obsolete(ObsoleteConsts.MESSAGE_ON_OBSOLETE, ObsoleteConsts.ERROR_ON_OBSOLETE)]
        public extern int IndexOf(char ch);

        [Obsolete(ObsoleteConsts.MESSAGE_ON_OBSOLETE, ObsoleteConsts.ERROR_ON_OBSOLETE)]
        public extern int IndexOf(char ch, int startIndex);

        [Obsolete(ObsoleteConsts.MESSAGE_ON_OBSOLETE, ObsoleteConsts.ERROR_ON_OBSOLETE)]
        public extern int LastIndexOf(string subString);

        [Obsolete(ObsoleteConsts.MESSAGE_ON_OBSOLETE, ObsoleteConsts.ERROR_ON_OBSOLETE)]
        public extern int LastIndexOf(string subString, int startIndex);

        [Obsolete(ObsoleteConsts.MESSAGE_ON_OBSOLETE, ObsoleteConsts.ERROR_ON_OBSOLETE)]
        public extern string[] Match(RegExp regex);

        [ScriptName("replace")]
        [Obsolete(ObsoleteConsts.MESSAGE_ON_OBSOLETE, ObsoleteConsts.ERROR_ON_OBSOLETE)]
        public extern string ReplaceFirst(string oldText, string replaceText);

        [ScriptName("replace")]
        [Obsolete(ObsoleteConsts.MESSAGE_ON_OBSOLETE, ObsoleteConsts.ERROR_ON_OBSOLETE)]
        public extern string ReplaceRegex(RegExp regex, string replaceText);

        [ScriptName("replace")]
        [Obsolete(ObsoleteConsts.MESSAGE_ON_OBSOLETE, ObsoleteConsts.ERROR_ON_OBSOLETE)]
        public extern string ReplaceRegex(RegExp regex, StringReplaceCallback callback);

        [Obsolete(ObsoleteConsts.MESSAGE_ON_OBSOLETE, ObsoleteConsts.ERROR_ON_OBSOLETE)]
        public extern int Search(RegExp regex);

        [Obsolete(ObsoleteConsts.MESSAGE_ON_OBSOLETE, ObsoleteConsts.ERROR_ON_OBSOLETE)]
        public extern string[] Split(RegExp regex);

        [Obsolete(ObsoleteConsts.MESSAGE_ON_OBSOLETE, ObsoleteConsts.ERROR_ON_OBSOLETE)]
        public extern string[] Split(RegExp regex, int limit);

        [Obsolete(ObsoleteConsts.MESSAGE_ON_OBSOLETE, ObsoleteConsts.ERROR_ON_OBSOLETE)]
        public extern string Substr(int startIndex);

        [Obsolete(ObsoleteConsts.MESSAGE_ON_OBSOLETE, ObsoleteConsts.ERROR_ON_OBSOLETE)]
        public extern string Substr(int startIndex, int length);

        [Obsolete(ObsoleteConsts.MESSAGE_ON_OBSOLETE, ObsoleteConsts.ERROR_ON_OBSOLETE)]
        public extern string ToLowerCase();

        [Obsolete(ObsoleteConsts.MESSAGE_ON_OBSOLETE, ObsoleteConsts.ERROR_ON_OBSOLETE)]
        public extern string ToUpperCase();

        /// <summary>
        /// Decodes a string by replacing escaped parts with their equivalent textual representation.
        /// </summary>
        /// <returns>The unescaped string.</returns>
        [ScriptAlias("unescape")]
        [Obsolete(ObsoleteConsts.MESSAGE_ON_OBSOLETE, ObsoleteConsts.ERROR_ON_OBSOLETE)]
        public extern string Unescape();

        // This method is called ToLowerInvariant() on CLR
        public extern string ToLocaleLowerCase();

        // This method is called ToUpperInvariant() on CLR
        public extern string ToLocaleUpperCase();
    }
}
