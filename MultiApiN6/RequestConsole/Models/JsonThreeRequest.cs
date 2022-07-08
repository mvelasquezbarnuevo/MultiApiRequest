namespace RequestConsole.Models
{
    public class JsonThreeRequest
    {
        public string? Consignee { get; set; }
        public string? Consignor { get; set; }
        public Carton[]? Cartons { get; set; }
    }

    public class Carton
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
