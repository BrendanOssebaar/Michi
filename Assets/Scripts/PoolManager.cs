using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;
    private List<GameObject> _roomPool = new List<GameObject>();
    [SerializeField] private GameObject background;
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
        background.SetActive(false);
        int randomIndex = Random.Range(0, _roomPool.Count);
        GameObject room = _roomPool[randomIndex];

        room.SetActive(true);
        return room;
    }

    public static void ReturnRoom(GameObject room)
    {
        room.SetActive(false);
    }
}

