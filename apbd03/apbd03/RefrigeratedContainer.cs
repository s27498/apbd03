namespace apbd03;


public class RefrigeratedContainer : Container
{
    private string _serialNumber { get; set; }
    private float _temperature { get; set; }
    private string _productType { get; set; }

    public RefrigeratedContainer(float cargoWeight, float height, float ownWeight, float depth,
        float loadCapacity, string productType) : 
        base(cargoWeight, height, ownWeight, depth, loadCapacity)
    {
        _serialNumber = GenerateSerialNumber();
        _productType = productType;
        switch (productType)
        {
            case "Bananas":
                _temperature = (float)13.3;
                break;
            case "Chocolate":
                _temperature = 18;
                break;
            case "Fish":
                _temperature = 2;
                break;
            case "Meat":
                _temperature = -15;
                break;
            case "Ice_Cream":
                _temperature = -18;
                break;
            case "Frozen_pizza":
                _temperature = -30;
                break;
            case "Cheese":
                _temperature = (float)7.2;
                break;
            case "Sausages":
                _temperature = 5;
                break;
            case "Butter":
                _temperature = (float)20.5;
                break;
            case "Eggs":
                _temperature = 19;
                break;
            default:
                _temperature = 0;
                Console.WriteLine("The specified product is not available in the warehouse.");
                break;
        }
    }

    public override string ToString()
    {
        return base.ToString()
               + $"Temperature: {_temperature}, "
               + $"Product Type: {_productType}.";
    }

    public override string GenerateSerialNumber()
    {
        return "CON-" + "R" + "-" + i++;
    }
}
