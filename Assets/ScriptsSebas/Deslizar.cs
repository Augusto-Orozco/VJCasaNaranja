using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Deslizar : MonoBehaviour
{
    public CardManager manager; // Referencia al CardManager
    private Vector2 initialPosition; // Guarda la posición inicial del objeto
    private Vector2 difference; // Diferencia entre la posición del mouse y el objeto al hacer clic
    private bool isDragging = false; // Indica si el objeto está siendo arrastrado
    public TimerBar timerBar;
    public RespuestaVisual respuestaVisual;

    void Start()
    {
        // Se guarda la posición inicial al comenzar
        initialPosition = transform.position;
        respuestaVisual = FindObjectOfType<RespuestaVisual>();
        PuntosCartasBehaviour.Instancia.ResetPuntos();
        SFXManagerCartas.Instancia.EmpezarMusica();

    }

    private void OnMouseDown()
    {
        // Calcula la diferencia entre el mouse y la posición del objeto
        if (!timerBar.juegoIniciado) return;

        if (EstaTocandoUI()) return;

        difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
        isDragging = true; // Activa el arrastre
    }

    private void OnMouseDrag()
    {
        if (!isDragging || !timerBar.juegoIniciado) return;

        if (isDragging)
        {
            // Actualiza la posición del objeto mientras se arrastra con el mouse
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition - difference;
        }
    }

    private void OnMouseUp()
    {
        if (!timerBar.juegoIniciado) return;
        isDragging = false; // Termina el arrastre
        float desplazamientoX = transform.position.x - initialPosition.x; // Calcula cuánto se movió en el eje X

        // Si el objeto se desliza lo suficiente a la derecha
        if (desplazamientoX > 1f)
            StartCoroutine(DeslizarFuera(Vector2.right));
        // Si el objeto se desliza lo suficiente a la izquierda
        else if (desplazamientoX < -1f)
            StartCoroutine(DeslizarFuera(Vector2.left));
        // Si el movimiento no fue suficiente, vuelve a la posición original
        else
            StartCoroutine(VolverAPosicion());
    }

    // Corrutina para deslizar el objeto hacia fuera de la pantalla
    IEnumerator DeslizarFuera(Vector2 direccion)
    {
        Debug.Log("Entrando en la corrutina DeslizarFuera.");

        CardBehavior card = GetComponent<CardBehavior>();
        if (card != null)
        {
            int selection = (direccion == Vector2.right) ? 2 : 1;

            if (selection == card.datos.respuestaCorrecta)
            {
                Debug.Log("Respuesta correcta");
                respuestaVisual.MostrarCorrecto();
                PuntosCartasBehaviour.Instancia.AgregarPuntos(200);
                SFXManagerCartas.Instancia.ReproducirCorrecto();
            }
            else
            {
                Debug.Log("Respuesta incorrecta");
                respuestaVisual.MostrarIncorrecto();
                PuntosCartasBehaviour.Instancia.RestarPuntos(200);
                SFXManagerCartas.Instancia.ReproducirIncorrecto();
            }
        }

        while (Mathf.Abs(transform.position.x) < 10f)
        {
            transform.position += (Vector3)direccion * 30f * Time.deltaTime;
            yield return null;
        }

        // Verifica que el objeto no haya sido destruido antes de destruirlo
        if (gameObject != null)
        {
            Destroy(gameObject); // Elimina la tarjeta actual
        }

        // Verifica si hay más tarjetas después de deslizar la tarjeta
        if (manager != null)
        {
            Debug.Log("Verificando si hay más tarjetas...");

            if (manager.HayMasTarjetas())
            {
                Debug.Log("Aún hay más tarjetas.");
                manager.MostrarSiguienteTarjeta();
            }
            else
            {
                Debug.Log("No hay más tarjetas, terminando juego.");
                manager.TerminarJuego(); // Cambia de escena cuando ya no haya más tarjetas
                timerBar.juegoIniciado = false; // Detener el temporizador aquí
            }
        }
    }
    // Corrutina para volver suavemente a la posición original
    IEnumerator VolverAPosicion()
    {
        // Mientras no esté lo suficientemente cerca de la posición original
        while (Vector2.Distance(transform.position, initialPosition) > 0.01f)
        {
            // Interpola suavemente hacia la posición original
            transform.position = Vector2.Lerp(transform.position, initialPosition, 10f * Time.deltaTime);
            yield return null; // Espera un frame
        }
        // Asegura que la posición final sea exactamente la inicial
        transform.position = initialPosition;
    }
 
    bool EstaTocandoUI()
    {
        if (Input.touchCount > 0)
        {   
            
            Touch touch = Input.GetTouch(0);
            PointerEventData eventData = new PointerEventData(EventSystem.current);
            eventData.position = touch.position;

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);
            foreach (var result in results)
            {
                Debug.Log("Tocando objeto UI: " + result.gameObject.name);
            }


            return results.Count > 0;
        }
        else if (Input.GetMouseButtonDown(0)) 
        {

            PointerEventData eventData = new PointerEventData(EventSystem.current);
            eventData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);

            foreach (var result in results)
            {
                Debug.Log("Tocando objeto UI: " + result.gameObject.name);
            }

            return results.Count > 0;
        }

        return false;
    }

}