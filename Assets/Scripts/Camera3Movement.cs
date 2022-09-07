using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Camera3Movement : MonoBehaviour
{
    [SerializeField] private GameObject _camera3;
    [SerializeField] private Transform[] _targets;
    [SerializeField] private float _waitTimer;
    [SerializeField] private float _moveTimer;

    private bool _isMoving = false;

    private void Update()
    {
        if(_camera3.active && _isMoving == false)
        {
            _isMoving = true;
            StartCoroutine(MoveTimer());
        }
    }

    private IEnumerator MoveTimer()
    {
        yield return new WaitForSeconds(_waitTimer);
        for (int i = 0; i < _targets.Length; i++)
        {
            transform.DOMove(_targets[i].position, _moveTimer);
            yield return new WaitForSeconds(_waitTimer);
        }
    }
}
