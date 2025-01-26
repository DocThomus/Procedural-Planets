
using Godot;

public partial class ShapeGenerator
{
    private ShapeSetting ShapeSetting { get; set; }

    public ShapeGenerator(ShapeSetting shapeSetting)
    {
        ShapeSetting = shapeSetting;
    }

    public Vector3 CalculatePointOnPlanet(Vector3 pointOnSphere)
    {
        return pointOnSphere * ShapeSetting.planetRadius;
    }

}
