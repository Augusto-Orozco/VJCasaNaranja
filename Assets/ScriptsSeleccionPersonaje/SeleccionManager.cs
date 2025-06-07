using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SeleccionManager : MonoBehaviour
{
    public List<GameObject> personajes;
    public List<AudioSource> canciones;


    private const string personajesAPI = "https://localhost:7029/Augusto/ObtenerPersonajes";
    private const string cancionesAPI = "https://localhost:7029/AugustoController2/ObtenerCanciones";

    private int numEmpleadoSesion;

    void Start()
    {
        numEmpleadoSesion = PlayerPrefs.GetInt("numEmpleado", 0);

        StartCoroutine(CargarPersonaje());
        StartCoroutine(CargarCancion());

    }

    IEnumerator CargarPersonaje()
    {

        string url = $"{personajesAPI}?numEmpleado={numEmpleadoSesion}";
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error al obtener personaje: " + www.error);
            }
            else
            {
                string json = "{\"items\":" + www.downloadHandler.text + "}";
                PersonajeResponse respuesta = JsonUtility.FromJson<PersonajeResponse>(json);
                ActivarPersonaje(respuesta.items[0].nombreAspecto);
            }
        }
    }

    IEnumerator CargarCancion()
    {
        string url = $"{cancionesAPI}?numEmpleado={numEmpleadoSesion}";
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error al obtener canción: " + www.error);
            }
            else
            {
                string json = "{\"items\":" + www.downloadHandler.text + "}";
                TrackResponse respuesta = JsonUtility.FromJson<TrackResponse>(json);
                ActivarCancion(respuesta.items[0].nombreMusica);
            }
        }
    }

    void ActivarPersonaje(string nombre)
    {
        foreach (var personaje in personajes)
            personaje.SetActive(personaje.name == nombre);
    }

    void ActivarCancion(string nombre)
    {
        foreach (var cancion in canciones)
        {
            bool esSeleccionada = cancion.gameObject.name == nombre;
    
            cancion.gameObject.SetActive(esSeleccionada);
    
            if (esSeleccionada)
            {
                cancion.Play();
            }
            else
            {
                cancion.Stop();
            }
        }
    }

}

// -------- Clases auxiliares (DTOs) --------

[System.Serializable]
public class PersonajeDTO
{
    public int idPersonalizacion;
    public string nombreAspecto;
}

[System.Serializable]
public class PersonajeResponse
{
    public List<PersonajeDTO> items;
}

[System.Serializable]
public class TrackDTO
{
    public int idPersonalizacion;
    public string nombreMusica;
}

[System.Serializable]
public class TrackResponse
{
    public List<TrackDTO> items;
}
