namespace DSharp.Shell.src
{
    public class Properties
    {
        public string Normal { get; set; }

        public string ReadLocalWrite { get; private set; }

        public string Readonly { get; }

        public Properties(string readonlyVal)
        {
            Readonly = readonlyVal;
        }

        public void Change(string value)
        {
            ReadLocalWrite = value;
        }
    }
}
