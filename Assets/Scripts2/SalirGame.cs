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

    // Update is called once per frame
    void Update()
    {

    }

    private System.Collections.IEnumerator CambiarEscenaRetraso(string nombreEscena)
    {
        yield return new WaitForSeconds(1.5f); 
        SceneManager.LoadScene(nombreEscena);
    }

}
