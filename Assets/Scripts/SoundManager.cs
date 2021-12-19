using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource EffectsSource;

    public float LowPitchRange = .95f;
    public float HighPitchRange = 1.05f;

    public static SoundManager Instance = null;

    public AudioClip Click;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        
    }

    public void Play(AudioClip clip)
    {
        if (clip)
        {
            EffectsSource.clip = clip;
            EffectsSource.Play();
        }
    }

    public void Play_Click()
    {
        Play(Click);
    }
}
