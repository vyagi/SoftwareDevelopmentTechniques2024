using FluentBuilder;

namespace FluentBuilderPattern;

public class MarineUnitBuilder : INameSetter, 
    IIntendedUseSetter, 
    IDimensionsSetter, 
    IMechanicalInstallationsSetter, 
    IVersatileInstallationsSetter, 
    IElectricalInstallationsSetter, 
    IBrandAndModelSetter, 
    IMarineUnitBuilder
{
    private readonly MarineUnit _unit = new();

    private readonly List<ElectricalInstallation> _electricalInstallations = new ();

    private MarineUnitBuilder() { }

    public static INameSetter Initialize() => new MarineUnitBuilder();

    public IIntendedUseSetter WithName(string name)
    {
        //Builder can validate if this is a proper name (according to some business rules)
        _unit.UnitName = name;
        return this;
    }

    public IDimensionsSetter WithIntendedUse(UnitIntendedUse intendedUse)
    {
        //validation
        _unit.UnitIntendedUse = intendedUse;
        return this;
    }

    public IMechanicalInstallationsSetter WithDimension(Dimensions dimensions)
    {
        //validation
        _unit.Dimensions = dimensions;
        return this;
    }

    public IVersatileInstallationsSetter WithMechanicalInstallation(MechanicalInstallation mechanicalInstallation)
    {
        _unit.MechanicalInstallation = mechanicalInstallation;
        return this;
    }

    public IElectricalInstallationsSetter WithVersatileInstallation(VersatileInstallation versatileInstallation)
    {
        _unit.VersatileInstallation = versatileInstallation;
        return this;
    }

    public IElectricalInstallationsSetter WithElectricaInstallation(ElectricalInstallation electricalInstallation)
    {
        _electricalInstallations.Add(electricalInstallation);

        return this;    
    }

    public IBrandAndModelSetter WithNoMoreElectricaInstallation()
    {
        _unit.ElectricalInstallation = _electricalInstallations.ToArray();

        return this;
    }

    public IMarineUnitBuilder WithBrandAndModel(string brand, string model)
    {
        _unit.Brand = brand;
        _unit.Model = model;

        return this;
    }

    public MarineUnit Build() => _unit;
}

public interface INameSetter
{
    IIntendedUseSetter WithName(string name);
}

public interface IIntendedUseSetter
{
    IDimensionsSetter WithIntendedUse(UnitIntendedUse intendedUse);
}

public interface IDimensionsSetter
{
    IMechanicalInstallationsSetter WithDimension(Dimensions dimensions);
}

public interface IMechanicalInstallationsSetter
{
    IVersatileInstallationsSetter WithMechanicalInstallation(MechanicalInstallation mechanicalInstallation);
}

public interface IVersatileInstallationsSetter
{
    IElectricalInstallationsSetter WithVersatileInstallation(VersatileInstallation versatileInstallation);
}

public interface IElectricalInstallationsSetter
{
    IElectricalInstallationsSetter WithElectricaInstallation(ElectricalInstallation electricalInstallation);

    IBrandAndModelSetter WithNoMoreElectricaInstallation();
}

public interface IBrandAndModelSetter
{
    IMarineUnitBuilder WithBrandAndModel(string brand, string model);
}

public interface IMarineUnitBuilder
{
    MarineUnit Build();
}