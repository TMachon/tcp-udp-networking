using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static Dictionary<int, PlayerManager> players = new Dictionary<int, PlayerManager>();
    public static Dictionary<int, ItemSpawner> spawners = new Dictionary<int, ItemSpawner>();

    public GameObject localPlayerPrefab;
    public GameObject playerPrefab;
    public GameObject itemSpawnerPrefab;

    public static Dictionary<int, BuildingCube> buildingCubes = new Dictionary<int, BuildingCube>();
    public GameObject buildingCubePrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    public void SpawnPlayer(int _id, string _username, Vector3 _position, Quaternion _rotation)
    {
        GameObject _player;
        if (_id == Client.instance.myId)
        {
            _player = Instantiate(localPlayerPrefab, _position, _rotation);
        }
        else
        {
            _player = Instantiate(playerPrefab, _position, _rotation);
        }

        _player.GetComponent<PlayerManager>().id = _id;
        _player.GetComponent<PlayerManager>().username = _username;
        players.Add(_id, _player.GetComponent<PlayerManager>());
    }

    public void CreateItemSpawner(int _spawnerId, Vector3 _position, bool _hasItem)
    {
        GameObject _spawner = Instantiate(itemSpawnerPrefab, _position, itemSpawnerPrefab.transform.rotation);
        _spawner.GetComponent<ItemSpawner>().Initialize(_spawnerId, _hasItem);
        spawners.Add(_spawnerId, _spawner.GetComponent<ItemSpawner>());
    }

    public void CreateBuildingCube(int _cubeId, Vector3 _position, Quaternion _rotation, Vector3 _scale)
    {
        GameObject _buildingCube = Instantiate(buildingCubePrefab, _position, _rotation);
        _buildingCube.transform.localScale = _scale;

        _buildingCube.GetComponent<BuildingCube>().Initialize(_cubeId, _position, _rotation, _scale);
        buildingCubes.Add(_cubeId, _buildingCube.GetComponent<BuildingCube>());
    }
}
