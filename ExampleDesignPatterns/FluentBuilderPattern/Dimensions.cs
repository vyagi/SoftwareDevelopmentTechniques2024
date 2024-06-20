namespace FluentBuilder;

public struct Dimensions
{
    public Dimensions(int length, int width, int weight)
    {
        Length = length;
        Width = width;
        Weight = weight;
    }
    public int Length { get; internal set; }
    public int Width { get; internal set; }
    public int Weight { get; internal set; }
}
