using FluentAssertions;
using MementoPattern;

namespace MementoPatternTests;

public class DocumentTests
{
    [Fact]
    public void Document_works()
    {
        var document = new Document();

        document.SetContent("Some stuff");
        document.GetContent().Should().Be("Some stuff");

        document.CreateState();
        document.SetContent("Something not good");
        document.GetContent().Should().Be("Something not good");

        document.RestoreState();
        document.GetContent().Should().Be("Some stuff");
    }
}
