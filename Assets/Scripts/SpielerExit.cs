using UnityEngine;

public class ExitGameAtCoordinates : MonoBehaviour
{
    public Vector3 targetPosition1; // Die erste Zielkoordinate
    public Vector3 targetPosition2; // Die zweite Zielkoordinate
    public Vector3 targetPosition3; // Die dritte Zielkoordinate
    public float tolerance = 1.0f; // Toleranzbereich um die Zielkoordinaten

    void Update()
    {
        // Überprüfe die Distanz für jede Zielposition
        if (CheckDistanceToTarget(targetPosition1) ||
            CheckDistanceToTarget(targetPosition2) ||
            CheckDistanceToTarget(targetPosition3))
        {
            ExitGame();
        }
    }

    bool CheckDistanceToTarget(Vector3 targetPosition)
    {
        // Berechne die Distanz zwischen der aktuellen Position und der Zielposition
        float distanceToTarget = Vector3.Distance(transform.position, targetPosition);
        Debug.Log(transform.position); // Zeige die Distanz im Konsolenfenster

        // Überprüfe, ob der Spieler innerhalb des Toleranzbereichs der Zielkoordinaten ist
        return distanceToTarget <= tolerance;
    }

    void ExitGame()
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
