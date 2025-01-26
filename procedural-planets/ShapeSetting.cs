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

    private float _strength = 1;
    [Export]
    public float strength
    {
        get => _strength;
        set
        {
            _strength = value;
            EmitChanged();
        }
    }

    private int _numLayers = 1;
    [Export]
    public int numLayers
    {
        get => _numLayers;
        set
        {
            _numLayers = value;
            EmitChanged();
        }
    }

    private float _baseRoughness = 1;
    [Export]
    public float baseRoughness
    {
        get => _baseRoughness;
        set
        {
            _baseRoughness = value;
            EmitChanged();
        }
    }

    private float _roughness = 2;
    [Export]
    public float roughness
    {
        get => _roughness;
        set
        {
            _roughness = value;
            EmitChanged();
        }
    }

    private float _persistence = .5f;
    [Export]
    public float persistence
    {
        get => _persistence;
        set
        {
            _persistence = value;
            EmitChanged();
        }
    }

    private Vector3 _offset;
    [Export]
    public Vector3 offset
    {
        get => _offset;
        set
        {
            _offset = value;
            EmitChanged();
        }
    }

    private float _minValue;
    [Export]
    public float minValue
    {
        get => _minValue;
        set
        {
            _minValue = value;
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
