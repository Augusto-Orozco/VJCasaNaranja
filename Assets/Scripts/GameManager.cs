using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;
    public int puntaje = 0;
    public Text textoPuntaje;

    void Awake()
    {
        if (instancia == null)
            instancia = this;
        else
            Destroy(gameObject);
    }

    public void SumarPuntos(int cantidad)
    {
        puntaje += cantidad;
        if (textoPuntaje != null)
            textoPuntaje.text = "Puntos: " + puntaje;
    }
}
