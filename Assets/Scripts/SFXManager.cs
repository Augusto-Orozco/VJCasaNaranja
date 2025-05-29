using UnityEngine;
using System.Collections;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instancia;
    public AudioClip sonidoDeFondo;
    public AudioClip respuestaCorrecta;
    public AudioClip respuestaIncorrecta;
    public AudioClip minijuegoCompletado;
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
        audioSource.volume = 0.1f;
        audioSource.clip = sonidoDeFondo;
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

    public void ResetMusica()
    {
        audioSource.UnPause();
    }
    
    public void DetenerMusic()
    {
        audioSource.Stop();
    }

    public void EmpezarMusica()
    {
        audioSource.Play();
    }

}
