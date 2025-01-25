using Godot;
using System;

public partial class TerrainFace
{
    ArrayMesh mesh;
	int resolution;
	Vector3 normale;
    Vector3 tangentA;
    Vector3 tangentB;

    public TerrainFace(ArrayMesh mesh, int resolution, Vector3 normale)
    {
        this.mesh = mesh;
        this.resolution = resolution;
        this.normale = normale;

        tangentA = new Vector3(normale.Y, normale.Z, normale.X);
        tangentB = normale.Cross(tangentA);
    }

    public void ConstructMesh()
    {
        Vector3[] vertices = new Vector3[resolution * resolution];
        Vector3[] normals = new Vector3[resolution * resolution];
        int[] triangles = new int[(resolution - 1) * (resolution - 1) * 6];
        int j = 0;

        for (int y = 0; y < resolution; y++)
        {
            for (int x = 0; x < resolution; x++)
            {
                int i = x + y * resolution;
                Vector2 percent = new Vector2(x, y) / (resolution - 1);
                Vector3 pointOnUnitCube = normale + (percent.X - .5f) * 2 * tangentA + (percent.Y - .5f) * 2 * tangentB;
                vertices[i] = pointOnUnitCube;
                normals[i] = pointOnUnitCube.Normalized();

                if (x != resolution - 1 && y != resolution - 1)
                {
                    triangles[j] = i;
                    triangles[j + 1] = i + resolution;
                    triangles[j + 2] = i + resolution + 1;
                    triangles[j + 3] = i;
                    triangles[j + 4] = i + resolution + 1;
                    triangles[j + 5] = i + 1;

                    j += 6;
                }
            }
        }

        var surfaceArray = new Godot.Collections.Array();
        surfaceArray.Resize((int)Mesh.ArrayType.Max);

        surfaceArray[(int)Mesh.ArrayType.Vertex] = vertices;
        surfaceArray[(int)Mesh.ArrayType.Normal] = normals; // A tester, pas sûr que la génération soi bonne
        surfaceArray[(int)Mesh.ArrayType.Index] = triangles;

        mesh.AddSurfaceFromArrays(Mesh.PrimitiveType.Triangles, surfaceArray);
    }
}
