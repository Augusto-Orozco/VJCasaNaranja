using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    public void GotoMinigame1()
    {
        SceneManager.LoadScene("Nivel1MiniJuego3"); // Cargar la escena del menú
    }

    public void GotoMinigame2()
    {
    SceneManager.LoadScene("Nivel2MiniJuego3"); // Cargar la escena del menú
    }

    public void GotoMinigame3()
    {
    SceneManager.LoadScene("Nivel3MiniJuego3"); // Cargar la escena del menú
    }

    public void GotoEndScene()
    {
    SceneManager.LoadScene("EndScene2");
    }  

    public void ChangeScene()
    {
        SFXManagerTareas.Instancia.DetenerMusic();
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void ChangeScene2()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void GotoLeaderBoard()
    {
        SceneManager.LoadScene("LeaderBoard");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
