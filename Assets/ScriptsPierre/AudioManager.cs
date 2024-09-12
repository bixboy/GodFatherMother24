using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private AudioSource _audioSource;
    private AudioSource _audioSourceSound;

    [Header("Music")]
    [SerializeField] private AudioClip[] _playlistMusic;

    private int _index = 0;
    private int _lastIndex = -1;
    private AudioClip[] _actualClip;

    public void PlayMusic() => PlayNextSound();

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        _audioSourceSound = GameObject.FindGameObjectWithTag("Sound").GetComponent<AudioSource>();
        _actualClip = _playlistMusic;
        PlayNextSound();
    }

    void Update()
    {
        if (!_audioSource.isPlaying)
        {
            //PlayNextSound();
        }
    }

    private void PlaySound(AudioClip sound)
    {
        _audioSourceSound.clip = sound;
        _audioSourceSound.Play();
    }

    private void PlayNextSound()
    {
        Debug.Log("play next sound");

        if (_actualClip.Length == 0)
        {
            Debug.LogWarning("La playlist est vide.");
            return;
        }

        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, _actualClip.Length);
        } while (randomIndex == _lastIndex);

        _lastIndex = randomIndex;
        _index = randomIndex;

        _audioSource.clip = _actualClip[_index];
        _audioSource.Play();
    }
}
