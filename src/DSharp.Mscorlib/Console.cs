using System.Runtime.CompilerServices;

namespace System
{
    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("console")]
    public static class Console
    {
        private const string CONSOLE_LOGGING_METHOD = "debug";

        [ScriptName(CONSOLE_LOGGING_METHOD)]
        public extern static void WriteLine();

        [ScriptName(CONSOLE_LOGGING_METHOD)]
        public extern static void WriteLine(bool value);

        [ScriptName(CONSOLE_LOGGING_METHOD)]
        public extern static void WriteLine(char value);

        [ScriptName(CONSOLE_LOGGING_METHOD)]
        public extern static void WriteLine(char[] buffer);

        [ScriptName(CONSOLE_LOGGING_METHOD)]
        public extern static void WriteLine(string message);

        [ScriptName(CONSOLE_LOGGING_METHOD)]
        public extern static void WriteLine(double value);

        [ScriptName(CONSOLE_LOGGING_METHOD)]
        public extern static void WriteLine(float value);

        [ScriptName(CONSOLE_LOGGING_METHOD)]
        public extern static void WriteLine(decimal value);

        [ScriptName(CONSOLE_LOGGING_METHOD)]
        public extern static void WriteLine(ushort value);

        [ScriptName(CONSOLE_LOGGING_METHOD)]
        public extern static void WriteLine(short value);

        [ScriptName(CONSOLE_LOGGING_METHOD)]
        public extern static void WriteLine(uint value);

        [ScriptName(CONSOLE_LOGGING_METHOD)]
        public extern static void WriteLine(int value);

        [ScriptName(CONSOLE_LOGGING_METHOD)]
        public extern static void WriteLine(ulong value);

        [ScriptName(CONSOLE_LOGGING_METHOD)]
        public extern static void WriteLine(long value);
    }
}
