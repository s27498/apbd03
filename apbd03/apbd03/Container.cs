namespace apbd03;


public class Container
{
    private float _cargoWeight;
    private float _height;

    private float _ownWeight;
    private float _depth;
    private string _serialNumber;

    private float _loadCapacity;

    public static int i;

    public Container(float cargoWeight, float height, float ownWeight, float depth, float loadCapacity)
    {
        _cargoWeight = cargoWeight;
        _height = height;
        _ownWeight = ownWeight;
        _depth = depth;
        _loadCapacity = loadCapacity;
        _serialNumber = GenerateSerialNumber();
    }

    public virtual void EmptyContainer()
    {
        _cargoWeight = 0;
    }

    public virtual void LoadContainer(float loadedWeight)
    {
        if (_cargoWeight + loadedWeight > _loadCapacity)
        {
            throw new OverflowException("You are trying to load too much");
        }
        else
        {
            _cargoWeight += loadedWeight;
        }
    }

    public virtual string GenerateSerialNumber()
    {
        return "CON" + "-" + "ABSTRACT" + "-" + i++;
    }

    public override string ToString()
    {
        return $"Serial Number: {_serialNumber}, " +
               $"Cargo Weight: {_cargoWeight} kg, " +
               $"Height: {_height} cm, " +
               $"Own Weight: {_ownWeight} kg, " +
               $"Depth: {_depth} cm, " +
               $"Load Capacity: {_loadCapacity} kg, ";
    }

    public float CargoWeight
    {
        get => _cargoWeight;
        set => _cargoWeight = value;
    }

    public float Height
    {
        get => _height;
        set => _height = value;
    }

    public float OwnWeight
    {
        get => _ownWeight;
        set => _ownWeight = value;
    }

    public float Depth
    {
        get => _depth;
        set => _depth = value;
    }

    public string SerialNumber
    {
        get => _serialNumber;
        set => _serialNumber = value;
    }

    public float LoadCapacity
    {
        get => _loadCapacity;
        set => _loadCapacity = value;
    }
}
