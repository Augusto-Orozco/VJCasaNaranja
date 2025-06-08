using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OpcionesControllerTareas : MonoBehaviour
{
    public Slider sliderMusica;
    public Slider sliderEfectos;
    public Slider sliderBrillo;

    public Image brilloOverlay;

    private AudioSource musicaFuente;
    private SFXManagerTareas sfx;

    void Start()
    {
        StartCoroutine(EsperarYConfigurar());
    }

    private IEnumerator EsperarYConfigurar()
    {
        yield return new WaitForSeconds(0.1f);

        while (SFXManagerTareas.Instancia == null)
            yield return null;

        sfx = SFXManagerTareas.Instancia;
        musicaFuente = sfx.GetMusicaSource();

        float volMusica = PlayerPrefs.GetFloat("VolumenMusica", 0.3f);
        float volEfectos = PlayerPrefs.GetFloat("VolumenEfectos", 0.5f);
        float brillo = PlayerPrefs.GetFloat("Brillo", 1f);

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

        PlayerPrefs.SetFloat("VolumenMusica", valor);
    }

    public void CambiarVolumenEfectos(float valor)
    {
        if (sfx != null)
            sfx.SetVolumenEfectos(valor);

        PlayerPrefs.SetFloat("VolumenEfectos", valor);
    }

    void CambiarBrillo(float valor)
    {
        if (brilloOverlay != null)
        {
            Color c = brilloOverlay.color;
            c.a = Mathf.Lerp(0.6f, 0f, valor);
            brilloOverlay.color = c;
        }

        PlayerPrefs.SetFloat("Brillo", valor);
    }
}
