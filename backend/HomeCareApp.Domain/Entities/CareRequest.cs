namespace HomeCareApp.Domain.Entities;

public class CareRequest // Created by client
{
    public Guid Id { get; set; }
    public Guid ClientId { get; set; }
    public DateTime RequestedDate { get; set; }
    public string ServiceType { get; set; } =  string.Empty;
    public string Notes { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
}