
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour 
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] private int _StartLineDelay = 3;
    [SerializeField] private AudioClip _StartVoiceLine;
    

    private AudioSource _audioSource;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
    }
    
    IEnumerator Start()
    {
        _audioSource = GetComponent<AudioSource>();

        yield return new WaitForSeconds(_StartLineDelay);
        _audioSource.PlayOneShot(_StartVoiceLine);
    }

    public void PlaySound(AudioClip sound)
    {
        _audioSource.PlayOneShot(sound);
    }

    public void PlayRandomSounnd(AudioClip[] sounds)
    {
        int randomIndex = Random.Range(0, sounds.Length-1);
        _audioSource.PlayOneShot(sounds[randomIndex]);
    }

    private AudioClip _savedSound;
    public void PlaySound(AudioClip sound, float delay)
    {
        _savedSound = sound;
        Invoke("PlaySavedSound", delay);
    }

    private void PlaySavedSound()
    {
        _audioSource.PlayOneShot(_savedSound);
    }

}
