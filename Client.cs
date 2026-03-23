namespace Business;

public enum ClientType
{
    Physical = 0,
    Legal = 1
}

public class Client
{
    public string Name { get; }
    public ClientType Type { get; }

    public Client(string name, ClientType type)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Type = type;
    }
}

