using FactoryPattern;
using FluentAssertions;

namespace FactoryPatternTests;

public class AnimalTests
{
    [Fact]
    public void Factory_returns_proper_animals()
    {
        var animalFactory = new AnimalFactory();

        animalFactory.Create<Dog>().Should().BeOfType<Dog>();
        animalFactory.Create<Cat>().Should().BeOfType<Cat>();
        animalFactory.Create<Horse>().Should().BeOfType<Horse>();
        animalFactory.Create<Monkey>().Should().BeOfType<Monkey>();
    }

    //[Fact]
    //public void Factory_returns_proper_animals()
    //{
    //    var animalFactory = new AnimalFactory();

    //    animalFactory.Create("Dog").Should().BeOfType<Dog>();
    //    animalFactory.Create("Cat").Should().BeOfType<Cat>();
    //    animalFactory.Create("Horse").Should().BeOfType<Horse>();
    //    animalFactory.Create("Monkey").Should().BeOfType<Monkey>();
    //}
}