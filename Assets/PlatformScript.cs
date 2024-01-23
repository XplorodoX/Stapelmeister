using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    private bool isObjectOnPlatform = false;
    private float timeObjectIsOnPlatform = 0.0f;
    public GameObject[] fallGates; // Array von Fallgitter GameObjects
    public Vector3 openPosition; // Die Position, zu der die Gitter bewegt werden sollen, wenn sie ge�ffnet sind
    public float openSpeed = 1.0f; // Wie schnell sich die Gitter �ffnen sollen
    public Renderer platformRenderer;
    private Color originalColor;

    void Start()
    {
        if (platformRenderer == null)
        {
            platformRenderer = GetComponent<Renderer>(); // Versuche, den Renderer automatisch zu erhalten, falls nicht manuell zugewiesen
        }
        if (platformRenderer != null)
        {
            originalColor = platformRenderer.material.color; // Speichert die urspr�ngliche Farbe
        }
    }

    void Update()
    {
        if (isObjectOnPlatform)
        {
            timeObjectIsOnPlatform += Time.deltaTime;
            if (timeObjectIsOnPlatform >= 5.0f)
            {
                // Fallgitter �ffnen
                foreach (var fallGate in fallGates)
                {
                    OpenFallGate(fallGate);
                }
                // Kein Bedarf, die Farbe hier zu �ndern, da sie bereits in OnTriggerEnter ge�ndert wurde
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
            ChangePlatformColor(Color.green); // Plattform sofort gr�n f�rben, wenn das Objekt die Plattform betritt
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("R2D2"))
        {
            isObjectOnPlatform = false;
            // Optional: Die Farbe der Plattform zur�cksetzen, wenn das Objekt die Plattform verl�sst
            ChangePlatformColor(originalColor); // oder eine andere Standardfarbe
        }
    }

    void OpenFallGate(GameObject fallGate)
    {
        // Bewegt das Gitter sanft zur "openPosition" in der Y-Achse, beh�lt aber die aktuellen X und Z Positionen bei
        Vector3 currentPosition = fallGate.transform.position;
        Vector3 newPosition = new Vector3(currentPosition.x, openPosition.y, currentPosition.z);
        fallGate.transform.position = Vector3.MoveTowards(currentPosition, newPosition, openSpeed * Time.deltaTime);
    }
    void ChangePlatformColor(Color color)
    {
        if (platformRenderer != null)
        {
            platformRenderer.material.color = color; // �ndert die Farbe des Materials der Plattform
        }
    }
}
