namespace cw_4.Models;

public class Product_Warehouse
{
    private int IdProductWarehouse { get; set; }
    private int IdWarehouse { get; set; }
    private int IdProduct { get; set; }
    private int IdOrder { get; set; }
    private int Amount { get; set; }
    private decimal Price { get; set; }
    private DateTime CreatedAt { get; set; }
}