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
}
