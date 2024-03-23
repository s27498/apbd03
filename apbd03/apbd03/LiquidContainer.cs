namespace apbd03;


public class LiquidContainer : Container, IHazardNotifier
{
    private string _serialNumber { get; set; }
    private string _cargoType { get; set; }

    public LiquidContainer(float cargoWeight, float height, float ownWeight, float depth, float loadCapacity,
        string cargoType)
        : base(cargoWeight, height, ownWeight, depth, loadCapacity)
    {
        _cargoType = cargoType;
        _serialNumber = GenerateSerialNumber();
    }

    public void dangerNotifier()
    {
        Console.WriteLine("Container: " + ToString() + "\nMay be endangered by excessive load");
    }

    public override string GenerateSerialNumber()
    {
        return "CON-" + "L" + "-" + i++;
    }

    public override void LoadContainer(float loadedWeight)
    {
        if (_cargoType.Equals("dangerous") && loadedWeight + CargoWeight > LoadCapacity * 0.5)
        {
            dangerNotifier();
        }

        if (_cargoType.Equals("safe") && loadedWeight + CargoWeight > LoadCapacity * 0.9)
        {
            dangerNotifier();
        }

        base.LoadContainer(loadedWeight);
    }

    public override void EmptyContainer()
    {
        base.EmptyContainer();
    }

    public override string ToString()
    {
        return base.ToString() + $" Cargo Type: {_cargoType}.";
    }
}
