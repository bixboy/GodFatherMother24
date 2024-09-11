using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class dialogue : MonoBehaviour
{
    public static dialogue instance;
    private Animator _animator;

    [SerializeField] private TextMeshProUGUI _dialogue;
    [SerializeField] private Image _characterImg;
    [SerializeField] private AudioClip _tapingSound;

    [Header("Variables")]
    [SerializeField] private float _timeDialogueHide;
    [SerializeField] private float _textSpeed;
    [SerializeField] private bool _dontTimeDialogueHide;

    private string _lines;
    private bool _isDialogueActive = false;
    private bool _isPlayed;

    private AudioSource _audio;
    private AudioManager _audioManager;
    private Coroutine _coroutine;

    public void SartDialogue(string text, Sprite character) => SetDialogue(text, character);
    public bool GetDilogueIsPlayed() => _isPlayed;
    public void CloseDialogue() => Disable();

    public Sprite test;

    private void Awake()
    {
        instance = this;

        _dialogue = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        _animator = GetComponent<Animator>();
        _isPlayed = false;
    }

    private void Start()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        _audio = GameObject.FindGameObjectWithTag("Sound").GetComponent<AudioSource>();

        SartDialogue("gerhgehdpoghdfoghdofhgo", test);
    }

    #region Start dialogues
    private void SetDialogue(string text, Sprite character)
    {
        if (!_isPlayed)
        {
            if (_audioManager != null) 
            { 
                Disable();
                Enable(text, character);
                OpenDialogue();
            }
        }

    }

    #endregion

    #region open & close dialogues
    private void OpenDialogue()
    {
        _animator.SetBool("Close", false);
        _animator.SetTrigger("Open");
        _isPlayed = true;
    }

    private void Enable(string text, Sprite character)
    {
        _lines = text;
        _dialogue.text = string.Empty;
        _characterImg.sprite = character;

        //SeparateString(text);
        _coroutine = StartCoroutine(TypeLine());
    }

    private void Disable()
    {
        _isPlayed = false;
        _animator.SetBool("Close", true);

        _dialogue.text = string.Empty;

        _audio.Stop();
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
        _isDialogueActive = false;
    }
    #endregion

    private IEnumerator TypeLine()
    {
        _isDialogueActive = true;
        foreach (char c in _lines)
        {
            _dialogue.text += c;
            _audio.clip = _tapingSound;
            _audio.Play();
            yield return new WaitForSeconds(_textSpeed);
        }

        _isPlayed = false;
        if (!_dontTimeDialogueHide && _isDialogueActive)
        {
            _coroutine = StartCoroutine(TimeDialogue());
        }
    }

    private IEnumerator TimeDialogue()
    {
        yield return new WaitForSeconds(_timeDialogueHide);
        if (_isDialogueActive)
        {
            Disable();
        }
    }


}
