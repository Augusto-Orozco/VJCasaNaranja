using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class DisparadorEscaner : MonoBehaviour
{
    public GameObject[] burbujaPrefabs;
    public Transform spawnPoint;
    public float velocidadRotacion = 150f;
    public float fuerzaDisparo = 1f;

    private GameObject burbujaActual;

    public PowerUp powerUpManager;
    public GameObject zonaDerrota;
    private float direccionRotacion = 0f;

    void Start()
    {
        generarBurbuja();
    }

    // Parte de la logica para utilizar botones para manejar el disparador.
    public void RotarIzquierda(bool activo)
    {
        direccionRotacion = activo ? -1f : 0f;
    }

    public void RotarDerecha(bool activo)
    {
        direccionRotacion = activo ? 1f : 0f;
    }

    public void BotonDisparar()
    {
        Disparar();
    }


    public GameObject GetBurbujaActual()
    {
        return burbujaActual;
    }

    void Update()
    {
    #if UNITY_EDITOR
        // Para seguir probando con teclado en la PC
        float input = Input.GetAxis("Horizontal");
        if (input != 0)
            direccionRotacion = input;
        else if (direccionRotacion != -1f && direccionRotacion != 1f)
            direccionRotacion = 0;

        if (Input.GetKeyDown(KeyCode.Space))
            Disparar();
    #endif

        rotarDisparador();
    }

    void rotarDisparador()
    {
        if (direccionRotacion == 0f) return;

        transform.Rotate(0, 0, -direccionRotacion * velocidadRotacion * Time.deltaTime);

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

        TipoBurbuja tipo = burbujaActual.GetComponent<TipoBurbuja>();
        if (tipo != null)
            tipo.esInicial = false;
    }


    public GridPrefab gridPrefab;

    int disparos = 0;

    void Disparar()
    {
        if (burbujaActual == null) return;

        Rigidbody2D rb = burbujaActual.GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 0f;
        rb.linearVelocity = spawnPoint.up.normalized * fuerzaDisparo;
        StartCoroutine(IgnorarZonaDerrotaTemporalmente(burbujaActual));


        burbujaActual = null;
        Invoke(nameof(generarBurbuja), 0.5f);

        disparos++;

        if (disparos % 8 == 0) 
        {
            gridPrefab.AgregarFilaSuperior();
        }

        if (disparos % 6 == 0)
        {
            string colorRandom = burbujaPrefabs[Random.Range(0, burbujaPrefabs.Length)].GetComponent<TipoBurbuja>().tipo;
            powerUpManager.MostrarPowerUp(colorRandom);
        }
    }
    IEnumerator IgnorarZonaDerrotaTemporalmente(GameObject bola)
    {
        Collider2D bolaCol = bola.GetComponent<Collider2D>();
        Collider2D zonaDerrotaCol = zonaDerrota.GetComponent<Collider2D>();

        if (bolaCol != null && zonaDerrotaCol != null)
            Physics2D.IgnoreCollision(bolaCol, zonaDerrotaCol, true);

        yield return new WaitForSeconds(0.5f);

        if (bolaCol != null && zonaDerrotaCol != null)
            Physics2D.IgnoreCollision(bolaCol, zonaDerrotaCol, false);
    }

}