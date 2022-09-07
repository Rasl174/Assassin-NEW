using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WomanWalk : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    [SerializeField] private Transform _endPosition;
    [SerializeField] private float _moveTime;

    private bool _isMoving = false;

    private void Update()
    {
        if (_camera.active && _isMoving == false)
        {
            transform.DOMove(_endPosition.position, _moveTime);
            _isMoving = true;
        }
    }
}
