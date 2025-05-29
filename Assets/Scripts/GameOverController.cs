using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Burbuja"))
        {
            // Guardamos el puntaje actual
            PlayerPrefs.SetInt("PuntajeFinal", GameManager.instancia.puntaje);
            Debug.Log(GameManager.instancia.puntaje);

            // Cargamos la escena de fin de juego
            FindFirstObjectByType<ContadorTiempo>().DetenerContador();
            SceneManager.LoadScene("BubbleEnd");
        }
    }
}
