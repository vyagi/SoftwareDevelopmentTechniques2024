using FluentBuilder;
using FluentBuilderPattern;

var unit = MarineUnitBuilder
    .Initialize()
    .WithName("Cindy")
    .WithIntendedUse(new UnitIntendedUse(TypeOfUse.MarineCommercial, "Fishing", "Salmon"))
    .WithDimension(new Dimensions(100, 100, 100))
    .WithMechanicalInstallation(new MechanicalInstallation())
    .WithVersatileInstallation(new VersatileInstallation())
    .WithElectricaInstallation(new ElectricalInstallation())
    .WithElectricaInstallation(new ElectricalInstallation())
    .WithElectricaInstallation(new ElectricalInstallation())
    .WithNoMoreElectricaInstallation()
    .WithBrandAndModel("Mercedes", "Seastorm")
    .Build();


    /*
.Initialize()
    .WithName("Cindy")
    .WithIntendedUse(new UnitIntendedUse(TypeOfUse.MarineCommercial, "Fishing", "Salmon"))
    .WithDimension(new Dimensions(100, 100, 100))
    //WE WILL ADD MORE
    .Build();
*/

//Now I cannot produce shit ;-)

//var unit = new MarineUnit()
//{
//    Brand = "Some invalid brand",
//    ElectricalInstallation = null,
//    Model = "Some shit",

//};