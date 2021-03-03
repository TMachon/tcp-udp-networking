using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class UnityNumericsConversion : MonoBehaviour
{
    #region Unity to Numerics
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
    #endregion

    #region Numerics to Unity
    public static System.Numerics.Vector3 getVector(UnityEngine.Vector3 _vector)
    {
        float _posX = _vector.x;
        float _posY = _vector.y;
        float _posZ = _vector.z;
        return new System.Numerics.Vector3(_posX, _posY, _posZ);
    }

    public static System.Numerics.Quaternion getQuaternion(UnityEngine.Quaternion _quaternion)
    {
        float _rotX = _quaternion.x;
        float _rotY = _quaternion.y;
        float _rotZ = _quaternion.z;
        float _rotW = _quaternion.w;
        return new System.Numerics.Quaternion(_rotX, _rotY, _rotZ, _rotW);
    }
    #endregion
}
