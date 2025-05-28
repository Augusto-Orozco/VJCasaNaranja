using UnityEngine;
using UnityEngine.UI;

public class ResultadoFinalCartas : MonoBehaviour
{
    public Text textoPuntosFinales;
    public GameObject estrella1, estrella2, estrella3;

    void Start()
    {
        int puntos = PuntosCartasBehaviour.Instancia.puntuacion;

        textoPuntosFinales.text = puntos.ToString();

        estrella1.SetActive(false);
        estrella2.SetActive(false);
        estrella3.SetActive(false);

        if (puntos >= 900)
        {
            estrella1.SetActive(true);
            estrella2.SetActive(true);
            estrella3.SetActive(true);
        }
        else if (puntos >= 600)
        {
            estrella1.SetActive(true);
            estrella2.SetActive(true);
        }
        else if (puntos >= 300)
        {
            estrella1.SetActive(true);
        }
    }
}
