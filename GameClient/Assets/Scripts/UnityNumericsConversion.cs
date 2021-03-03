using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityNumericsConversion : MonoBehaviour
{
    public static UnityEngine.Vector3 getVector(System.Numerics.Vector3 _vector)
	{
        float _posX = _vector.X;
        float _posY = _vector.Y;
        float _posZ = _vector.Z;
        return new UnityEngine.Vector3(_posX, _posY, _posZ);
	}
	
	public static UnityEngine.Quaternion getQuaternion(System.Numerics.Quaternion _quaternion)
	{
        float _rotX = _quaternion.X;
        float _rotY = _quaternion.Y;
        float _rotZ = _quaternion.Z;
        float _rotW = _quaternion.W;
        return new UnityEngine.Quaternion(_rotX, _rotY, _rotZ, _rotW);
	}
}
