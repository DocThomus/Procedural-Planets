
using Godot;
using System;

[Tool]
public partial class ShapeGenerator
{
    private ShapeSetting settings { get; set; }

    public ShapeGenerator(ShapeSetting shapeSetting)
    {
        settings = shapeSetting;
    }

    public Vector3 CalculatePointOnPlanet(Vector3 pointOnSphere)
    {
        float elevation = Evaluate(pointOnSphere);
        return pointOnSphere * settings.planetRadius * (1+elevation);
    }

    public float Evaluate(Vector3 point)
    {
        float noiseValue = 0;
        float frequency = settings.baseRoughness;
        float amplitude = 1;

        for (int i = 0; i < settings.numLayers; i++)
        {
            float v = settings.Noise.GetNoise3Dv(point * frequency + settings.offset);
            noiseValue += (v + 1) * .5f * amplitude;
            frequency *= settings.roughness;
            amplitude *= settings.persistence;
        }

        noiseValue = Mathf.Max(0, noiseValue - settings.minValue);
        return noiseValue * settings.strength;
    }

}
