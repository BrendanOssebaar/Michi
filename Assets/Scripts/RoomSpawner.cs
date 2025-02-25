using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class RoomSpawner : MonoBehaviour
{
    public GameObject[] preMadeRooms; 
    private GameObject _currentRoom; 
    private GameObject _previousRoom; 
    public float roomOffsetX = 10f; 
    public float roomOffsetY = 10f; 
    public float roomOffsetZ = 10f; 
    public float roomDeactivateDelay = 5f;
    public GameObject walkthroughZone;
    private void Start()
    {
        PoolManager.Instance.InitializePool(preMadeRooms);
    }

    public void SpawnNewRoom()
    {
        Vector3 spawnPosition = Vector3.zero;
        if (_currentRoom != null)
        {
            
            spawnPosition = _currentRoom.transform.position + new Vector3(roomOffsetX, roomOffsetY, roomOffsetZ); // Verplaats naar rechts
            StartCoroutine(DeactivateRoomAfterDelay(_currentRoom, roomDeactivateDelay));
        }
        
        _currentRoom = PoolManager.Instance.GetRandomRoom();
        if (_currentRoom != null)
        {
            _currentRoom.transform.position = spawnPosition;
        }
    }
    private IEnumerator DeactivateRoomAfterDelay(GameObject room, float delay)
    {
        yield return new WaitForSeconds(delay);
        PoolManager.Instance.ReturnRoom(room);
    }
    void OnTriggerEnter(Collider other)
    {
        // Bijvoorbeeld: controleer of het de speler is via de tag
        if(other.CompareTag("Player"))
        {
            // Verwijs naar de GameManager en roep een methode aan
            GameManager.Instance.OnPlayerTriggered();
        }
    }
}