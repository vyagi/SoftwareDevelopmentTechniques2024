using FluentBuilder;

public class MarineUnit
{
    internal MarineUnit() { }

    public string UnitName { get; internal set; }

    public UnitIntendedUse UnitIntendedUse { get; internal set; }

    public Dimensions Dimensions { get; internal set; }

    public MechanicalInstallation MechanicalInstallation { get; internal set; }

    public VersatileInstallation VersatileInstallation { get; internal set; }

    public ElectricalInstallation[] ElectricalInstallation { get; internal set; }

    public string Brand { get; internal set; }

    public string Model { get; internal set; }

    //Other methods...
}

