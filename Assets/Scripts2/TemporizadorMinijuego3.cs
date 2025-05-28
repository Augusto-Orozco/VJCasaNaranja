using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TemporizadorMinijuego3 : MonoBehaviour
{
    public float tiempoInicial = 30f;
    private float tiempoRestante;
    public Text textoTiempo;

    private bool tiempoAgotado = false;

    void Start()
    {
        tiempoRestante = tiempoInicial;
    }

    void Update()
    {
        if (tiempoAgotado)
        {
            return;
        }
        tiempoRestante -= Time.deltaTime;

        if (tiempoRestante <= 0)
        {
            tiempoRestante = 0;
            tiempoAgotado = true;
        }

        MostrarTiempo();
    }

    void MostrarTiempo()
    {
        int minutos = Mathf.FloorToInt(tiempoRestante / 60f);
        int segundos = Mathf.FloorToInt(tiempoRestante % 60f);
        textoTiempo.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }

    void FinJuego()
    {
        Debug.Log("Se acabo el tiempo");
        SceneManager.LoadScene("EndScene2");
    }
}
