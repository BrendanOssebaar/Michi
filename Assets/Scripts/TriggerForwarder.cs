using UnityEngine;

public class TriggerForwarder : MonoBehaviour
{
    public Transform targetPlayerPosition;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            // Geef de eigen transform (van deze triggerbox) mee
            GameManager.Instance.OnPlayerTriggered(transform);
        }
    }
}