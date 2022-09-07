using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAim : MonoBehaviour
{
    [SerializeField] private GameObject _swipe;
    [SerializeField] private GameObject _camera;

    private Vector3 _startCameraRotation;

    private void Start()
    {
        _startCameraRotation = _camera.transform.eulerAngles;
    }

    private void Update()
    {
        if(_camera.transform.eulerAngles != _startCameraRotation)
        {
            _swipe.SetActive(false);
        }
    }
}
