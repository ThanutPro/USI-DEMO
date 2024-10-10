using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clip")]
    public AudioClip background;
    public AudioClip LaserPlayer;
    public AudioClip LaserEnemy;
    public AudioClip ExplodeEnemy;
    public AudioClip ExplodeAster;

    // Start is called before the first frame update
    private void Start()
    {
        // Assign and play the background music
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);

    }
}
