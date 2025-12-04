using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum SoundType
{
    SOUND_SFX,
    SOUND_MUSIC
}

public static class SoundManager
{
    public static float masterVolume;
    public static float musicVolume;
    public static float sfxVolume;
    public static float panning;
    private static Dictionary<string, AudioClip> sfxDictionary; // Reference value to a Dictionary that will be created.
    private static Dictionary<string, AudioClip> musicDictionary;
    private static AudioSource sfxSource; // Reference to an AudioSource created later.
    private static AudioSource musicSource;
   
   

    static SoundManager() // Static constructor. Gets called the first time the class is accessed.
    {
        Debug.Log("Invoking SoundManager constructor...");
        sfxDictionary = new Dictionary<string, AudioClip>();
        musicDictionary = new Dictionary<string, AudioClip>();
        Initialize();
    }

    // Initialize the SoundManager. I just put this functionality here instead of in the static constructor.
    private static void Initialize()
    {
        // Create a new GameObject to hold the AudioSource
        GameObject soundManagerObject = new GameObject("SoundManagerObject");
        // Now create and attach the AudioSources to the new GameObject.
        
        sfxSource = soundManagerObject.AddComponent<AudioSource>();
        sfxSource.volume = 0.50f; // 1.0f is default.
        musicSource = soundManagerObject.AddComponent<AudioSource>();
        musicSource.volume = 0.20f;
        musicSource.loop = true; // false is default.
        GameObject.DontDestroyOnLoad(soundManagerObject);
    }

    // Add a sound to the dictionary.
    public static void AddSound(string soundKey, AudioClip audioClip, SoundType soundType)
    {
        // Return if audioClip didn't load properly.
        if (audioClip == null)
        {
            Debug.LogError("Error loading AudioClip!");
            return;
        }
        Debug.Log("Adding new sound with key of " + soundKey);
        // Create a temporary field of the associated Dictionary.
        Dictionary<string, AudioClip> targetDictionary = GetDictionaryByType(soundType);
        if (!targetDictionary.ContainsKey(soundKey))
        {
            targetDictionary.Add(soundKey, audioClip);
        }
        else
        {
            Debug.LogWarning("Key " + soundKey + " already exists in dictionary.");
        }
    }

    // Play a sound by key interface.
    public static void PlaySound(string soundKey)
    {
        if (sfxDictionary.ContainsKey(soundKey))
        {
            sfxSource.PlayOneShot(sfxDictionary[soundKey]);
        }
    }

    // Play music by key interface.
    public static void PlayMusic(string soundKey)
    {
        if (musicDictionary.ContainsKey(soundKey))
        {
            musicSource.Stop();
            musicSource.clip = musicDictionary[soundKey];
            musicSource.Play();
        }
    }

    public static void Please()
    {
        musicSource.volume = musicVolume * masterVolume;
        sfxSource.volume = sfxVolume * masterVolume;
        musicSource.panStereo = panning;
        sfxSource.panStereo = panning;

    }

    private static Dictionary<string, AudioClip> GetDictionaryByType(SoundType soundType)
    {
        switch(soundType)
        {
            case SoundType.SOUND_SFX:
                return sfxDictionary;
            case SoundType.SOUND_MUSIC:
                return musicDictionary;
            default:
                return null;
        }
    }
}