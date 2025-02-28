using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;
    private List<GameObject> roomPool = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    public void InitializePool(GameObject[] rooms)
    {
        foreach (GameObject room in rooms)
        {
            room.SetActive(false);
            roomPool.Add(room);
        }
    }

    public GameObject GetRandomRoom()
    {
        if (roomPool.Count == 0) return null;

        int randomIndex = Random.Range(0, roomPool.Count);
        GameObject room = roomPool[randomIndex];

        room.SetActive(true);
        return room;
    }

    public void ReturnRoom(GameObject room)
    {
        room.SetActive(false);
    }
}

