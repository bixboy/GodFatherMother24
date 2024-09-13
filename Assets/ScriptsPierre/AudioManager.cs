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
    private AudioClip[] _actualClip;

    public void PlayMusic() => PlayNextSound();
    public void PlaySound(AudioClip sound) => StartSound(sound);
    public void ChangeMusic(AudioClip music) => StartMusic(music);

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
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
            PlayNextSound();
        }
    }

    private void StartSound(AudioClip sound)
    {
        if (_audioSourceSound == null)
        {
            _audioSourceSound = GameObject.FindGameObjectWithTag("Sound").GetComponent<AudioSource>();
            StartSound(sound);
        }
        else
        {
            _audioSourceSound.clip = sound;
            _audioSourceSound.Play();
        }
    }

    private void StartMusic(AudioClip music)
    {
        _audioSource.clip = music;
        _audioSource.Play();
    }

    private void PlayNextSound()
    {
        Debug.Log("play next sound");

        _audioSource.clip = _actualClip[_index];
        _audioSource.Play();
    }
}
