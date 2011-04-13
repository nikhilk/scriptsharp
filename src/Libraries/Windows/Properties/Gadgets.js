if (System && System.Gadget) {
    // Running in the context of a Sidebar gadget.

    window.Gadget = System.Gadget;
    window.Sidebar = System.Gadget.Sidebar;
    window.SideShow = System.Gadget.SideShow;
    window.EnvironmentService = System.Environment;
    window.TimeService = System.Time;
    window.SoundService = System.Sound;
    window.ShellService = System.Shell;

    ss.Debug.assert = function Gadgets$Debug$assert(condition, message) {
        if (!condition) {
            message = message + '\r\n\r\nBreak into debugger?';

            var shell = new Shell();
            if (shell.Popup(message, 0, 'Assert Failed', 20) == 6) {
                ss.Debug._fail(message);
            }
        }
    };

    ss.Debug.writeLine = function Gadgets$Debug$writeLine(message) {
        System.Debug.outputString(message + '\r\n');
    }
}
