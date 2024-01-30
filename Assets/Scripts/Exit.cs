using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private bool isPressed = false; // Ein Zustand, um den Buttonstatus zu verfolgen.

    // Hier wird die Methode aufgerufen, wenn der Button interagiert wird.
    public void InteractWithButton()
    {
        // Überprüfe, ob der Button nicht bereits gedrückt wurde.
        if (!isPressed)
        {
            // Führe die Logik für das Drücken des Buttons aus.
            // Hier könntest du Animationen, Soundeffekte usw. hinzufügen.
            // Wenn der Button gedrückt wurde, kannst du das Spiel beenden.
            isPressed = true;
            Application.Quit(); // Beendet das Spiel.
        }
    }
}
