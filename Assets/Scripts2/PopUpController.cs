using UnityEngine;
using UnityEngine.SceneManagement;

public class PopUpController : MonoBehaviour
{
    public GameObject popUp1;
    public GameObject popUp2;
    public GameObject popUp3;

    public GameObject popUpFinal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MostrarPopUp1()
    {
        // Implementar la lógica para mostrar el pop-up
        popUp1.SetActive(true);
    }
    public void OcultarPopUp1()
    {
        // Implementar la lógica para ocultar el pop-up
        popUp1.SetActive(false);
    }
    public void MostrarPopUp2()
    {
        // Implementar la lógica para mostrar el pop-up
        popUp2.SetActive(true);
    }
    public void OcultarPopUp2()
    {
        // Implementar la lógica para ocultar el pop-up
        popUp2.SetActive(false);
    }
    public void MostrarPopUp3()
    {
        // Implementar la lógica para mostrar el pop-up
        popUp3.SetActive(true);
    }
    public void OcultarPopUp3()
    {
        // Implementar la lógica para ocultar el pop-up
        popUp3.SetActive(false);
    }
    public void MostrarPopUpFinal()
    {
        // Implementar la lógica para mostrar el pop-up
        popUpFinal.SetActive(true);
    }
    public void OcultarPopUpFinal()
    {
        // Implementar la lógica para ocultar el pop-up
        popUpFinal.SetActive(false);
    }
    public void Salir()
    {// Verifica que sea el personaje
        SceneManager.LoadScene("LoginScene");  // Carga la escena especificada
    }
}
