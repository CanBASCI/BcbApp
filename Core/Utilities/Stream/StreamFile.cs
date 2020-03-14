using System.IO;

namespace Core.Utilities.Stream
{
    public static class StreamFile
    {
        private const string path = "C:\\BcbAppLog.txt";
        public static void Write(string message)
        {
            using (var stream = new StreamWriter(path, true))
            {
                stream.WriteLine(message);
                stream.Close();
            }
        }
    }
}
