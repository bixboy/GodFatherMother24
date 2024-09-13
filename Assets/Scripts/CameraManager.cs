using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private CinemachineCollisionImpulseSource _impulseSource;

    private static CameraManager instance = null;
    public static CameraManager Instance => instance;

    private void Awake()
    {
        instance = this;
        _impulseSource = GetComponent<CinemachineCollisionImpulseSource>();
    }
    public void ScreenShake()
    {
        _impulseSource.GenerateImpulse();
    }
}
