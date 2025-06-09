using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

[System.Serializable]
public class LeaderboardEntry
{
    public string nombre;
    public string apellidoP;
    public int puntuacionTotal;
    public int totalEstrellas;
}


[System.Serializable]
public class LeaderboardResponse
{
    public List<LeaderboardEntry> entries;
}

public class LeaderboardManager : MonoBehaviour
{
    public Text resultados;

    private void Start()
    {
        StartCoroutine(GetLeaderboard());
    }

    IEnumerator GetLeaderboard()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://10.22.220.253:7029/Leaderboard/Top10");
        www.certificateHandler = new ForceAcceptAll();
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error al obtener el leaderboard: " + www.error);
            resultados.text = "No se pudo cargar el leaderboard.";
            yield break;
        }

        string json = www.downloadHandler.text;
        Debug.Log("JSON recibido: " + json);

        string jsonArreglado = "{\"entries\":" + json + "}";

        LeaderboardResponse response = JsonUtility.FromJson<LeaderboardResponse>(jsonArreglado);

        if (response == null || response.entries == null || response.entries.Count == 0)
        {
            resultados.text = "No hay datos disponibles.";
            yield break;
        }

        string resultado = "";

        for (int i = 0; i < response.entries.Count; i++)
        {
            var entry = response.entries[i];
            int lugar = i + 1;
            string nombreResaltado = $"<b>{entry.nombre} {entry.apellidoP}</b>";
            string linea = $"{lugar}. {nombreResaltado} — Puntos: {entry.puntuacionTotal} — Estrellas: {entry.totalEstrellas}";

            if (i == 0)
                resultado += $"<color=#DAA520><b>{linea}</b></color>\n\n";
            else if (i == 1)
                resultado += $"<color=#A9A9A9><b>{linea}</b></color>\n\n";
            else if (i == 2)
                resultado += $"<color=#B87333><b>{linea}</b></color>\n\n";
            else
                resultado += linea + "\n\n";
        }

        resultados.text = resultado;
    }
}