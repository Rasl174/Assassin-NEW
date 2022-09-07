using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _sensetive;

    private Vector3 _rotation;

    private void Start()
    {
        _rotation = transform.eulerAngles;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _sensetive;
        float mouseY = Input.GetAxis("Mouse Y") * _sensetive;
        _rotation.x -= mouseY;
        _rotation.y += mouseX;
        transform.eulerAngles = _rotation;
    }
}
