using UnityEngine;

public class DisparadorEscaner : MonoBehaviour
{
    public GameObject[] burbujaPrefabs;
    public Transform spawnPoint;
    public float velocidadRotacion = 150f;
    public float fuerzaDisparo = 1f;

    private GameObject burbujaActual;

    void Start()
    {
        generarBurbuja();
    }

    void Update()
    {
        rotarDisparador();
        if (Input.GetKeyDown(KeyCode.Space))
            Disparar();
    }

    void rotarDisparador()
    {
        float input = Input.GetAxis("Horizontal");
        transform.Rotate(0, 0, -input * velocidadRotacion * Time.deltaTime);

        // Limita el ángulo
        float z = transform.eulerAngles.z;
        if (z > 180 && z < 280) z = 280;
        else if (z < 180 && z > 80) z = 80;
        transform.eulerAngles = new Vector3(0, 0, z);
    }

    void generarBurbuja()
    {
        //Genera un prefab de burbuja random asegurandose que sea estatico
        GameObject selectedPrefab = burbujaPrefabs[Random.Range(0, burbujaPrefabs.Length)];
        burbujaActual = Instantiate(selectedPrefab, spawnPoint.position, Quaternion.identity);
        burbujaActual.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }

    void Disparar()
    {
        if (burbujaActual == null) return;

        //Obtiene el componente Rigidbody2D y cambia su estado a dinámico para permitirle moverse
        Rigidbody2D rb = burbujaActual.GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 0f; //Mantiene la gravedad desactivada
        rb.linearVelocity = spawnPoint.up.normalized * fuerzaDisparo;

        burbujaActual = null;
        // Vuelve a cargar una nueva burbuja después de un pequeño retraso
        Invoke(nameof(generarBurbuja), 0.5f);
    }
}