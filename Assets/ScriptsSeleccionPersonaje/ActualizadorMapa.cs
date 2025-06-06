using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ActualizadorMapa : MonoBehaviour
{
    public List<GameObject> mapas;

    private const string estrellasAPI = "https://localhost:7029/AugustoController3/ObtenerEstrellas";
    private int numEmpleadoSesion;

    void Start()
    {
        numEmpleadoSesion = PlayerPrefs.GetInt("numEmpleado", 0);
        StartCoroutine(CargarMapaPorEstrellas());
    }

    IEnumerator CargarMapaPorEstrellas()
    {
        string url = $"{estrellasAPI}?numEmpleado={numEmpleadoSesion}";
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error al obtener estrellas: " + www.error);
            }
            else
            {
                string json = "{\"items\":" + www.downloadHandler.text + "}";
                EstrellaResponse respuesta = JsonUtility.FromJson<EstrellaResponse>(json);
                int totalEstrellas = respuesta.items[0].TotalEstrellas;

                ActivarMapaPorEstrellas(totalEstrellas);
            }
        }
    }

    void ActivarMapaPorEstrellas(int estrellas)
    {
        // Siempre dejar activo el mapa base (mapas[0])
        mapas[0].SetActive(true);

        // Desactivar los mapas secundarios antes de activar el correcto
        mapas[1].SetActive(false);
        mapas[2].SetActive(false);

        if (estrellas == 5)
            mapas[1].SetActive(true); // Mapa intermedio
        else if (estrellas == 9)
            mapas[2].SetActive(true); // Mapa avanzado
    }
}


// -------- DTOs para respuesta de estrellas --------

[System.Serializable]
public class EstrellaDTO
{
    public int TotalEstrellas;
}

[System.Serializable]
public class EstrellaResponse
{
    public List<EstrellaDTO> items;
}
