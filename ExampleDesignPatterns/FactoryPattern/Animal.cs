namespace FactoryPattern;

public class AnimalFactory
{
    public Animal Create<T>() where T : Animal, new() => new T();

    //Better but there is an even better way
    //public Animal Create(string type)
    //{
    //    var actualType = Type.GetType($"FactoryPattern.{type}");

    //    return (Animal)Activator.CreateInstance(actualType);
    //}

    //very naive - but it's the first approach - it violates OCP (Open-closed principle)
    //public Animal Create(string type) => type switch
    //{
    //    "Dog" => new Dog(),
    //    "Cat" => new Cat(),
    //    "Horse" => new Horse(),
    //    "Monkey" => new Monkey(),
    //    _ => throw new ArgumentOutOfRangeException(),
    //};
}

public abstract class Animal
{
    public abstract string MakeNoise();
}

public class Dog : Animal
{
    public override string MakeNoise() => "Hau hau";
}

public class Cat : Animal
{
    public override string MakeNoise() => "Miał miał";
}

public class Horse : Animal
{
    public override string MakeNoise() => "Patatataj";
}

public class Monkey : Animal
{
    public override string MakeNoise() => "Uuuaaaa";
}