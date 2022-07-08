using RequestConsole.Abstractions;

namespace RequestConsole
{
    internal class InputReader : IInputReader
    {
        public string Read(string input)
        {
            try
            {
                // Open the text file using a stream reader.
                using var sr = new StreamReader(input);
                return sr.ReadToEnd();
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
