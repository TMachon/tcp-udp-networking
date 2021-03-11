using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int id;
    public string username;
    public CharacterController controller;

    public void Initialize(int _id, string _username)
    {
        id = _id;
        username = _username;
    }

    public void Move(Vector3 _newPosition, Quaternion _newRotation)
    {
        this.transform.position = _newPosition;
        this.transform.rotation = _newRotation;
    }
}
