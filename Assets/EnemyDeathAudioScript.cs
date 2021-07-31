using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathAudioScript : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip[] deathAudioClips;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        AudioClip randomClip =
            deathAudioClips[Random.Range(0, deathAudioClips.Length)];
        audioSource.clip = randomClip;
        audioSource.Play();
    }
}
