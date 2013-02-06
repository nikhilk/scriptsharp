// Test.cs
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Logger.Formatters;
using Logger.LogProviders;

namespace Logger {

    public class Test {
        public Test() {
            Logger logger = new Logger();
            logger.AddProvider(new ConsoleLogger(LogLevel.Debug, new DefaultFormatter()));
            //logger.AddProvider(new ServerProvider(LogLevel.Info, new DefaultFormatter(), true, "http://localhost"));
            logger.AddProvider(new WindowProvider(LogLevel.Debug, new DefaultFormatter()));
            logger.AddProvider(new TestProvider(LogLevel.Debug, new DefaultFormatter(), delegate(string s) {
                Debug.WriteLine("TEST" + s);
            }));

            logger.LogInfo("This is a test!!!");
        }
    }
}
