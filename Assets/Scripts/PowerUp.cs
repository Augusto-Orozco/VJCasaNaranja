using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    public Button botonPowerUp;
    private string colorObjetivo;
    private DisparadorEscaner disparador;
    public Text tituloPowerUp;
    public Text descripcionPowerUp;

    public UIController controladorUI;

    void Start()
    {
        disparador = FindObjectOfType<DisparadorEscaner>();
        botonPowerUp.interactable = false;
        botonPowerUp.gameObject.SetActive(false);
        botonPowerUp.onClick.AddListener(ActivarPowerUp);
    }

    public void MostrarPowerUp(string color)
    {
        colorObjetivo = color;


        ActualizarDescripcion();


        controladorUI.PlayPoder();

        botonPowerUp.gameObject.SetActive(true);  // Mostrar el botón
        botonPowerUp.interactable = true;
    }

    public void ActivarPowerUp()
    {
        {
            Debug.Log("Se quiere destruir las bolas: " + colorObjetivo.Trim().ToLower());

            GameObject[] burbujas = GameObject.FindGameObjectsWithTag("Burbuja");
            int eliminadas = 0;

            GameObject burbujaActual = disparador != null ? disparador.GetBurbujaActual() : null;

            foreach (GameObject b in burbujas)
            {
                TipoBurbuja tipo = b.GetComponent<TipoBurbuja>();
                if (tipo != null && tipo.tipo == colorObjetivo && b != burbujaActual)
                {
                    Destroy(b);
                    eliminadas++;
                }
            }

            if (GameManager.instancia != null)
                GameManager.instancia.SumarPuntos(eliminadas * 10);
        }
        botonPowerUp.gameObject.SetActive(false);
        botonPowerUp.interactable = false;
    }
    
    
    void ActualizarDescripcion()
    {
        Debug.Log(colorObjetivo.Trim().ToLower());
        switch (colorObjetivo.Trim().ToLower())
        {
            case "roja":
                tituloPowerUp.text = "Descuentos Especiales (Elimina Piezas Rojas)";
                descripcionPowerUp.text = "Una promoción bien implementada puede aumentar ventas y mejorar la experiencia del cliente.";
                break;
            case "azul":
                tituloPowerUp.text = "Servicio al Cliente (Elimina Piezas Azules)";
                descripcionPowerUp.text = "Brindar atención con empatía fortalece la lealtad del comprador.";
                break;
            case "verde":
                tituloPowerUp.text = "Eficiencia Operativa (Elimina Piezas Verdes)";
                descripcionPowerUp.text = "Optimiza procesos para ahorrar tiempo y mejorar el rendimiento.";
                break;
            case "amarilla":
                tituloPowerUp.text = "Orden y Limpieza (Elimina Piezas Amarillas)";
                descripcionPowerUp.text = "Un entorno limpio es clave para una experiencia de compra agradable.";
                break;
            case "morado":
                tituloPowerUp.text = "Liderazgo y Motivación (Elimina Piezas Moradas)";
                descripcionPowerUp.text = "Un buen líder inspira a su equipo y promueve un ambiente positivo.";
                break;
            default:
                tituloPowerUp.text = "Power-Up Activado";
                descripcionPowerUp.text = "¡Sigue usando tus habilidades para destacar en la tienda!";
                break;
        }
    }
}
