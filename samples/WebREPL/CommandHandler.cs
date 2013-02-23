// CommandHandler.cs
//

using System;
using NodeApi;
using NodeApi.Compute;
using NodeApi.IO;

namespace WebREPL {

    internal sealed class CommandHandler {

        private WebRequest _webRequest;
        private WebResponse _webResponse;

        public CommandHandler() {
            _webRequest = new WebRequest();
            _webResponse = new WebResponse();
        }

        private void EvaluateCommand(string command, object context, string fileName, AsyncResultCallback<object> callback) {
            object result = Script.Undefined;

            command = command.Substr(1, command.Length - 2).Trim();
            if (command.Length != 0) {
                WebCommand webCommand = WebCommand.TryParseCommand(command, _webRequest, _webResponse);
                if (webCommand != null) {
                    webCommand.HandleCommand(callback);
                    return;
                }
                else {
                    try {
                        Script.SetField(context, "$", _webRequest);
                        Script.SetField(context, "$$", _webResponse);

                        ScriptInstance script = ScriptEngine.CreateScript(command);
                        result = script.RunInNewContext(context);
                    }
                    catch (Exception e) {
                        Console.Error(e.Message);
                    }
                }
            }

            callback(null, result);
        }

        public void Run() {
            REPLOptions commandOptions = new REPLOptions();
            commandOptions.Input = Node.Process.StandardInput;
            commandOptions.Output = Node.Process.StandardOutput;
            commandOptions.Eval = EvaluateCommand;

            REPL.Start(commandOptions);
        }
    }
}
