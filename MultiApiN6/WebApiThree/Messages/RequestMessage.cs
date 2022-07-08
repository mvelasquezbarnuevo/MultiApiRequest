namespace WebApiThree.Messages;

public class RequestMessage
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