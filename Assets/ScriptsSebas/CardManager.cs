using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class CardManager : MonoBehaviour
{
    public List<GameObject> tarjetas; // Lista de tarjetas que están en la escena
    private int indice = 0; // Control de qué tarjeta se debe mostrar

    public TimerBar timerBar;

    void Start()
    {
        // Asegúrate de que todas las tarjetas estén desactivadas al inicio
        foreach (GameObject tarjeta in tarjetas)
        {
            tarjeta.SetActive(false);
        }

        // Mostrar la primera tarjeta
        MostrarSiguienteTarjeta();
    }

    // Método que muestra la siguiente tarjeta de la lista
    public void MostrarSiguienteTarjeta()
    {
        Debug.Log("Intentando mostrar tarjeta en índice: " + indice);

        // Si ya se han mostrado todas las tarjetas, no hace nada
        if (indice >= tarjetas.Count)
        {
            Debug.Log("Ya no hay más tarjetas para mostrar.");
            return;
        }

        // Desactivar la tarjeta anterior (si es necesario)
        if (indice > 0)
        {
            tarjetas[indice - 1].SetActive(false);
        }

        // Activar la siguiente tarjeta
        tarjetas[indice].SetActive(true);

        // Avanza al siguiente índice para la próxima tarjeta
        indice++;

        Debug.Log("Tarjeta mostrada, nuevo índice: " + indice);
    }

    // Método para comprobar si hay más tarjetas
    public bool HayMasTarjetas()
    {
        return indice < tarjetas.Count;
    }

    public void TerminarJuego()
    {
        Debug.Log("CardManager.TerminarJuego() llamado");
        timerBar.TerminarJuego(false); // Esto debe detener el temporizador
        Debug.Log("TimerBar.TerminarJuego() ejecutado.");
        SceneManager.LoadScene("EndScene"); // Esto debería cambiar la escena
    }
}