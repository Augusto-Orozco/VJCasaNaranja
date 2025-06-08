using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class OpcionesControllerCartas : MonoBehaviour
{
    public Slider sliderMusica;
    public Slider sliderEfectos;
    public Slider sliderBrillo;

    public Image brilloOverlay;

    private AudioSource musicaFuente;
    private SFXManagerCartas sfx;

    void Start()
    {
        StartCoroutine(EsperarYConfigurar());
    }

    private IEnumerator EsperarYConfigurar()
    {
        // Esperar hasta que SFXManagerCartas esté listo
        while (SFXManagerCartas.Instancia == null || SFXManagerCartas.Instancia.GetMusicaSource() == null)
        {
            yield return null;
        }

        sfx = SFXManagerCartas.Instancia;
        musicaFuente = sfx.GetMusicaSource();

        float volMusica = PlayerPrefs.GetFloat("VolumenMusicaCartas", 0.5f);
        float volEfectos = PlayerPrefs.GetFloat("VolumenEfectosCartas", 0.5f);
        float brillo = PlayerPrefs.GetFloat("BrilloCartas", 1f);

        sliderMusica.value = volMusica;
        sliderEfectos.value = volEfectos;
        sliderBrillo.value = brillo;

        CambiarVolumenMusica(volMusica);
        CambiarVolumenEfectos(volEfectos);
        CambiarBrillo(brillo);

        sliderMusica.onValueChanged.AddListener(CambiarVolumenMusica);
        sliderEfectos.onValueChanged.AddListener(CambiarVolumenEfectos);
        sliderBrillo.onValueChanged.AddListener(CambiarBrillo);
    }
    public void CambiarVolumenMusica(float valor)
    {
        if (musicaFuente != null)
            musicaFuente.volume = valor;

        PlayerPrefs.SetFloat("VolumenMusicaCartas", valor);
    }

    public void CambiarVolumenEfectos(float valor)
    {
        if (sfx != null)
        {
            sfx.SetVolumenEfectos(valor); // nuevo método que debes crear abajo
        }

        PlayerPrefs.SetFloat("VolumenEfectosCartas", valor);
    }

    void CambiarBrillo(float valor)
    {
        if (brilloOverlay != null)
        {
            Color c = brilloOverlay.color;
            c.a = Mathf.Lerp(0.6f, 0f, valor);
            brilloOverlay.color = c;
        }

        PlayerPrefs.SetFloat("BrilloCartas", valor);
    }
}
