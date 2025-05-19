using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartToPlay()
    {
        SceneManager.LoadScene("LoginScene");
    }

    public void ExitGame()
    {
        // Sale del juego cuando se preciona el botón "Exit"
        // Si se está ejecutando en el editor de Unity, detiene la ejecución del juego
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
