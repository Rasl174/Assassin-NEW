using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody _spineMiddle;
    [SerializeField] private ParticleSystem _blood;
    [SerializeField] private Vector3 _bodyVelocity;

    private Rigidbody[] _bodies;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _bodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody body in _bodies)
        {
            body.isKinematic = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Knife>(out Knife knife))
        {
            _animator.enabled = false;
            foreach (Rigidbody body in _bodies)
            {
                body.isKinematic = false;
            }
            _blood.Play();
            _spineMiddle.velocity = _bodyVelocity;
        }
    }

    public void SetReadyAnimation()
    {
        _animator.Play("Ready");
    }
}
