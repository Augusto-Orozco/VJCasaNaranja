using UnityEngine;
using UnityEngine.UI;

public class ResultadoFinalTareas : MonoBehaviour
{
    public Text textoPuntos;
    public GameObject estrella1;
    public GameObject estrella2;
    public GameObject estrella3;

    void Start()
    {
        int puntos = PuntosTareasManager.Instancia.puntos;

        textoPuntos.text = puntos.ToString();

        estrella1.SetActive(false);
        estrella2.SetActive(false);
        estrella3.SetActive(false);

        if (puntos >= 50 && puntos < 70)
        {
            estrella1.SetActive(true);
        }
        else if (puntos >= 70 && puntos < 100)
        {
            estrella1.SetActive(true);
            estrella2.SetActive(true);
        }
        else if (puntos >= 100)
        {
            estrella1.SetActive(true);
            estrella2.SetActive(true);
            estrella3.SetActive(true);
        }
    }
}
