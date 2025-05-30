using UnityEngine;

public class DatosUsuario : MonoBehaviour
{
    public int numEmpleado;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject); 
    }
}
