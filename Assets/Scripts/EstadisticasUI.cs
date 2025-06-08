using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class EstadisticasUI : MonoBehaviour
{
    public Text textoMonedas;
    public Text textoEstrellas;

    private int numEmpleado;

    void Start()
    {
        numEmpleado = PlayerPrefs.GetInt("numEmpleado", 0); 
        StartCoroutine(ObtenerEstadisticas(numEmpleado));
    }

    IEnumerator ObtenerEstadisticas(int id)
    {
        string url = $"https://10.22.220.253:7029/Estadisticas/Estadisticas/{id}";

        UnityWebRequest request = UnityWebRequest.Get(url);
        request.certificateHandler = new ForceAcceptAll();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError ||
            request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Error al obtener estadísticas: " + request.error);
        }
        else
        {
            string json = request.downloadHandler.text;
            Estadisticas estadisticas = JsonUtility.FromJson<Estadisticas>(json);

            textoMonedas.text = estadisticas.monedas.ToString();
            textoEstrellas.text = estadisticas.estrellas.ToString();
        }
    }

    public class Estadisticas
    {
        public int numEmpleado;
        public int monedas;
        public int estrellas;
    }

}
