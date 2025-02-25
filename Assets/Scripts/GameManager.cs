using UnityEngine;

public class GameManager : MonoBehaviour
{
    public RoomSpawner roomSpawner;
    public static GameManager Instance;
    void Awake()
    {
        // Zorg voor een enkelvoudige instantie van de GameManager
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void OnPlayerTriggered()
    {
        roomSpawner.SpawnNewRoom();
    }
    // private void Update()
    // {
    //     if (roomSpawner.walkthroughZone == ColliderHit)
    //     {
    //         roomSpawner.SpawnNewRoom();
    //     }
    // }
}