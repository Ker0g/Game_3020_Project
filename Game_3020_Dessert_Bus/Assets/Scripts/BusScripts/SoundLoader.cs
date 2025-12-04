using UnityEngine;

public class SoundLoader : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //SoundManager.AddSound("Shot", Resources.Load<AudioClip>("Shot"), SoundType.SOUND_SFX);
        //SoundManager.AddSound("Boom", Resources.Load<AudioClip>("Boom"), SoundType.SOUND_SFX);
        //SoundManager.AddSound("Hit", Resources.Load<AudioClip>("Hit"), SoundType.SOUND_SFX);

        //SoundManager.AddSound("NotApplicable", Resources.Load<AudioClip>("NotApplicable"), SoundType.SOUND_MUSIC);

        SoundManager.AddSound("sherbet", Resources.Load<AudioClip>("sherbet"), SoundType.SOUND_MUSIC);
        SoundManager.AddSound("boundless-blue", Resources.Load<AudioClip>("boundless-blue"), SoundType.SOUND_MUSIC);

        SoundManager.AddSound("collision", Resources.Load<AudioClip>("collision"), SoundType.SOUND_SFX);

        SoundManager.PlayMusic("sherbet");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
