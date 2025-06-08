using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OpcionesControllerMenu : MonoBehaviour
{
    public Slider sliderMusica;
    public Slider sliderBrillo;
    public Image brilloOverlay;

    private AudioSource cancionActiva;
    private SeleccionManager seleccionManager;

    void Start()
    {
        StartCoroutine(EsperarSeleccionYConfigurar());
    }

    private IEnumerator EsperarSeleccionYConfigurar()
    {
        // Esperar a que SeleccionManager exista
        while (seleccionManager == null)
        {
            seleccionManager = FindObjectOfType<SeleccionManager>();
            yield return null;
        }

        // Esperar a que haya una canción activa
        while (seleccionManager.CancionActiva == null)
            yield return null;

        cancionActiva = seleccionManager.CancionActiva;

        float volMusica = PlayerPrefs.GetFloat("VolumenMusicaMenu", 0.3f);
        float brillo = PlayerPrefs.GetFloat("BrilloMenu", 1f);

        sliderMusica.value = volMusica;
        sliderBrillo.value = brillo;

        CambiarVolumenMusica(volMusica);
        CambiarBrillo(brillo);

        sliderMusica.onValueChanged.AddListener(CambiarVolumenMusica);
        sliderBrillo.onValueChanged.AddListener(CambiarBrillo);
    }

    public void CambiarVolumenMusica(float valor)
    {
        if (cancionActiva != null)
            cancionActiva.volume = valor;

        PlayerPrefs.SetFloat("VolumenMusicaMenu", valor);
    }

    void CambiarBrillo(float valor)
    {
        if (brilloOverlay != null)
        {
            Color c = brilloOverlay.color;
            c.a = Mathf.Lerp(0.6f, 0f, valor);
            brilloOverlay.color = c;
        }

        PlayerPrefs.SetFloat("BrilloMenu", valor);
    }
}
