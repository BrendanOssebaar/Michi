using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class RoomSpawner : MonoBehaviour
{
    public GameObject[] preMadeRooms; 
    [SerializeField] private GameObject currentRoom; 
    public float roomOffset = 5f; 
    public float roomDeactivateDelay = 5f;
    [SerializeField] private float roomSlideTime;

    private void Start()
    {
        PoolManager.Instance.InitializePool(preMadeRooms);
    }
    public void SpawnNewRoom(Transform triggerTransform)
    {
        var spawnPosition = (Vector2)triggerTransform.position + (Vector2)triggerTransform.up * roomOffset;
        GameObject newRoom = PoolManager.Instance.GetRandomRoom();
        if(newRoom != null)
        {
            newRoom.transform.position = spawnPosition;
            newRoom.transform.rotation = Quaternion.Euler(0,0,0);
            TransitionRooms(newRoom, currentRoom, triggerTransform);
            // SlideRoomToCenter(newRoom, triggerTransform);
            currentRoom = newRoom;
        }
    }
    private void SlideRoomToCenter(GameObject room, Transform triggerTransform)
    {
        Vector3 centerPosition = GetCameraCenter();
        Vector3 startPos = room.transform.position;
        float duration = 1f;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            room.transform.position = Vector3.Lerp(startPos, centerPosition, elapsed / duration);
            elapsed += Time.deltaTime;
        }
        room.transform.position = centerPosition;
        if (GameManager.Instance.playerTransform != null)
        {
            GameManager.Instance.playerTransform.position = centerPosition + (triggerTransform.up * GameManager.Instance.playerDoorOffset);
        }
    }
    private void TransitionRooms(GameObject newRoom, GameObject oldRoom, Transform triggerTransform)
    {
        Vector3 centerPosition = GetCameraCenter();
        Vector3 newRoomStart = newRoom.transform.position;
        Vector3 oldRoomStart = oldRoom.transform.position;
        Vector3 displacement = centerPosition - newRoomStart;
        Vector3 oldRoomTarget = oldRoomStart + displacement;
        DoorTrigger doorTrigger = triggerTransform.GetComponent<DoorTrigger>();
        Vector3 playerTarget;
        if (doorTrigger != null && doorTrigger.targetPlayerPosition != null)
        {
            playerTarget = doorTrigger.targetPlayerPosition.position;
        }
        else
        {
            playerTarget = centerPosition + (triggerTransform.up * GameManager.Instance.playerDoorOffset);
        }
        Transform player = GameManager.Instance.playerTransform;
        Vector3 playerStart = player.position;
        float duration = roomSlideTime;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            float t = elapsed / duration;
            newRoom.transform.position = Vector3.Lerp(newRoomStart, centerPosition, t);
            oldRoom.transform.position = Vector3.Lerp(oldRoomStart, oldRoomTarget, t);
            
            float playerT = t * 1f;
            player.position = Vector3.Lerp(playerStart, playerTarget, playerT);
            
            elapsed += Time.deltaTime;
        }
        newRoom.transform.position = centerPosition;
        oldRoom.transform.position = oldRoomTarget;
        
        Vector3 playerCurrent = player.position;
        float extraDuration = 0f;
        float extraElapsed = 0f;
        while (extraElapsed < extraDuration)
        {
            float extraT = extraElapsed / extraDuration;
            player.position = Vector3.Lerp(playerCurrent, playerTarget, extraT);
            extraElapsed += Time.deltaTime;
        }
        player.position = playerTarget;

        
        DeactivateRoomAfterDelay(oldRoom, roomDeactivateDelay);
    }

    private void DeactivateRoomAfterDelay(GameObject room, float delay)
    {
        PoolManager.ReturnRoom(room);
    }
    private static Vector3 GetCameraCenter()
    {
        Vector3 center = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, Mathf.Abs(Camera.main.transform.position.z)));
        center.z = 0f;
        return center;
    }
}
