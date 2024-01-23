using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    private bool isObjectOnPlatform = false;
    private float timeObjectIsOnPlatform = 0.0f;
    public GameObject[] fallGates; // Array von Fallgitter GameObjects
    public Vector3 openPosition; // Die Position, zu der die Gitter bewegt werden sollen, wenn sie geöffnet sind
    public float openSpeed = 1.0f; // Wie schnell sich die Gitter öffnen sollen

    void Update()
    {
        if (isObjectOnPlatform)
        {
            timeObjectIsOnPlatform += Time.deltaTime;
            if (timeObjectIsOnPlatform >= 5.0f)
            {
                // Fallgitter öffnen
                foreach (var fallGate in fallGates)
                {
                    OpenFallGate(fallGate);
                }
            }
        }
        else
        {
            timeObjectIsOnPlatform = 0.0f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("R2D2"))
        {
            isObjectOnPlatform = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("R2D2"))
        {
            isObjectOnPlatform = false;
        }
    }

    void OpenFallGate(GameObject fallGate)
    {
        // Bewegt das Gitter sanft zur "openPosition" in der Y-Achse, behält aber die aktuellen X und Z Positionen bei
        Vector3 currentPosition = fallGate.transform.position;
        Vector3 newPosition = new Vector3(currentPosition.x, openPosition.y, currentPosition.z);
        fallGate.transform.position = Vector3.MoveTowards(currentPosition, newPosition, openSpeed * Time.deltaTime);
    }
}
