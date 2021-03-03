using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSend : MonoBehaviour
{
    private static void SendTCPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.instance.tcp.SendData(_packet);
    }
	
	private static void SendUDPData(Packet _packet)
	{
		_packet.WriteLength();
		Client.instance.udp.SendData(_packet);
	}

    public static void WelcomeReceived()
    {
        using (Packet _packet = new Packet((int)ClientPackets.welcomeReceived))
        {
            _packet.Write(Client.instance.myId);
            _packet.Write(UIManager.instance.usernameField.text);

            SendTCPData(_packet);
        }
    }
	
	public static void PlayerMovement(bool[] _inputs)
    {
        using (Packet _packet = new Packet((int)ClientPackets.playerMovement))
        {
            _packet.Write(_inputs.Length);
            foreach (bool _input in _inputs)
            {
                _packet.Write(_input);
            }

            UnityEngine.Quaternion _gameRot = GameManager.players[Client.instance.myId].transform.rotation;
            float _rotX = _gameRot.x;
            float _rotY = _gameRot.y;
            float _rotZ = _gameRot.z;
            float _rotW = _gameRot.w;
            System.Numerics.Quaternion _rotation = new System.Numerics.Quaternion(_rotX, _rotY, _rotZ, _rotW);
            _packet.Write(_rotation);

            SendUDPData(_packet);
        }
    }
}
