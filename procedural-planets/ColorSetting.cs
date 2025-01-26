using Godot;
using System;

[GlobalClass, Tool]
public partial class ColorSetting : Resource
{
    private Color _planetColor;

    [Export]
    public Color planetColor
    {
        get => _planetColor;
        set
        {
            _planetColor = value;
            EmitChanged();
        }
    }
}
