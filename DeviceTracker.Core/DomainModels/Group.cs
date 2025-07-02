using System;

namespace DeviceTracker.Core.DomainModels;
public class Group : DomainBase
{
    public int Id { get; private set; }

    private string? _name;
    public string Name
    {
        get => _name!;
        set => _name = !string.IsNullOrEmpty(value) ? value : throw new ArgumentNullException(Name);
    }

    public IList<IotDevice>? IotDevices { get; private set; }
    public Group(string name)
    {
        Name = name;
    }

    public Group(int id, string name) : this(name)
    {
        Id = id;
    }

    internal Group()
    {
    }
}
