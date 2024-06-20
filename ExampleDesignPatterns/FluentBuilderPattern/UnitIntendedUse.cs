using FluentBuilder;

public class UnitIntendedUse
{
    public UnitIntendedUse(TypeOfUse typeOfUse, string lineOfBusiness, string unitPurpose)
    {
        TypeOfUse = typeOfUse;
        LineOfBusiness = lineOfBusiness;
        UnitPurpose = unitPurpose;
    }

    public TypeOfUse TypeOfUse { get; internal set; }
    public string LineOfBusiness { get; internal set; }
    public string UnitPurpose { get; internal set; }
}

