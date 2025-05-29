using UnityEngine;
using UnityEngine.UI;

public class Consejos : MonoBehaviour
{
    public Animator animacionConsejo;
    public Text textoConsejo;
    public Text tituloConsejo;

    

    public void MostrarConsejo(string color)
    {
        string consejo = "";

        string titulo = "";


        switch (color.ToLower())
        {
            case "azul":
                titulo = "Atención Estelar";
                consejo = "Siempre que atiendas a un comprador con una sonrisa, querrá regresar.";
                break;
            case "verde":
                titulo = "Inventario en Orden";
                consejo = "Organiza tu inventario para facilitar tu trabajo diario.";
                break;
            case "roja":
                titulo = "Promoción Especial";
                consejo = "Revisa constantemente las fechas de caducidad de los productos.";
                break;
            case "amarilla":
                titulo = "Espacio Brillante";
                consejo = "Mantén siempre tu área de trabajo limpia y ordenada.";
                break;
            case "morado":
                    titulo = "Lider y Motivación";
                    consejo = "Un buen líder inspira a su equipo y promueve un ambiente positivo.";
                    break;
            default:
                titulo = "Consejo del Día";
                consejo = "¡Sigue esforzándote y serás un gran líder de tienda!";
                break;
        }


        if (textoConsejo != null)
            textoConsejo.text = consejo;

        if (tituloConsejo != null)
            tituloConsejo.text = titulo;

        if (animacionConsejo != null)
            animacionConsejo.SetTrigger("PlayPopUp");
    }
    
}
