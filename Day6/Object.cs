public class Object
{
    public string Name { get; set; }
    public string? OrbitsObjectName { get; set; }
    public List<Object> ConnectedObjects { get; set; } = new List<Object>();

    public Object(string Name, string? OrbitsObjectName)
    {
        this.Name = Name;
        this.OrbitsObjectName = OrbitsObjectName;
    }
}