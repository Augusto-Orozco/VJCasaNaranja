using UnityEngine;
using UnityEngine.UI;

public class ResultadoFinalTareas : MonoBehaviour
{
    public Text textoPuntos;
    public GameObject estrella1;
    public GameObject estrella2;
    public GameObject estrella3;

    public APIResultados aPIResultados;

    public int numEmpleado = 12345;
    public int idNivel = 3;

    void Start()
    {
        int puntos = PuntosTareasManager.Instancia.puntos;
        int tiempoTotal = 30;

        textoPuntos.text = puntos.ToString();

        estrella1.SetActive(false);
        estrella2.SetActive(false);
        estrella3.SetActive(false);

        int estrellasObtenidas = 0;

        if (puntos >= 50 && puntos < 70)
        {
            estrella1.SetActive(true);
            estrellasObtenidas = 1;
        }
        else if (puntos >= 70 && puntos < 100)
        {
            estrella1.SetActive(true);
            estrella2.SetActive(true);
            estrellasObtenidas = 2;
        }
        else if (puntos >= 100)
        {
            estrella1.SetActive(true);
            estrella2.SetActive(true);
            estrella3.SetActive(true);
            estrellasObtenidas = 3;
        }

        NivelUsuario datos = new NivelUsuario
        {
            numEmpleado = numEmpleado,
            idNivel = idNivel,
            estrellas = estrellasObtenidas,
            puntuacion = puntos,
            tiempoNivel = tiempoTotal
        };

        aPIResultados.EnviarResultado(datos);
    }
}
