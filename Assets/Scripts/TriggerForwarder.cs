using UnityEngine;

public class TriggerForwarder : MonoBehaviour
{
    public ObjectPool objectPool; // Assign this via the Inspector or find it in code.

    void OnTriggerEnter2D(Collider2D other)
    {
        // Forward the event to the ObjectPool script
        if(objectPool != null)
        {
            objectPool.HandleTrigger(other);
        }
    }
}
