using UnityEngine;
using System.Collections;

public class SFXManagerCartas : MonoBehaviour
{
    public static SFXManagerCartas Instancia;

    public AudioClip respuestaCorrecta;
    public AudioClip respuestaIncorrecta;
    public AudioClip minijuegoCompletado;
    public AudioClip musicaFondo;
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
        musicaSource.volume = PlayerPrefs.GetFloat("VolumenMusicaCartas", 0.5f);
        musicaSource.clip = musicaFondo;
        musicaSource.loop = true;
        musicaSource.Play();

        efectosSource = gameObject.AddComponent<AudioSource>();
        efectosSource.volume = PlayerPrefs.GetFloat("VolumenEfectosCartas", 0.5f);
        efectosSource.loop = false;
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
        if (musicaSource != null && !musicaSource.isPlaying)
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
