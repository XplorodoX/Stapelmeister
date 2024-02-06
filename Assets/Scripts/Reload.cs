using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit; // Dieses Namespace hinzufügen, um auf XR Interaction Toolkit zugreifen zu können

namespace UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets
{
    public class ReloadScene : MonoBehaviour
    {
        [SerializeField] XRBaseInteractable interactableButton; // Referenz zum VR Button

        void Start()
        {
            // Stellen Sie sicher, dass der Button im Inspector zugewiesen wurde
            if (interactableButton != null)
            {
                // Fügen Sie Event-Listener für das Interaktions-Event hinzu
                interactableButton.onSelectEntered.AddListener(HandleButtonPressed);
            }
            else
            {
                Debug.LogWarning("Interactable Button not assigned in the inspector", this);
            }
        }

        private void HandleButtonPressed(XRBaseInteractor interactor)
        {
            Debug.Log("Button pressed, reloading scene");
            ReloadCurrentScene();
        }

        private void ReloadCurrentScene()
        {
            Debug.Log("Reload current scene called");
            
            // Aktuellen Szenenindex holen
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            
            // Aktuelle Szene neu laden
            SceneManager.LoadScene(sceneIndex);
        }

        void OnDestroy()
        {
            // Event-Listener entfernen, um Memory Leaks zu vermeiden
            if (interactableButton != null)
            {
                interactableButton.onSelectEntered.RemoveListener(HandleButtonPressed);
            }
        }
    }
}
