namespace cw_4.Models;

public class Order
{
    private int IdOrder { get; set; }
    private int IdProduct { get; set; }
    private int Amount { get; set; }
    private DateTime CreatedAt { get; set; }
    private DateTime FullfilledAt { get; set; }
    
    
    
}