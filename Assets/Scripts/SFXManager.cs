using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioClip sonidoDeFondo;
    public AudioClip sonidoBolitas;
    private AudioSource audioSource;
    private AudioSource efectosSource;

    public AudioSource MusicaSource => audioSource;
    public AudioSource EfectosSource => efectosSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.volume = PlayerPrefs.GetFloat("VolumenMusica", 0.5f);
        audioSource.clip = sonidoDeFondo;
        audioSource.loop = true;
        audioSource.Play();

        efectosSource = gameObject.AddComponent<AudioSource>();
        efectosSource.volume = PlayerPrefs.GetFloat("VolumenEfectos", 0.5f); // Volumen por defecto a mitad
        efectosSource.loop = false;
    }

    public void bolitasCrack()
    {
        if (sonidoBolitas != null)
            efectosSource.PlayOneShot(sonidoBolitas);
    }
}
