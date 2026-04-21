namespace RoofBlockCalculator;

/// <summary>
/// Computes the volume of a Triangular Roof Block Solid.
/// The solid is a composite of two primitive solids:
///   1. A rectangular prism (the main block / building body)
///   2. A triangular prism (the roof on top)
/// </summary>
public static class VolumeCalculator
{
    // Volume of a rectangular prism:  V = l * w * h
    public static double RectangularPrismVolume(double length, double width, double height)
    {
        if (length < 0 || width < 0 || height < 0)
            throw new ArgumentException("Dimensions must be non-negative.");

        return length * width * height;
    }

    // Volume of a triangular prism:  V = (1/2) * b * h * L
    public static double TriangularPrismVolume(double baseLength, double triHeight, double prismLength)
    {
        if (baseLength < 0 || triHeight < 0 || prismLength < 0)
            throw new ArgumentException("Dimensions must be non-negative.");

        return 0.5 * baseLength * triHeight * prismLength;
    }

    // Total volume of the composite solid.
    public static CompositeResult TotalVolume(
        double l1, double w1, double h1,   // rectangular block
        double b2, double h2, double L2)   // triangular roof
    {
        double v1 = RectangularPrismVolume(l1, w1, h1);
        double v2 = TriangularPrismVolume(b2, h2, L2);

        return new CompositeResult(v1, v2, v1 + v2);
    }
}

public record CompositeResult(double V1, double V2, double Total);
