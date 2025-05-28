using UnityEngine;

public class PuntosTareasManager : MonoBehaviour
{
    public static PuntosTareasManager Instancia;

    public int puntos = 0;

    private void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AgregarPuntos(int cantidad)
    {
        puntos += cantidad;
    }

    public void ReiniciarPuntos()
    {
        puntos = 0;
    }
}
