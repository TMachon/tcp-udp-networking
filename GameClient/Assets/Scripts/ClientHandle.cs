using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ClientHandle : MonoBehaviour
{
    public static void Welcome(Packet _packet)
    {
        string _msg = _packet.ReadString();
        int _myId = _packet.ReadInt();

        Debug.Log($"Message from server: {_msg}");
        Client.instance.myId = _myId;
        ClientSend.WelcomeReceived();
		
		Client.instance.udp.Connect(((IPEndPoint)Client.instance.tcp.socket.Client.LocalEndPoint).Port);
    }
	
	public static void SpawnPlayer(Packet _packet)
	{
		int _id = _packet.ReadInt();
		string _username = _packet.ReadString();

		System.Numerics.Vector3 _packetPosition = _packet.ReadVector3();
        float _posX = _packetPosition.X;
        float _posY = _packetPosition.Y;
        float _posZ = _packetPosition.Z;
        UnityEngine.Vector3 _position = new UnityEngine.Vector3(_posX, _posY, _posZ);

        System.Numerics.Quaternion _packetRotation = _packet.ReadQuaternion();
        float _rotX = _packetRotation.X;
        float _rotY = _packetRotation.Y;
        float _rotZ = _packetRotation.Z;
        float _rotW = _packetRotation.W;
        UnityEngine.Quaternion _rotation = new UnityEngine.Quaternion(_rotX, _rotY, _rotZ, _rotW);
		
		//TODO Use Unity Numerics Conversion

        GameManager.instance.SpawnPlayer(_id, _username, _position, _rotation);
	}
}