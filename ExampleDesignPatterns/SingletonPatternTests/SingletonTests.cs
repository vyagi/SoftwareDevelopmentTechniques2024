using FluentAssertions;
using SingletonPattern;

namespace SingletonPatternTests;

public class SingletonTests
{
    [Fact]
    public void Singleton_can_be_created()
    {
        var singleton = Singleton.GetInstance();

        singleton.Should().NotBeNull();
    }

    [Fact]
    public void GetInstance_called_twice_get_always_the_same_singleton()
    {
        var singleton1 = Singleton.GetInstance();
        var singleton2 = Singleton.GetInstance();

        singleton1.CreatedAt.Should().Be(singleton2.CreatedAt);

        ReferenceEquals(singleton1, singleton2).Should().BeTrue();
    }

    [Fact]
    public void GetInstance_called_twice_get_always_the_same_singleton_in_multithreaded_app()
    {
        Singleton singleton1 = null;
        Singleton singleton2 = null;

        Task task1 = Task.Factory.StartNew(() => singleton1 = Singleton.GetInstance());
        Task task2 = Task.Factory.StartNew(() => singleton2 = Singleton.GetInstance());

        Task.WaitAll(task1, task2);

        singleton1.CreatedAt.Should().Be(singleton2.CreatedAt);

        ReferenceEquals(singleton1, singleton2).Should().BeTrue();
    }
}