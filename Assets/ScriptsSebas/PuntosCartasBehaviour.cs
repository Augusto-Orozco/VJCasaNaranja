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
        Instancia = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        if (textoPuntos == null)
        {
            GameObject textoGO = GameObject.Find("Puntos");
            if (textoGO != null)
            {
                textoPuntos = textoGO.GetComponent<Text>();
                ActualizarTexto();
            }
        }
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

    public void ResetPuntos()
    {
        puntuacion = 0;
        ActualizarTexto();
    }
}
