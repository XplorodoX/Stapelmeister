using UnityEngine;

public class GameExit : MonoBehaviour
{
    // Method to end the game
    public void ExitGame()
    {
        // Log message to the console
        Debug.Log("Exit game called");

        // Quit the application
        Application.Quit();

        // If we're running in the editor
        #if UNITY_EDITOR
        // Stop playing the scene in the editor
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
