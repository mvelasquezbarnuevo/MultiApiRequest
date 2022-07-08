namespace RequestConsole.Models
{
    public class XmlRequest
    {
        public string? Source { get; set; }
        public string? Destination { get; set; }
        public Package[]? Packages { get; set; }
    }

    public class Package
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
