using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCube : MonoBehaviour
{
    public int cubeId;
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;

    public void Initialize(int _cubeId, Vector3 _position, Quaternion _rotation, Vector3 _scale)
    {
        cubeId = _cubeId;
        position = _position;
        rotation = _rotation;
        scale = _scale;
    }
}
