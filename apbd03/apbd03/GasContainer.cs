namespace apbd03;



public class GasContainer : Container , IHazardNotifier
{
    private string _serialNumber { get; set; }
    private double _pressure { get; set; }

    public GasContainer(float cargoWeight, float height, float ownWeight, float depth, float loadCapacity, double pressure) : 
        base(cargoWeight, height, ownWeight, depth, loadCapacity)
    {
        _pressure = pressure;
        _serialNumber = GenerateSerialNumber();
    }

    public override void EmptyContainer()
    {
        dangerNotifier();
        CargoWeight = (float)(CargoWeight * 0.05);
    }

    public override void LoadContainer(float loadedWeight)
    {
        base.LoadContainer(loadedWeight);
    }

    public override string GenerateSerialNumber()
    {
        return "CON-" + "G" + "-" + i++;
    }

    public override string ToString()
    {
        return base.ToString() +
               $" Pressure: {_pressure} hPa.";
    }

    public void dangerNotifier()
    {
        Console.WriteLine("Container: " + ToString() + "\nStill contains gas!");
    }
}
