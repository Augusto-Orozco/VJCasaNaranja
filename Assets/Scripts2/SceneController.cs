using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneName;  // Nombre de la escena a cargar
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Verifica que sea el personaje
        {
            SceneManager.LoadScene(sceneName);  // Carga la escena especificada
        }
    }
}