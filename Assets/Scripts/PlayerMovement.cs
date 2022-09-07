using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private List<Transform> _wallPositions;
    [SerializeField] private List<Transform> _roofPositions;
    [SerializeField] private float _vallMoveTime;
    [SerializeField] private float _roofMoveTime;
    [SerializeField] private CameraSwitcher _cameraSwitcher;
    [SerializeField] private Vector3 _tuningWallPosition;
    [SerializeField] private ParticleSystem _footPoof;
    [SerializeField] private ParticleSystem _handPoof;

    private Animator _animator;
    private Vector3 _targetPosition;
    private bool _canPlayParticle = true;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(transform.position == _targetPosition && _canPlayParticle)
        {
            PlayParticle();
        }
    }

    private void PlayParticle()
    {
        _canPlayParticle = false;
        _handPoof.Play();
    }

    public void Move()
    {
        if (_wallPositions.Count > 1)
        {
            _targetPosition = _wallPositions[0].position + _tuningWallPosition;
            _canPlayParticle = true;
            _footPoof.Play();
            _animator.Play("Branced");
            transform.DOMove(_wallPositions[0].position + _tuningWallPosition, _vallMoveTime);
            _wallPositions.Remove(_wallPositions[0]);
        }
        else if (_wallPositions.Count == 1)
        {
            _cameraSwitcher.Switch();
            transform.DOMove(_wallPositions[0].position + _tuningWallPosition, _vallMoveTime);
            _wallPositions.Remove(_wallPositions[0]);
        }
        else if(_wallPositions.Count == 0 && _roofPositions.Count == 2)
        {
            _animator.Play("Hang To Crouch");
            transform.DOMove(_roofPositions[0].position, _roofMoveTime / 2);
            _roofPositions.Remove(_roofPositions[0]);
        }
        else if(_roofPositions.Count == 1)
        {
            _animator.Play("Runing");
            transform.eulerAngles = new Vector3(0,49,0);
            transform.DOMove(_roofPositions[0].position, _roofMoveTime);
            _roofPositions.Remove(_roofPositions[0]);
        }
    }
}
