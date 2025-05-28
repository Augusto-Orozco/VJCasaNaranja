using UnityEngine;
using UnityEngine.SceneManagement;
public class SalirGame : MonoBehaviour
{
    public RespuestaVisual respuestaVisual;
    public int respuestaCorrecta;

    public void nextGame1(int numeroUsuario)
    {
        Debug.Log("Boton Presionado");

        if (respuestaCorrecta != null)
        {

            if (numeroUsuario == respuestaCorrecta)
            {
                Debug.Log("Respuesta correcta");
                respuestaVisual.MostrarCorrecto();
                PuntosTareasManager.Instancia.AgregarPuntos(30);
            }
            else
            {
                Debug.Log("Respuesta incorrecta");
                respuestaVisual.MostrarIncorrecto();
            }
        }

        StartCoroutine(CambiarEscenaRetraso("Nivel2MiniJuego3"));
    }

    public void nextGame2(int numeroUsuario)
    {
        Debug.Log("Boton Presionado");

        if (respuestaCorrecta != null)
        {

            if (numeroUsuario == respuestaCorrecta)
            {
                Debug.Log("Respuesta correcta");
                respuestaVisual.MostrarCorrecto();
                PuntosTareasManager.Instancia.AgregarPuntos(30);
            }
            else
            {
                Debug.Log("Respuesta incorrecta");
                respuestaVisual.MostrarIncorrecto();
            }
        }
        StartCoroutine(CambiarEscenaRetraso("Nivel3MiniJuego3"));
    }

    public void nextGame3(int numeroUsuario)
    {
        Debug.Log("Boton Presionado");

        if (respuestaCorrecta != null)
        {

            if (numeroUsuario == respuestaCorrecta)
            {
                Debug.Log("Respuesta correcta");
                respuestaVisual.MostrarCorrecto();
                PuntosTareasManager.Instancia.AgregarPuntos(40);
            }
            else
            {
                Debug.Log("Respuesta incorrecta");
                respuestaVisual.MostrarIncorrecto();
            }
        }
        StartCoroutine(CambiarEscenaRetraso("EndScene2"));
    }

    public void Restart()
    {
        PuntosTareasManager.Instancia.ReiniciarPuntos();
        SceneManager.LoadScene("ChooseWork");
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        respuestaVisual = FindObjectOfType<RespuestaVisual>();
    }

    private System.Collections.IEnumerator CambiarEscenaRetraso(string nombreEscena)
    {
        yield return new WaitForSeconds(0.5f); 
        SceneManager.LoadScene(nombreEscena);
    }

}
