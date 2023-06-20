using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	 
	public static AudioManager Instance = null;
	private AudioSource ambient1, ambient2, soundEffects, spatialSoundEffects;

	[SerializeField] private AudioClip ambientSound1, ambientSound2;
	
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
		AmbientBackGround(ambientSound1, ambientSound2);

	}
    private void InitializeAudioSources()
    {
		ambient1 = gameObject.AddComponent<AudioSource>();
		ambient2 = gameObject.AddComponent<AudioSource>();

		soundEffects = gameObject.AddComponent<AudioSource>();
		spatialSoundEffects = gameObject.AddComponent<AudioSource>();
    }
	[Tooltip("Volume between 0 , 1")]
	public void PlayOneShotSound(AudioClip clip, float volume)
    {
		volume = Mathf.Clamp01(volume);
		soundEffects.volume = volume;
		soundEffects.PlayOneShot(clip);
    }
	public void PlayOneShotSpatialSound(AudioClip clip, float volume, float pan)
	{
		volume = Mathf.Clamp01(volume);
		spatialSoundEffects.volume = volume;
		spatialSoundEffects.PlayOneShot(clip);
		pan = Mathf.Clamp(pan, -1f, 1f);
		spatialSoundEffects.panStereo = pan;
	}
	private void AmbientBackGround(AudioClip clip1, AudioClip clip2)
	{
		PlayLoop(ambient1, clip1, 0.5f);
		PlayLoop(ambient2, clip2, 0.1f);
	}
	public void PlayLoop(AudioSource audioSource, AudioClip clip, float volume)
    {
		volume = Mathf.Clamp01(volume);
		audioSource.volume = volume;
		audioSource.clip = clip;
		audioSource.loop = true;
		audioSource.Play();
    }
	public void StopSoundEffects()
    {
		soundEffects.Stop();
    }
	public void StopBackGroundLoop()
    {
		ambient1.Stop();
		ambient2.Stop();
    }
	
  
}
