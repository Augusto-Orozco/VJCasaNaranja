using UnityEngine;

public class GridPrefab : MonoBehaviour
{
    public GameObject[] prefabs;
    public int filas = 8;
    public int columnas = 10;
    public float radio = 0.5f;

    public float altura = 2f; 
    public static Vector3 gridOffset; 



    void Start()
    {
        GenerarGrid();
    }

    public void AgregarFilaSuperior()
    {
        float height = Mathf.Sqrt(3f) * radio;

        // Mueve todo hacia abajo
        foreach (Transform hijo in transform)
            hijo.position -= new Vector3(0f, height, 0f);

        // Ajusta offset del grid
        gridOffset -= new Vector3(0f, height, 0f);

        int filaZigzag = filas; 
        float nuevaAlturaFila = height * filaZigzag;

        GenerarFilaEnPosicion(nuevaAlturaFila, filaZigzag);

        filas++;
    }



    void GenerarGrid()
    {
        float width = 2f * radio;
        float height = Mathf.Sqrt(3f) * radio;

        float totalWidth = columnas * width;
        float totalHeight = filas * height;

        gridOffset = new Vector3(-totalWidth / 2f, -totalHeight / 2f + altura, 0f);

        for (int y = 0; y < filas; y++)
        {
            float offsetX = (y % 2 == 0) ? 0f : radio;

            for (int x = 0; x < columnas; x++)
            {
                Vector3 posicion = new Vector3(x * width + offsetX, y * height, 0f) + gridOffset;
                GameObject prefabAleatorio = prefabs[Random.Range(0, prefabs.Length)];
                GameObject burbuja = Instantiate(prefabAleatorio, posicion, Quaternion.identity, transform);

                Rigidbody2D rb = burbuja.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.bodyType = RigidbodyType2D.Kinematic;
                    rb.gravityScale = 0f;
                }

                if (!burbuja.CompareTag("Burbuja"))
                    burbuja.tag = "Burbuja";

                TipoBurbuja tipo = burbuja.GetComponent<TipoBurbuja>();
                if (tipo != null)
                    tipo.esInicial = true;
            }
        }
    }
    void GenerarFilaEnPosicion(float alturaFila, int filaIndex)
    {
        float width = 2f * radio;
        float height = Mathf.Sqrt(3f) * radio;

        float offsetX = (filaIndex % 2 == 0) ? 0f : radio;
        Vector3 filaOffset = new Vector3(offsetX, alturaFila, 0f) + gridOffset;

        for (int x = 0; x < columnas; x++)
        {
            Vector3 posicion = new Vector3(x * width, 0f, 0f) + filaOffset;
            GameObject prefabAleatorio = prefabs[Random.Range(0, prefabs.Length)];
            GameObject burbuja = Instantiate(prefabAleatorio, posicion, Quaternion.identity, transform);

            Rigidbody2D rb = burbuja.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.bodyType = RigidbodyType2D.Kinematic;
                rb.gravityScale = 0f;
            }

            if (!burbuja.CompareTag("Burbuja"))
                burbuja.tag = "Burbuja";

            TipoBurbuja tipo = burbuja.GetComponent<TipoBurbuja>();
            if (tipo != null)
                tipo.esInicial = true;
        }
    }
}

