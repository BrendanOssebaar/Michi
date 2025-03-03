using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;
    private readonly List<GameObject> _roomPool = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    public void InitializePool(GameObject[] rooms)
    {
        foreach (var room in rooms)
        {
            room.SetActive(false);
            _roomPool.Add(room);
        }
    }

    public GameObject GetRandomRoom()
    {
        if (_roomPool.Count == 0) return null;

        var randomIndex = Random.Range(0, _roomPool.Count);
        var room = _roomPool[randomIndex];

        room.SetActive(true);
        return room;
    }

    public static void ReturnRoom(GameObject room)
    {
        room.SetActive(false);
    }
}

