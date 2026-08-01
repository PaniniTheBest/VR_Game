using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    [SerializeField] AudioClip music;
    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySong()
    {
        audioSource.clip = music;
        audioSource.Play();
    }
}
