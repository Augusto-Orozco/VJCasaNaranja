using UnityEngine;


public class Esclavo : MonoBehaviour 
{
    void Start()
    {
        if (SFXManagerTareas.Instancia != null)
        {
            SFXManagerTareas.Instancia.IniciarMusicaSiNoSuena();
        }
    }
}
