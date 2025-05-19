using UnityEngine;

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
        }
    }

    // Función para alinear la burbuja a la cuadrícula en zigzag
    Vector3 AlinearCuadricula(Vector3 position)
    {
        float radius = 3.25f * transform.localScale.x;
        float width = radius * 2f;
        float height = Mathf.Sqrt(3) * radius;

        int row = Mathf.RoundToInt(position.y / height);
        float offsetX = (row % 2 == 0) ? 0f : radius;

        float x = Mathf.Round((position.x - offsetX) / width) * width + offsetX;
        float y = row * height;

        return new Vector3(x, y, position.z);
    }
}