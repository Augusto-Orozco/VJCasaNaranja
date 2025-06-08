using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class NivelUsuario
{
    public int numEmpleado;
    public int idNivel;
    public int estrellas;
    public int puntuacion;
    public int tiempoNivel;
}

public class APIResultados : MonoBehaviour
{
    private string url = "https://10.22.220.253:7029/NivelUsuario/ActualizarIntento"; 

    public void EnviarResultado(NivelUsuario datos)
    {
        StartCoroutine(PutNivelUsuario(datos));
    }

    IEnumerator PutNivelUsuario(NivelUsuario datos)
    {
        string json = JsonUtility.ToJson(datos);

        UnityWebRequest request = UnityWebRequest.Put(url, json);
        request.method = UnityWebRequest.kHttpVerbPUT;
        request.certificateHandler = new ForceAcceptAll();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log(" Se enviaron los datos correctamente: " + request.downloadHandler.text);
        }
        else
        {
            Debug.LogError("Datos no enviados a la base de datos");
        }
    }
}
