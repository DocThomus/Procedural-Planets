using Godot;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Range = Godot.Range;

[Tool]
public partial class Planet : MeshInstance3D
{

    private int _resolution = 10;
    [Export, Range(2, 256)]
    public int Resolution
    {
        get { return _resolution; }
        set { _resolution = value; Generate(); }
    }

    TerrainFace[] terrainFaces;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        Generate();
    }

    private void Generate()
    {
        ArrayMesh mesh = new ArrayMesh();
        terrainFaces = new TerrainFace[6];

        Vector3[] directions = { Vector3.Up, Vector3.Down, Vector3.Left, Vector3.Right, Vector3.Forward, Vector3.Back };

        for (int i = 0; i < 6; i++)
        {
            terrainFaces[i] = new TerrainFace(mesh, Resolution, directions[i]);
        }

        foreach (var face in terrainFaces)
        {
            face.ConstructMesh();
        }

        this.Mesh = mesh;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}
