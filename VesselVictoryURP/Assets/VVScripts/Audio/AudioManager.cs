using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	 
	public static AudioManager Instance = null;
	private AudioSource ambient, soundEffects;
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
    private void Start()
    {
		InitializeAudioSources();
    }
    private void InitializeAudioSources()
    {
		ambient = gameObject.AddComponent<AudioSource>();
		soundEffects = gameObject.AddComponent<AudioSource>();
    }
	public void PlayOneShotSound(AudioClip clip)
    {
		soundEffects.PlayOneShot(clip);
    }
	public void PlayBackgroundLoop(AudioClip clip)
    {
		ambient.clip = clip;
		ambient.loop = true;
		ambient.Play();
    }
	public void StopSound()
    {
		soundEffects.Stop();
    }
	
  
}
