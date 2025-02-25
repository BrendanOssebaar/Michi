using UnityEngine;

public class TriggerForwarder : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            // Geef de eigen transform (van deze triggerbox) mee
            GameManager.Instance.OnPlayerTriggered(transform);
        }
    }
}