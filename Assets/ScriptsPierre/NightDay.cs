using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NightDay : MonoBehaviour
{
    public static NightDay instance { get; private set; }

    [SerializeField] private float _rotationSpeed = 10f;
    [SerializeField] private float _radius = 10f;
    private Animator _animator;

    [SerializeField] private Transform _sun;
    [SerializeField] private Transform _moon;
    [SerializeField] private GameObject _centerPoint;
    private Vector3 _centerPos;
    private float _rotationSpeedTemp;
    bool _waitingForInput = false;
    public bool WaitingForInput => _waitingForInput;

    public void OpenChangeDay() => StartChangeDay();
    public void NextDay() => ChangeDay();

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rotationSpeedTemp = _rotationSpeed;
        _rotationSpeed = 0;

        _centerPos = _centerPoint.GetComponent<RectTransform>().position;
        _sun.position = _centerPos + new Vector3(0f, _radius, 0f);
        _moon.position = _centerPos + new Vector3(0f, -_radius, 0f);
    }

    private void StartChangeDay()
    {
        _waitingForInput = true;
        LoadScreen.instance.StartLoadScreen();
        _animator.SetBool("IsChangeDay", true);
    }

    private void ChangeDay()
    {
        _waitingForInput = false ;
        _rotationSpeed = _rotationSpeedTemp;

        StartCoroutine(RotateAroundCenter(_sun, 1, 180f));
        StartCoroutine(RotateAroundCenter(_moon, 1, 180f));
    }

    private void ChangeRoom()
    {
        GameManager.Instance.NextScene();
        EndChangeDay();
    }

    private void EndChangeDay()
    {
        _animator.SetBool("IsChangeDay", false);
        LoadScreen.instance.StartLoadScreen();
    }

    private IEnumerator RotateAroundCenter(Transform obj, int direction, float targetRotation)
    {
        float currentRotation = 0f;

        while (currentRotation < targetRotation)
        {
            float rotationStep = _rotationSpeed * Time.deltaTime;

            if (currentRotation + rotationStep > targetRotation)
            {
                rotationStep = targetRotation - currentRotation;
            }

            obj.RotateAround(_centerPos, Vector3.forward, direction * rotationStep);
            obj.rotation = Quaternion.identity;

            currentRotation += rotationStep;

            yield return null;
        }
        ChangeRoom();
    }
}
