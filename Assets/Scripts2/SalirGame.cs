using UnityEngine;
using UnityEngine.SceneManagement;
public class SalirGame : MonoBehaviour
{

    public void nextGame1()
    {
        SceneManager.LoadScene("Nivel2MiniJuego3");
    }

    public void nextGame2()
    {
        SceneManager.LoadScene("Nivel3MiniJuego3");
    }

    public void nextGame3()
    {
        SceneManager.LoadScene("EndScene2");
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
