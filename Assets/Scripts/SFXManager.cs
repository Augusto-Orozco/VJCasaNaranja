using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioClip sonidoDeFondo;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = 0.1f;
        audioSource.clip = sonidoDeFondo;
        audioSource.loop = true;
        audioSource.Play();
    }
}
