//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Audio;
//public class PlayOneShotBehaviour : StateMachineBehaviour
//{
//    //Test pøejmenování audioclipu, pùvodní jméno promìnné: soundToPlay
//    public AudioClip[] soundToPlay;

//    public int randomIndex;
//    public float volume = 1f;
//    public bool playOnEnter = true, playOnExit = false, playAfterDelay = false;
//    public float playDelay = 0.25f;
//    private float timeSinceEntered = 0;
//    private bool hasDelayedSoundPlayed = false;

//    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
//    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//    {
//        randomIndex = Random.Range(0, 3);
//        Debug.Log(randomIndex);
//        if(playOnEnter)
//        {
//            AudioSource.PlayClipAtPoint(soundToPlay[randomIndex], animator.gameObject.transform.position, volume);
//        }

//        timeSinceEntered = 0f;
//        hasDelayedSoundPlayed = false;
//    }

//    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
//    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//    {
//        if(playAfterDelay && !hasDelayedSoundPlayed)
//        {
//            timeSinceEntered += Time.deltaTime;

//            if(timeSinceEntered > playDelay)
//            {
//                AudioSource.PlayClipAtPoint(soundToPlay[randomIndex], animator.gameObject.transform.position, volume);
//                hasDelayedSoundPlayed = true;
//            }
//        }
//    }

//    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
//    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//    {
//        if (playOnExit)
//        {
//            AudioSource.PlayClipAtPoint(soundToPlay[randomIndex], animator.gameObject.transform.position, volume);
//        }
//    }

// OnStateMove is called right after Animator.OnAnimatorMove()
//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//{
//    // Implement code that processes and affects root motion
//}

// OnStateIK is called right after Animator.OnAnimatorIK()
//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//{
//    // Implement code that sets up animation IK (inverse kinematics)
//}
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayOneShotBehaviour : StateMachineBehaviour
{
    public bool enemyHasDied;
    public AudioClip[] soundToPlay;
    public AudioMixerGroup outputAudioMixerGroup;
    private powerUpSpawner spawnPowerUp;

    public int randomIndex;
    public float volume = 1f;
    public bool playOnEnter = true, playOnExit = false, playAfterDelay = false;
    public float playDelay = 0.25f;
    private float timeSinceEntered = 0;
    private bool hasDelayedSoundPlayed = false;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        randomIndex = Random.Range(0, soundToPlay.Length);
        Debug.Log(randomIndex);
        if (playOnEnter)
        {
            PlayClipAtPointWithAudioMixer(soundToPlay[randomIndex], animator.gameObject.transform.position, volume);
        }

        timeSinceEntered = 0f;
        hasDelayedSoundPlayed = false;
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playAfterDelay && !hasDelayedSoundPlayed)
        {
            timeSinceEntered += Time.deltaTime;

            if (timeSinceEntered > playDelay)
            {
                PlayClipAtPointWithAudioMixer(soundToPlay[randomIndex], animator.gameObject.transform.position, volume);
                hasDelayedSoundPlayed = true;
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playOnExit)
        {
            PlayClipAtPointWithAudioMixer(soundToPlay[randomIndex], animator.gameObject.transform.position, volume);
        }
    }

    private void PlayClipAtPointWithAudioMixer(AudioClip clip, Vector3 position, float volume)
    {
        GameObject audioSourceGameObject = new GameObject("TempAudioSource");
        audioSourceGameObject.transform.position = position;
        AudioSource audioSource = audioSourceGameObject.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.outputAudioMixerGroup = outputAudioMixerGroup;
        audioSource.Play();
        enemyHasDied = true;
        Destroy(audioSourceGameObject, clip.length);
    }
}

