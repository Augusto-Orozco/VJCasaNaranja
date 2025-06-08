using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ActualizadorMapa : MonoBehaviour
{
    public List<GameObject> mapas;

    private const string estrellasAPI = "https://10.22.220.253:7029/AugustoController3/ObtenerEstrellas";
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
                int totalEstrellas = respuesta.items[0].totalEstrellas;

                ActivarMapaPorEstrellas(totalEstrellas);
            }
        }
    }

    void ActivarMapaPorEstrellas(int estrellas)
    {
        // Desactiva todos los mapas primero
        foreach (var mapa in mapas)
            mapa.SetActive(false);

        // Activa el mapa según el rango de estrellas
        if (estrellas < 5)
        {
            mapas[0].SetActive(true); // Mapa base
        }
        else if (estrellas >= 5 && estrellas < 9)
        {
            mapas[1].SetActive(true); // Mapa intermedio
        }
        else // estrellas >= 9
        {
            mapas[2].SetActive(true); // Mapa avanzado
        }
    }


}


// -------- DTOs para respuesta de estrellas --------

[System.Serializable]
public class EstrellaDTO
{
    public int totalEstrellas;
}

[System.Serializable]
public class EstrellaResponse
{
    public List<EstrellaDTO> items;
}
