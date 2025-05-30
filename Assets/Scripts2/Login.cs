using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using System.Collections;

public class Login : MonoBehaviour
{
    public InputField usuarioInput;
    public InputField contraseñaInput;
    public Text mensajeError;

    string urlBase = "https://localhost:7029/Login/login/"; 

    public void IntentarLogin()
    {
        int numEmpleado;
        if (int.TryParse(usuarioInput.text, out numEmpleado))
        {
            StartCoroutine(VerificarCredenciales(numEmpleado, contraseñaInput.text));
        }
        else
        {
            mensajeError.text = "Contraseña o usuario incorrecto.";
        }
    }

    IEnumerator VerificarCredenciales(int numEmpleado, string contraseñaIngresada)
    {
        UnityWebRequest request = UnityWebRequest.Get(urlBase + numEmpleado);
        request.certificateHandler = new ForceAcceptAll();
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            mensajeError.text = "Error al conectar con la API.";
            yield break;
        }

        Usuario datos = JsonConvert.DeserializeObject<Usuario>(request.downloadHandler.text);

        if (datos != null && datos.contraseña == contraseñaIngresada)
        {
            PlayerPrefs.SetInt("numEmpleado", datos.numEmpleado);
            SceneManager.LoadScene("MenuPrincipal");
        }

        else
        {
            mensajeError.text = "Usuario o contraseña incorrectos.";
        }
    }
}

[System.Serializable]
public class Usuario
{
    public int numEmpleado;
    public string contraseña;
}
