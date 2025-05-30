using UnityEngine;
using System.Collections;

public class SFXManagerTareas : MonoBehaviour
{
    public static SFXManagerTareas Instancia;
    public AudioClip sonidoDeFondo;
    public AudioClip respuestaCorrecta;
    public AudioClip respuestaIncorrecta;
    public AudioClip minijuegoCompletado;
    private AudioSource audioSource;

    private void Awake()
    {
        
        Instancia = this;
        DontDestroyOnLoad(gameObject);
        
    }

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = 0.3f;
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
