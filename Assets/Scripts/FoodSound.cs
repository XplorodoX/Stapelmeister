using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public AudioClip walkSound; // Der Sound, der beim Gehen abgespielt wird
    public AudioClip teleportSound; // Der Sound, der beim Teleportieren abgespielt wird
    public AudioClip grabSound; // Der Sound, der beim Greifen eines Objekts abgespielt wird
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Wenn der Spieler sich bewegt und der Sound nicht bereits abgespielt wird
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            if (!audioSource.isPlaying || audioSource.clip != walkSound)
            {
                audioSource.clip = walkSound;
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }

        // Wenn der Spieler sich teleportiert
        if (Input.GetKeyDown(KeyCode.T)) // Ersetzen Sie KeyCode.T durch die Taste, die Sie für das Teleportieren verwenden möchten
        {
            audioSource.Stop(); // Stoppen Sie den aktuellen Sound
            audioSource.clip = teleportSound;
            audioSource.Play();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Wenn der Spieler ein Objekt aufnimmt
        if (other.CompareTag("Object")) // Ersetzen Sie "Object" durch das Tag, das Sie für greifbare Objekte verwenden möchten
        {
            audioSource.Stop(); // Stoppen Sie den aktuellen Sound
            audioSource.clip = grabSound;
            audioSource.Play();
        }
    }
}
