using UnityEngine;

public class GameManager : MonoBehaviour
{
    public RoomSpawner roomSpawner;
    public static GameManager Instance;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    // Nieuwe methode die de triggerbox's transform doorgeeft
    public void OnPlayerTriggered(Transform triggerTransform)
    {
        roomSpawner.SpawnNewRoom(triggerTransform);
    }
}