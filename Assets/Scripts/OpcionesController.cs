using UnityEngine;
using UnityEngine.UI;

public class OpcionesController : MonoBehaviour
{
    public Slider sliderMusica;
    public Slider sliderEfectos;
    public Slider sliderBrillo;

    public Image brilloOverlay;

    private SFXManager sfxManager;

    void Start()
    {
        sfxManager = FindObjectOfType<SFXManager>();

        float musicaInicial = PlayerPrefs.GetFloat("VolumenMusica", 0.5f);
        float efectosInicial = PlayerPrefs.GetFloat("VolumenEfectos", 0.5f);
        float brilloInicial = PlayerPrefs.GetFloat("Brillo", 1f);

        sliderMusica.value = musicaInicial;
        sliderEfectos.value = efectosInicial;
        sliderBrillo.value = brilloInicial;

        CambiarVolumenMusica(musicaInicial);
        CambiarVolumenEfectos(efectosInicial);
        CambiarBrillo(brilloInicial);

        sliderMusica.onValueChanged.AddListener(CambiarVolumenMusica);
        sliderEfectos.onValueChanged.AddListener(CambiarVolumenEfectos);
        sliderBrillo.onValueChanged.AddListener(CambiarBrillo);
    }

    void CambiarVolumenMusica(float valor)
    {
        if (sfxManager != null && sfxManager.MusicaSource != null)
            sfxManager.MusicaSource.volume = valor;

        PlayerPrefs.SetFloat("VolumenMusica", valor);
    }

    void CambiarVolumenEfectos(float valor)
    {
        if (sfxManager != null && sfxManager.EfectosSource != null)
            sfxManager.EfectosSource.volume = valor;

        PlayerPrefs.SetFloat("VolumenEfectos", valor);
    }

    void CambiarBrillo(float valor)
    {

        Color c = brilloOverlay.color;
        c.a = Mathf.Lerp(0.6f, 0f, valor);
        brilloOverlay.color = c;

        PlayerPrefs.SetFloat("Brillo", valor);
    }
}
