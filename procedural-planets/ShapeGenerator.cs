
using Godot;
using System;

[Tool]
public partial class ShapeGenerator
{
    private ShapeSetting ShapeSetting { get; set; }

    public ShapeGenerator(ShapeSetting shapeSetting)
    {
        ShapeSetting = shapeSetting;
    }

    public Vector3 CalculatePointOnPlanet(Vector3 pointOnSphere)
    {
        float elevation = Evaluate(pointOnSphere);
        return pointOnSphere * ShapeSetting.planetRadius * (1+elevation);
    }

    public float Evaluate(Vector3 point)
    {
        return (ShapeSetting.Noise.GetNoise3Dv(point) + 1) * .5f;
    }

}
