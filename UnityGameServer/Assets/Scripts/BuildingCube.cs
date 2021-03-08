using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCube : MonoBehaviour
{
    public static Dictionary<int, BuildingCube> cubes = new Dictionary<int, BuildingCube>();
    
    private static int nextCubeId = 1;
    public int cubeId;

    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;


    void Start()
    {
        cubeId = nextCubeId;
        nextCubeId++;
        position = this.transform.position;
        rotation = this.transform.rotation;
        scale = this.transform.localScale;
        cubes.Add(cubeId, this);
    }
}
