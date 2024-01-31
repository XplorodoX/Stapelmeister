using UnityEngine;

public class ExitGameTrigger : MonoBehaviour
{
    // Diese Funktion wird aufgerufen, wenn ein anderer Collider in den Trigger eintritt
    private void OnTriggerEnter(Collider other)
    {
        // Prüfe, ob der Collider zum Spieler gehört
        if (other.tag == "Player")
        {
            // Beende das Spiel
            #if UNITY_EDITOR
            // Wenn du im Unity Editor bist, stoppe das Abspielen
            UnityEditor.EditorApplication.isPlaying = false;
            #else
                // Wenn das Spiel gebaut ist, beende die Anwendung
                Application.Quit();
            #endif
        }
    }
}
