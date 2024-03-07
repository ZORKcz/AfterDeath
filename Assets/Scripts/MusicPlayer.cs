using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource introSource, loopSource;
    public bool playOnlyOnce;
    // Start is called before the first frame update
    void Start()
    {
        playOnlyOnce = false;
        introSource.Play();
        loopSource.PlayScheduled(AudioSettings.dspTime + introSource.clip.length);
    }
    void Update()
    {
        if (!console.jojoSoundtrackHasBeenSwitched && playOnlyOnce)
        {
            playOnlyOnce = false;
            introSource.Play();
            loopSource.PlayScheduled(AudioSettings.dspTime + introSource.clip.length);
        }    
    }
}
