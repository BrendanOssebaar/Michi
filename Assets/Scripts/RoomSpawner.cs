using System.Collections;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public GameObject[] preMadeRooms; 
    private GameObject _currentRoom; 
    [SerializeField]public float roomOffset; 
    public float roomDeactivateDelay = 5f;

    private void Start()
    {
        PoolManager.Instance.InitializePool(preMadeRooms);
    }

    // Nieuwe methode met een Transform-parameter van de triggerbox
    public void SpawnNewRoom(Transform triggerTransform)
    {
        // Bepaal de spawnpositie op basis van de positie en 'up' richting van de triggerbox
        Vector2 spawnPosition = (Vector2)triggerTransform.position + (Vector2)triggerTransform.up * roomOffset;
        
        // Indien er al een huidige room is, plan de deactivering
        if (_currentRoom != null)
        {
            StartCoroutine(DeactivateRoomAfterDelay(_currentRoom, roomDeactivateDelay));
        }
        
        // Haal een willekeurige room uit de pool en plaats hem
        _currentRoom = PoolManager.Instance.GetRandomRoom();
        if (_currentRoom != null)
        {
            _currentRoom.transform.position = spawnPosition;
            // Optioneel: als je ook de rotatie wilt meegeven:
            _currentRoom.transform.rotation = Quaternion.Euler(0,0,0);
        }
    }

    private IEnumerator DeactivateRoomAfterDelay(GameObject room, float delay)
    {
        yield return new WaitForSeconds(delay);
        PoolManager.Instance.ReturnRoom(room);
    }

    // Deze methode kun je eventueel gebruiken als je vanuit een script op de triggerbox wilt doorgeven
    public void HandleTrigger(Collider2D other, Transform triggerTransform)
    {
        Debug.Log("Collision detected");
        if(other.CompareTag("Player"))
        {
            // Laat de GameManager de nieuwe room spawnen met de triggerbox als referentie
            GameManager.Instance.OnPlayerTriggered(triggerTransform);
        }
    }
}