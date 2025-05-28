using UnityEngine;
using UnityEngine.UI;

public class PuntosTextoTareas : MonoBehaviour
{
    public Text textoPuntos;

    void Update()
    {
        textoPuntos.text = "Puntos: " + PuntosTareasManager.Instancia.puntos;
    }
}
