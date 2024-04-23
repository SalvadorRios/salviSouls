using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; } // Singleton instance

    public AudioSource soundEffectSource; // AudioSource para efectos de sonido
    public AudioSource musicSource; // AudioSource para música de fondo
    public AudioClip song;

    void Awake()
    {
        // Implementación del singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Para mantener activo el AudioManager entre escenas
        }
        else
        {
            Destroy(gameObject); // Si ya existe una instancia, destruye la duplicada
        }
        PlayMusic(song);
    }

    // Método para reproducir música de fondo
    public void PlayMusic(AudioClip clip, bool loop = true)
    {
        musicSource.clip = clip;
        musicSource.loop = loop;
        musicSource.Play();
    }

    // Método para reproducir efectos de sonido
    public void PlaySoundEffect(AudioClip clip)
    {
        soundEffectSource.PlayOneShot(clip);
    }
}