
using static System.Net.Mime.MediaTypeNames;

namespace Lakeshore.SendUnplannedReturn.Dto.SendUnplannedReturn;

public class UnplannedReturnDto
{
    public UnplannedReturn UnplannedReturn { get; set; } = new UnplannedReturn();
}

public class UnplannedReturn
{
    public int DeliveryDocument { get; set; }
    public string? RecordType { get; set; }
    public string? BillToNumber { get; set; }
    public string? BillToName { get; set; }
    public string? BillToAddress1 { get; set; }
    public string? BillToAddress2 { get; set; }
    public string? BillToAddress3 { get; set; }
    public string? BillToAddress4 { get; set; }
    public string? BillToCity { get; set; }
    public string BillToState { get; set; } = string.Empty;
    public string? BillToZip9 { get; set; }
    public string? BillToCountry { get; set; }
    public string ShipToNumber { get; set; } = string.Empty;
    public string? ShipToName { get; set; }
    public string ShiptoAddress1 { get; set; } = string.Empty;
    public string? ShipToAddress2 { get; set; }
    public string? ShipToAddress3 { get; set; }
    public string ShipToAddress4 { get; set; } = string.Empty;
    public string? ShipToCity { get; set; }
    public string ShipToState { get; set; } = string.Empty;
    public string? ShipToZip9 { get; set; }
    public string? ShipToCountry { get; set; }
    public List<Item> Item { get; set; } = new List<Item>();
}

public class Item
{
    public string MaterialNumber { get; set; } = string.Empty;
    public string? UnitsReturned { get; set; }
    public string NegativeIndicator { get; set; }
    public string ReasonCode { get; set; }
    public string Invclass { get; set; }
    public string? Container { get; set; }
    public string? Comments { get; set; }
    public string? FifoLayer { get; set; }
    public string? Orderline { get; set; }
    public string UnscheduledFlag { get; set; } = string.Empty;
    public string? FinalFlag { get; set; }
    public string? WMSStagingArea { get; set; }
    public List<Text> Text { get; set; } = new List<Text>();
}

public class Text
{
    public string Language { get; set; }
    public string? LongTextID { get; set; }
    public string LongText { get; set; } = string.Empty;
}

