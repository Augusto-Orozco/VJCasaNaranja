using UnityEngine;
using UnityEngine.UI;

public class ResultadoFinalCartas : MonoBehaviour
{
    public Text textoPuntosFinales;
    public GameObject estrella1, estrella2, estrella3;
    public APIResultados aPIResultados;

    public int numEmpleadoSesion;
    public int idNivel = 2;

    void Start()
    {
        numEmpleadoSesion = PlayerPrefs.GetInt("numEmpleado", 0);
        int puntos = PuntosCartasBehaviour.Instancia.puntuacion;
        int tiempoTotal = 180;

        textoPuntosFinales.text = puntos.ToString();

        estrella1.SetActive(false);
        estrella2.SetActive(false);
        estrella3.SetActive(false);

        int estrellasObtenidas = 0;

        if (puntos >= 900)
        {
            estrella1.SetActive(true);
            estrella2.SetActive(true);
            estrella3.SetActive(true);
            estrellasObtenidas = 3;
        }
        else if (puntos >= 600)
        {
            estrella1.SetActive(true);
            estrella2.SetActive(true);
            estrellasObtenidas = 2;
        }
        else if (puntos >= 300)
        {
            estrella1.SetActive(true);
            estrellasObtenidas = 1;
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
        SFXManagerCartas.Instancia.ReproducirCompletado();
    }
}
