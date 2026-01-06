using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Log everything that enters
        Debug.Log("KillZone hit: " + other.name);

        // Only destroy objects tagged as "Reel"
        if (other.CompareTag("Reel"))
        {
            Destroy(other.gameObject);
        }
    }
}