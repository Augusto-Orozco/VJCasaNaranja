using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void CambiarEscena()
    {

        SceneManager.LoadScene("SampleScene");
        PuntosCartasBehaviour.Instancia.ResetPuntos();
        SFXManagerCartas.Instancia.ResetMusica();
    }
    void Start()
    {
        
    }
    public void ExitGame() //para salir del juego
    {
        SceneManager.LoadScene("MenuPrincipal");
        PuntosCartasBehaviour.Instancia.ResetPuntos();
        SFXManagerCartas.Instancia.DetenerMusic();
        //UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit(); //Para aplicacion y salir
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
