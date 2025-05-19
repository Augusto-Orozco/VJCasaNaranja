using UnityEngine;

public class PopUpFinal : MonoBehaviour
{
    public GameObject popUpFinal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Player"))  // Verifica que sea el personaje
    {
        popUpFinal.SetActive(true);  // Carga la escena especificada
    }
}
}
