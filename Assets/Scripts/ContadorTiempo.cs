using UnityEngine;
using UnityEngine.UI;

public class ContadorTiempo : MonoBehaviour
{
    public Text textoTiempo; // Asigna este en el inspector
    private float tiempoTranscurrido = 0f;
    private bool contar = true;

    void Update()
    {
        if (!contar) return;

        tiempoTranscurrido += Time.deltaTime;
        int segundos = Mathf.FloorToInt(tiempoTranscurrido);
        textoTiempo.text = "Tiempo: " + segundos + "s";
    }

    public void DetenerContador()
    {
        contar = false;
    }

    public float ObtenerTiempo()
    {
        return tiempoTranscurrido;
    }
}
