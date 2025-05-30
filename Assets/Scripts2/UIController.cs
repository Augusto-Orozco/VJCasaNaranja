using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public Animator animator;
    public Animator poderAnimator;

    public void Play()
    {
        animator.SetTrigger("PlayPopUp");
    }

    public void PlayPoder()
    {
        poderAnimator.SetTrigger("PlayPoder");
    }
    
    public void CambiarEscena(){
        
        SceneManager.LoadScene("BubbleEnd");
    }

    public void RecargarJuego(){
        
        SceneManager.LoadScene("BubbleGame");
    }
 
    public void ExitGame() 
    {
        PlayerPrefs.DeleteKey("numEmpleado");
        UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit(); //Para aplicacion y salir
    }
}