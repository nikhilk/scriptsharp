using System.Collections.Generic;
using System.Linq;
using DSharp.Compiler;

namespace DSharp.ImportedMetadataGenerator
{
    class Program
    {
        static bool hasErrors;

        static int Main(string[] args)
        {
            var opts = new Options();

            foreach (var arg in args)
            {
                var parts = arg.Split("=");
                var name = parts[0];

                if (typeof(Options).GetProperty(name) is var prop)
                {
                    if (typeof(IEnumerable<string>).IsAssignableFrom(prop.PropertyType))
                    {
                        var values = parts[1].Split(";").Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
                        prop.SetValue(opts, values);
                    }
                    else
                    {
                        var value = parts[1];
                        if (prop.PropertyType == typeof(bool))
                        {
                            if(bool.TryParse(value, out bool result))
                            {
                                prop.SetValue(opts, result);
                            }
                        }
                        else
                        {
                            prop.SetValue(opts, value);
                        }
                    }
                }
            }

            MetadataCompiler compiler = new MetadataCompiler(new ConsoleErrorHandler());
            return (compiler.Compile(opts) && !hasErrors)
                ? 0 
                : 1;
        }
    }
}
