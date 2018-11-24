using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager instance;

    public AudioSource sfxSource;
    public AudioSource musicSource;

    private float lowPitchRange = .95f;
    private float highPitchRange = 1.05f;

	// Use this for initialization
	void Awake () {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
	}

    private void Start()
    {
        /*
        AudioSource[] sources = GetComponents<AudioSource>();
        sfxSource = sources[0];
        musicSource = sources[1];
        sfxSource.playOnAwake = false;
        */
    }

    public void PlayerSingle(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.Play();
    }

    public void RandomiseSfx (params AudioClip [] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);

        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        sfxSource.pitch = randomPitch;

        sfxSource.PlayOneShot(clips[randomIndex]);
    }
}
