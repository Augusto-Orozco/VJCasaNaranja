using UnityEngine;
using System.Collections;

public class SFXManagerCartas : MonoBehaviour
{
    public static SFXManagerCartas Instancia;

    public AudioClip respuestaCorrecta;
    public AudioClip respuestaIncorrecta;
    public AudioClip minijuegoCompletado;
    public AudioClip musicaFondo;

    private AudioSource audioSource;

    private void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = 0.3f;
        audioSource.clip = musicaFondo;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void ReproducirCorrecto()
    {
        audioSource.PlayOneShot(respuestaCorrecta);
    }

    public void ReproducirIncorrecto()
    {
        audioSource.PlayOneShot(respuestaIncorrecta);
    }

    public void ReproducirCompletado()
    {
        StartCoroutine(DetenerMusicaYReproducirFinal());
    }
    
    private IEnumerator DetenerMusicaYReproducirFinal()
    {
        audioSource.Pause();
        AudioSource.PlayClipAtPoint(minijuegoCompletado, Camera.main.transform.position);

        yield return new WaitForSeconds(minijuegoCompletado.length);
    }
}
