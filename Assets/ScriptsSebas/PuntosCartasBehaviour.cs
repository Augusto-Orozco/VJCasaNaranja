using UnityEngine;
using UnityEngine.UI;

public class PuntosCartasBehaviour : MonoBehaviour
{
    public static PuntosCartasBehaviour Instancia;

    public int puntuacion = 0;
    public int puntosMaximos = 1000;
    public Text textoPuntos;

    void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        ActualizarTexto();
    }

    public void AgregarPuntos(int cantidad)
    {
        puntuacion = Mathf.Min(puntuacion + cantidad, puntosMaximos);
        ActualizarTexto();
    }

    public void RestarPuntos(int cantidad)
    {
        puntuacion = Mathf.Max(puntuacion - cantidad, 0);
        ActualizarTexto();
    }

    private void ActualizarTexto()
    {
        if (textoPuntos != null)
        {
            textoPuntos.text = $"Puntos: {puntuacion}";
        }
    }
}
