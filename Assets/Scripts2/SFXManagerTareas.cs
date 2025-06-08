using UnityEngine;
using System.Collections;

public class SFXManagerTareas : MonoBehaviour
{
    public static SFXManagerTareas Instancia;

    public AudioClip sonidoDeFondo;
    public AudioClip respuestaCorrecta;
    public AudioClip respuestaIncorrecta;
    public AudioClip minijuegoCompletado;

    private AudioSource musicaSource;
    private AudioSource efectosSource;

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
        musicaSource = gameObject.AddComponent<AudioSource>();
        musicaSource.clip = sonidoDeFondo;
        musicaSource.loop = true;
        musicaSource.volume = PlayerPrefs.GetFloat("VolumenMusicaTareas", 0.3f);
        musicaSource.Play();

        efectosSource = gameObject.AddComponent<AudioSource>();
        efectosSource.loop = false;
        efectosSource.volume = PlayerPrefs.GetFloat("VolumenEfectosTareas", 0.5f);
    }

    public void ReproducirCorrecto()
    {
        efectosSource.PlayOneShot(respuestaCorrecta);
    }

    public void ReproducirIncorrecto()
    {
        efectosSource.PlayOneShot(respuestaIncorrecta);
    }

    public void ReproducirCompletado()
    {
        StartCoroutine(DetenerMusicaYReproducirFinal());
    }

    private IEnumerator DetenerMusicaYReproducirFinal()
    {
        if (musicaSource != null)
            musicaSource.Pause();

        AudioSource.PlayClipAtPoint(minijuegoCompletado, Camera.main.transform.position);
        yield return new WaitForSeconds(minijuegoCompletado.length);
    }

    public void ResetMusica()
    {
        if (musicaSource != null)
            musicaSource.UnPause();
    }

    public void DetenerMusic()
    {
        if (musicaSource != null)
            musicaSource.Stop();
    }

    public void EmpezarMusica()
    {
        if (musicaSource != null)
            musicaSource.Play();
    }

    public void SetVolumenEfectos(float valor)
    {
        if (efectosSource != null)
            efectosSource.volume = valor;
    }

    public AudioSource GetMusicaSource()
    {
        return musicaSource;
    }
}
