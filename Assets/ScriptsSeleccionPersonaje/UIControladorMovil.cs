using UnityEngine;
using UnityEngine.EventSystems;

public class UIControladorMovil : MonoBehaviour
{
    public GameObject botonArriba;
    public GameObject botonAbajo;
    public GameObject botonIzquierda;
    public GameObject botonDerecha;

    private PlayerController personajeControlado;

    public void AsignarJugador(PlayerController nuevoJugador)
    {
        personajeControlado = nuevoJugador;

        AsignarEvento(botonArriba, EventTriggerType.PointerDown, () => personajeControlado.MoverArriba());
        AsignarEvento(botonArriba, EventTriggerType.PointerUp, () => personajeControlado.DetenerVertical());

        AsignarEvento(botonAbajo, EventTriggerType.PointerDown, () => personajeControlado.MoverAbajo());
        AsignarEvento(botonAbajo, EventTriggerType.PointerUp, () => personajeControlado.DetenerVertical());

        AsignarEvento(botonIzquierda, EventTriggerType.PointerDown, () => personajeControlado.MoverIzquierda());
        AsignarEvento(botonIzquierda, EventTriggerType.PointerUp, () => personajeControlado.DetenerHorizontal());

        AsignarEvento(botonDerecha, EventTriggerType.PointerDown, () => personajeControlado.MoverDerecha());
        AsignarEvento(botonDerecha, EventTriggerType.PointerUp, () => personajeControlado.DetenerHorizontal());
    }

    private void AsignarEvento(GameObject boton, EventTriggerType tipo, UnityEngine.Events.UnityAction accion)
    {
        EventTrigger trigger = boton.GetComponent<EventTrigger>();
        if (trigger == null)
        {
            trigger = boton.AddComponent<EventTrigger>();
        }

        var entry = new EventTrigger.Entry { eventID = tipo };
        entry.callback.AddListener((_) => accion.Invoke());
        trigger.triggers.Add(entry);
    }
}
