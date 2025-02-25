using System.Collections;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public GameObject[] preMadeRooms; 
    private GameObject _currentRoom; 
    public float roomOffset = 5f; 
    public float roomDeactivateDelay = 5f;
    [SerializeField] private float roomSlideTime;

    private void Start()
    {
        PoolManager.Instance.InitializePool(preMadeRooms);
    }

    // Nieuwe SpawnNewRoom-methode die een triggerTransform verwacht
    public void SpawnNewRoom(Transform triggerTransform)
    {
        // Bereken de spawnpositie op basis van de triggerbox
        Vector2 spawnPosition = (Vector2)triggerTransform.position + (Vector2)triggerTransform.up * roomOffset;
        
        // Haal een willekeurige kamer op uit de pool
        GameObject newRoom = PoolManager.Instance.GetRandomRoom();
        if(newRoom != null)
        {
            newRoom.transform.position = spawnPosition;
            newRoom.transform.rotation = Quaternion.Euler(0,0,0);
            
            // Als er al een kamer in het centrum staat, start dan de overgang
            if (_currentRoom != null)
            {
                // Pass the triggerTransform to the TransitionRooms coroutine.
                StartCoroutine(TransitionRooms(newRoom, _currentRoom, triggerTransform));
            }
            else
            {
                // If there is no current room, simply slide the new room to center.
                StartCoroutine(SlideRoomToCenter(newRoom, triggerTransform));
            }
            
            // Stel de nieuwe kamer in als de huidige
            _currentRoom = newRoom;
        }
    }

    // Coroutine voor het naar het midden schuiven van een enkele kamer
    private IEnumerator SlideRoomToCenter(GameObject room, Transform triggerTransform)
    {
        Vector3 centerPosition = GetCameraCenter();
        Vector3 startPos = room.transform.position;
        float duration = 1f;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            room.transform.position = Vector3.Lerp(startPos, centerPosition, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        room.transform.position = centerPosition;
        // Also reposition the player.
        if (GameManager.Instance.playerTransform != null)
        {
            GameManager.Instance.playerTransform.position = centerPosition + (Vector3)(triggerTransform.up * GameManager.Instance.playerDoorOffset);
        }
    }

    // Coroutine voor het gelijktijdig verplaatsen van de nieuwe kamer naar het centrum en de oude kamer weg
    private IEnumerator TransitionRooms(GameObject newRoom, GameObject oldRoom, Transform triggerTransform)
    {
        Vector3 centerPosition = GetCameraCenter();
        Vector3 newRoomStart = newRoom.transform.position;
        Vector3 oldRoomStart = oldRoom.transform.position;
        Vector3 displacement = centerPosition - newRoomStart;
        Vector3 oldRoomTarget = oldRoomStart + displacement;
        Transform player = GameManager.Instance.playerTransform;
        Vector3 playerStart = player.position;
        // The target position: center of the new room plus an offset in the trigger's up direction.
        Vector3 playerTarget = centerPosition + (Vector3)(-triggerTransform.up * GameManager.Instance.playerDoorOffset)+Vector3.back;

        float duration = roomSlideTime;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            float t = elapsed / duration;
            newRoom.transform.position = Vector3.Lerp(newRoomStart, centerPosition, t);
            oldRoom.transform.position = Vector3.Lerp(oldRoomStart, oldRoomTarget, t);
            
            float playerT = t * 0.99f;
            player.position = Vector3.Lerp(playerStart, playerTarget, playerT);
            
            elapsed += Time.deltaTime;
            yield return null;
        }
        newRoom.transform.position = centerPosition;
        oldRoom.transform.position = oldRoomTarget;
        
        Vector3 playerCurrent = player.position;
        float extraDuration = 0f; // Adjust this duration to taste.
        float extraElapsed = 0f;
        while (extraElapsed < extraDuration)
        {
            float extraT = extraElapsed / extraDuration;
            player.position = Vector3.Lerp(playerCurrent, playerTarget, extraT);
            extraElapsed += Time.deltaTime;
            yield return null;
        }
        player.position = playerTarget;

        
        StartCoroutine(DeactivateRoomAfterDelay(oldRoom, roomDeactivateDelay));
    }

    private IEnumerator DeactivateRoomAfterDelay(GameObject room, float delay)
    {
        yield return new WaitForSeconds(delay);
        PoolManager.Instance.ReturnRoom(room);
    }

    // Hulpfunctie om het midden van de camera in wereldcoördinaten te bepalen
    private Vector3 GetCameraCenter()
    {
        // De camera is vaak orthografisch in 2D, dus kun je het viewport-midden gebruiken
        Vector3 center = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, Mathf.Abs(Camera.main.transform.position.z)));
        center.z = 0f; // Zorg ervoor dat de z-waarde 0 is voor 2D
        return center;
    }
}
