using UnityEngine;
using System.Collections.Generic;


public class Spawner : MonoBehaviour
{
    public float gridSize = 1.0f;  // Tamaño de la celda de la cuadrícula

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Pared") || collision.collider.CompareTag("Burbuja"))
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.linearVelocity = Vector2.zero;  // Detener la burbuja
            rb.bodyType = RigidbodyType2D.Kinematic;

            // Alinea la burbuja a la cuadrícula
            Vector3 alignedPosition = AlinearCuadricula(transform.position);
            transform.position = alignedPosition;

            // Aquí haces que la burbuja se haga hija del grid
            GridPrefab grid = FindObjectOfType<GridPrefab>();
            if (grid != null)
            {
                transform.SetParent(grid.transform);
            }
        }
        TipoBurbuja tipo = GetComponent<TipoBurbuja>();
        if (tipo != null)
        {
            BuscarConectadas(gameObject); // Esta función se encarga de destruir si es necesario
        }
    }

    // Función para alinear la burbuja a la cuadrícula en zigzag
    Vector3 AlinearCuadricula(Vector3 position)
    {
        float radio = 0.5f; // Usa el mismo valor exacto del GridPrefab
        float width = 2f * radio;
        float height = Mathf.Sqrt(3f) * radio;

        Vector3 relativePos = position - GridPrefab.gridOffset;
        int fila = Mathf.RoundToInt(relativePos.y / height);
        float offsetX = (fila % 2 == 0) ? 0f : radio;
        int columna = Mathf.RoundToInt((relativePos.x - offsetX) / width);

        float x = columna * width + offsetX;
        float y = fila * height;
        return new Vector3(x, y, position.z) + GridPrefab.gridOffset;
    }


    List<GameObject> BuscarConectadas(GameObject inicio)
    {
        List<GameObject> resultado = new List<GameObject>();
        Queue<GameObject> cola = new Queue<GameObject>();
        HashSet<GameObject> visitados = new HashSet<GameObject>();

        TipoBurbuja tipoInicio = inicio.GetComponent<TipoBurbuja>();
        if (tipoInicio == null) return resultado;

        string tipoObjetivo = tipoInicio.tipo;
        bool hayNoInicial = !tipoInicio.esInicial;

        cola.Enqueue(inicio);
        visitados.Add(inicio);

        float radioBusqueda = 0.7f;

        while (cola.Count > 0)
        {
            GameObject actual = cola.Dequeue();
            resultado.Add(actual);

            Collider2D[] cercanos = Physics2D.OverlapCircleAll(actual.transform.position, radioBusqueda);
            foreach (var col in cercanos)
            {
                if (col.CompareTag("Burbuja") && !visitados.Contains(col.gameObject))
                {
                    TipoBurbuja tipoVecino = col.GetComponent<TipoBurbuja>();
                    if (tipoVecino != null && tipoVecino.tipo == tipoObjetivo)
                    {
                        cola.Enqueue(col.gameObject);
                        visitados.Add(col.gameObject);

                        if (!tipoVecino.esInicial)
                            hayNoInicial = true;
                    }
                }
            }
        }

        // Solo destruir si hay al menos una burbuja disparada Y todas son del mismo tipo

        if (resultado.Count >= 6 && hayNoInicial)
        {
            // Buscar el color
            string color = tipoInicio.tipo;

            Consejos sistemaConsejos = FindObjectOfType<Consejos>();
            if (sistemaConsejos != null)
                sistemaConsejos.MostrarConsejo(color);
        }


        if (resultado.Count >= 3 && hayNoInicial)
        {
            foreach (var burbuja in resultado)
            {
                Destroy(burbuja);
            }
            if (GameManager.instancia != null)
                GameManager.instancia.SumarPuntos(resultado.Count * 10);
        }

        return resultado;
    }

}