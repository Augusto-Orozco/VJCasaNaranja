using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RespuestaVisual : MonoBehaviour
{
    public CanvasGroup checkmark;
    public CanvasGroup ximage;
    public float tiempoVisible = 1f; 

    void Start()
    {
        if (checkmark != null) checkmark.alpha = 0f;
        if (checkmark != null) checkmark.alpha = 0f;
    }

    public void MostrarCorrecto()
    {
        StartCoroutine(MostrarFeedback(checkmark));
    }

    public void MostrarIncorrecto()
    {
        StartCoroutine(MostrarFeedback(ximage));
    }

    private IEnumerator MostrarFeedback(CanvasGroup imagen)
    {
        imagen.alpha = 1f;
        imagen.transform.localScale = Vector3.zero;

        float t = 0f;
        while (t < 0.2f)
        {
            imagen.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, t / 0.2f);
            t += Time.deltaTime;
            yield return null;
        }

        imagen.transform.localScale = Vector3.one;
        yield return new WaitForSeconds(tiempoVisible);

        imagen.alpha = 0f;
    }
}
