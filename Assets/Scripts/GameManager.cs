using UnityEngine;

public class GameManager : MonoBehaviour
{
    public RoomSpawner roomSpawner;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            roomSpawner.SpawnNewRoom();
        }
    }
}