using Godot;
using System;

[GlobalClass, Tool]
public partial class ShapeSetting : Resource
{
    private float _planetRadius = 1;
    [Export]
    public float planetRadius
    {
        get => _planetRadius;
        set
        {
            _planetRadius = value;
            EmitChanged();
        }
    }

    private FastNoiseLite _Noise = GD.Load<FastNoiseLite>("res://PlanetSettings/Noise.tres");
    [Export]
    public FastNoiseLite Noise
    {
        get => _Noise;
        set
        {
            _Noise = value;
            EmitChanged();
        }
    }
}
