using Godot;
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
        set { _resolution = value; Run(); }
    }

    private ColorSetting _ColorSetting;
    [Export]
    public ColorSetting ColorSetting
    {
        get => _ColorSetting;
        set
        {
            _ColorSetting = value;
            _ColorSetting.Changed += ColorSetting_Changed;
        }
    }

    private ShapeSetting _shapeSetting;
    [Export]
    public ShapeSetting shapeSetting
    {
        get => _shapeSetting;
        set
        {
            _shapeSetting = value;
            _shapeSetting.Changed += ShapeSetting_Changed;
        }
    }

    TerrainFace[] terrainFaces;

    private ShapeGenerator ShapeGenerator;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        Run();
    }

    private void Run()
    {
        Initialize();
        GenerateMesh();
        GenerateColor();
    }

    private void ColorSetting_Changed()
    {
        //Initialize();
        //GenerateColor();
        Run();
    }

    private void ShapeSetting_Changed()
    {
        //Initialize();
        //GenerateMesh();
        Run();
    }

    private void Initialize()
    {
        ShapeGenerator = new ShapeGenerator(shapeSetting);

        ArrayMesh mesh = new ArrayMesh();
        terrainFaces = new TerrainFace[6];

        Vector3[] directions = { Vector3.Up, Vector3.Down, Vector3.Left, Vector3.Right, Vector3.Forward, Vector3.Back };

        for (int i = 0; i < 6; i++)
        {
            terrainFaces[i] = new TerrainFace(ShapeGenerator, mesh, Resolution, directions[i]);
        }

        this.Mesh = mesh;
    }

    private void GenerateMesh()
    {
        foreach (var face in terrainFaces)
        {
            face.ConstructMesh();
        }
    }

    private void GenerateColor()
    {
        if (ColorSetting != null)
        {
            for (int i = 0; i < 6; i++)
            {
                StandardMaterial3D material = (StandardMaterial3D)Mesh.SurfaceGetMaterial(i);
                if (material == null)
                {
                    material = new StandardMaterial3D();
                }

                material.AlbedoColor = ColorSetting.planetColor;
            
                Mesh.SurfaceSetMaterial(i, material);
            }
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}
