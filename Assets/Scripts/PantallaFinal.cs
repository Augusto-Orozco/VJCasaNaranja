using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TuClaseFinal : MonoBehaviour
{
    public Text textoPuntaje;
    public Image[] estrellas;
    public float tiempoEsperaAnimacion = 2f;


    private int numEmpleadoSesion;
    public APIResultados aPIResultados;
    private int idNivel = 1;

    private int tiempoTrans;


    void Start()
    {
        foreach (Image estrella in estrellas)
        {
            estrella.enabled = false;
        }
        StartCoroutine(MostrarPuntajeYEstrellas());
    }

    IEnumerator MostrarPuntajeYEstrellas()
    {
        // Espera a que termine la animación
        yield return new WaitForSeconds(tiempoEsperaAnimacion);

        int puntaje = PlayerPrefs.GetInt("PuntajeFinal", 0);

        if (textoPuntaje != null)
            textoPuntaje.text = puntaje.ToString();

        int cantidadEstrellas = CalcularEstrellas(puntaje);

        for (int i = 0; i < cantidadEstrellas; i++)
        {
            estrellas[i].enabled = true;
            yield return new WaitForSeconds(1f);
        }
        numEmpleadoSesion = PlayerPrefs.GetInt("numEmpleado", 0);

        tiempoTrans = PlayerPrefs.GetInt("tiempoNivel", 0);

        NivelUsuario datos = new NivelUsuario
        {
            numEmpleado = numEmpleadoSesion,
            idNivel = idNivel,
            estrellas = cantidadEstrellas,
            puntuacion = puntaje,
            tiempoNivel = tiempoTrans
        };
        Debug.Log(numEmpleadoSesion);
        Debug.Log(idNivel);
        Debug.Log(cantidadEstrellas);
        Debug.Log(puntaje);
        Debug.Log(tiempoTrans);


        aPIResultados.EnviarResultado(datos);
    }

    int CalcularEstrellas(int puntaje)
    {
        
        if (puntaje >= 700) return 3;
        if (puntaje >= 500) return 2;
        if (puntaje >= 200) return 1;
        return 0;
    }
}
