using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAudioScript : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip[] audioClips;

    public float timeBetweenAudioClips = 5f;

    private float nextAudioClipTime;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAudioClipTime)
        {
            AudioClip randomClip =
                audioClips[Random.Range(0, audioClips.Length)];
            audioSource.clip = randomClip;
            audioSource.Play();
            nextAudioClipTime = Time.time + timeBetweenAudioClips;
        }
    }
}
