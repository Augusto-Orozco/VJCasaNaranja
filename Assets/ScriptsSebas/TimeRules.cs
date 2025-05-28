using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Agregar para cargar escenas
using System.Collections;

public class TimerBar : MonoBehaviour
{
    public Slider timerSlider;
    public GameObject panel; // El panel que contiene las animaciones
    private CanvasGroup panelCanvasGroup; // El CanvasGroup del panel
    public float totalTime = 20f;
    private float timeLeft;
    public bool juegoIniciado = false; // Hacerlo público
    private bool juegoTerminado = false; // Nueva variable para saber si el juego ha terminado
    private float tiempoPenalizacion = 10f;
    private float tiempoAcumulado = 0f;

    void Start()
    {
        timeLeft = totalTime;
        timerSlider.maxValue = totalTime;
        timerSlider.value = totalTime;

        // Obtener el CanvasGroup del panel
        panelCanvasGroup = panel.GetComponent<CanvasGroup>();

        // Asegurarse de que el panel sea visible y funcional al principio
        panelCanvasGroup.alpha = 1;  // Panel completamente visible
        panelCanvasGroup.interactable = true; // Los elementos dentro del panel son interactivos
        panelCanvasGroup.blocksRaycasts = true; // El panel puede bloquear raycasts (interacciones de UI)

        juegoIniciado = false;
    }

    void Update()
    {
        if (!juegoIniciado || juegoTerminado) return; // No actualizar si el juego no ha iniciado o ya terminó

        timeLeft -= Time.deltaTime;
        tiempoAcumulado += Time.deltaTime;
        timerSlider.value = timeLeft;

        if (tiempoAcumulado >= tiempoPenalizacion)
        {
            PuntosCartasBehaviour.Instancia.RestarPuntos(50); 
            tiempoAcumulado = 0f;
        }

        if (timeLeft <= 0f)
            {
                // Aquí cargamos la escena "EndScene" cuando el tiempo se acabe
                TerminarJuego(true);
            }
    }

    public void IniciarJuego()
    {
        // Llamar a una coroutine para hacer desaparecer el panel rápidamente
        StartCoroutine(FadeOut());
        juegoIniciado = true;
    }

    // Coroutine para hacer un desvanecimiento rápido (fade out)
    private IEnumerator FadeOut()
    {
        float startAlpha = panelCanvasGroup.alpha;
        float timeElapsed = 0f;

        // Ajustamos el tiempo para un desvanecimiento más rápido (ejemplo: en 0.2 segundos)
        float fadeDuration = 0.2f;

        // Animación de desvanecimiento rápido
        while (timeElapsed < fadeDuration)
        {
            panelCanvasGroup.alpha = Mathf.Lerp(startAlpha, 0, timeElapsed / fadeDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        panelCanvasGroup.alpha = 0; // Asegurarse de que el panel esté completamente invisible
        panelCanvasGroup.interactable = false; // Desactivar la interactividad del panel
        panelCanvasGroup.blocksRaycasts = false; // Desactivar los raycasts (deja de bloquear interacciones)
    }

    public void TerminarJuego(bool porTiempo)
    {
        Debug.Log("TimerBar.TerminarJuego() llamado");

        if (porTiempo)
        {
            timeLeft = 0f;
            timerSlider.value = 0f;
        }

        juegoTerminado = true;
        SceneManager.LoadScene("EndScene");
    }

    private IEnumerator CambiarEscena()
    {
        // Esperar un frame antes de cambiar la escena
        yield return null;
        
        // Cambiar la escena después de un breve retraso
        SceneManager.LoadScene("EndScene");
    }
}