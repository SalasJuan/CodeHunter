using UnityEngine;

public class BackgroundMusicArea : MonoBehaviour
{
    public AudioSource backgroundMusicSource;
    public AudioClip backgroundMusicClip;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // El jugador entró en el área, comienza a reproducir la música de fondo
            backgroundMusicSource.clip = backgroundMusicClip;
            backgroundMusicSource.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // El jugador salió del área, detén la música de fondo
            backgroundMusicSource.Stop();
        }
    }
}
