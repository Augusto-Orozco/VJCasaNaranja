using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class ResultadoFinalTareas : MonoBehaviour
{
    public Text textoPuntos;
    public GameObject estrella1;
    public GameObject estrella2;
    public GameObject estrella3;

    public APIResultados aPIResultados;

    public int numEmpleadoSesion;
    public int idNivel = 3;

    public int tiempoTotal;

    void Start()
    {
        numEmpleadoSesion = PlayerPrefs.GetInt("numEmpleado", 0);
        int puntos = PuntosTareasManager.Instancia.puntos;
        tiempoTotal = PlayerPrefs.GetInt("tiempoInicial", 0);

        textoPuntos.text = puntos.ToString();

        estrella1.SetActive(false);
        estrella2.SetActive(false);
        estrella3.SetActive(false);

        int estrellasObtenidas = 0;

        if (puntos >= 300 && puntos < 600)
        {
            estrella1.SetActive(true);
            estrellasObtenidas = 1;
        }
        else if (puntos >= 600 && puntos < 900)
        {
            estrella1.SetActive(true);
            estrella2.SetActive(true);
            estrellasObtenidas = 2;
        }
        else if (puntos >= 900)
        {
            estrella1.SetActive(true);
            estrella2.SetActive(true);
            estrella3.SetActive(true);
            estrellasObtenidas = 3;
        }

        NivelUsuario datos = new NivelUsuario
        {
            numEmpleado = numEmpleadoSesion,
            idNivel = idNivel,
            estrellas = estrellasObtenidas,
            puntuacion = puntos,
            tiempoNivel = tiempoTotal
        };

        aPIResultados.EnviarResultado(datos);
        SFXManagerTareas.Instancia.ReproducirCompletado();

    }
}
