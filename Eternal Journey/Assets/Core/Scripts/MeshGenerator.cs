/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;


[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour {

    Mesh mesh;
    Vector3[] verticies;
    int[] triangles;
    Color[] colors;
    Slider perlinSlider;

    private float minTerrainHeight;
    private float maxTerrainHeight;
    private string path = "Assets/Terrain/Meshes/";

    public string meshName;
    public int xSize = 20;
    public int zSize = 20;
    public float perlinFactor = 1f;
    public Gradient gradient;
    
    void Start() {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshCollider>().sharedMesh = mesh;
        CreateShape();
    }

    public void SliderPerlin(float val) {
        perlinFactor = val;
    }

    public void GenerateNewMesh() {
        mesh.Clear();
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshCollider>().sharedMesh = mesh;
        CreateShape();
    }

    public void SaveMesh() {
        AssetDatabase.CreateAsset(mesh, path + meshName + ".mesh");
        AssetDatabase.SaveAssets();
    }

    void Update() {
        UpdateMesh();
    }

    void CreateShape() {
        verticies = new Vector3[(xSize + 1) * (zSize + 1)];
        for (int i = 0, z = 0; z <= zSize; z++) {
            for (int x = 0; x <= xSize; x++) {
                float y = Mathf.PerlinNoise(x * 0.3f, z * 0.3f) * perlinFactor;
                verticies[i] = new Vector3(x, y, z);
                if (y > maxTerrainHeight)
                    maxTerrainHeight = y;
                if (y < minTerrainHeight)
                    minTerrainHeight = y;
                i++;
            }
        }
        triangles = new int[xSize * zSize * 6];
        int vert = 0;
        int tris = 0;
        for (int z = 0; z < zSize; z++) {
            for (int x = 0; x < xSize; x++) {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;
                vert++;
                tris += 6;
            }
            vert++;
        }
        colors = new Color[verticies.Length];
        for (int i = 0, z = 0; z <= zSize; z++) {
            for (int x = 0; x <= xSize; x++) {
                float height = Mathf.InverseLerp(minTerrainHeight, maxTerrainHeight, verticies[i].y);
                colors[i] = gradient.Evaluate(height);
                i++;
            }
        }
    }

    void UpdateMesh() {
        mesh.Clear();
        mesh.vertices = verticies;
        mesh.triangles = triangles;
        mesh.colors = colors;
        mesh.RecalculateNormals();
    }
}*/
