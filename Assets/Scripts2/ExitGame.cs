using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void Exit()
    {
        // If we are running in the editor
        #if UNITY_EDITOR
            // Stop playing the scene
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            // Otherwise, if we are running in a standalone build or a web player
            Application.Quit();
        #endif
    }

}
