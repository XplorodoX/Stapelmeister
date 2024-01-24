using UnityEngine;

public class FallSound : MonoBehaviour
{
    public AudioSource audioSource;
    public float fallThreshold = 0.5f; // Threshold für das Umfallen des Objekts

    private bool hasFallen = false;

    void OnCollisionEnter(Collision collision)
    {
        // Überprüfen Sie, ob das Objekt umgefallen ist
        if (!hasFallen && collision.relativeVelocity.magnitude >= fallThreshold)
        {
            audioSource.Play();
            hasFallen = true; // Markieren Sie das Objekt als umgefallen, um mehrfache Auslösungen zu verhindern
        }
    }
}
