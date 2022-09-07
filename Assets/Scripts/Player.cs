using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private CameraSwitcher _cameraSwitcher;
    [SerializeField] private GameObject _spawnPosition;
    [SerializeField] private float _spawnTimer;
    [SerializeField] private GameObject _leftHand;
    [SerializeField] private GameObject _rightHand;
    [SerializeField] private GameObject _leftKnife;
    [SerializeField] private GameObject _rightKnife;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private ParticleSystem _roofParticles;
    [SerializeField] private ParticleSystem _floorParticles;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void SwitchKnives()
    {
        _leftKnife.transform.position = _leftHand.transform.position;
        _rightKnife.transform.position = _rightHand.transform.position;
        _leftKnife.transform.SetParent(_leftHand.transform);
        _rightKnife.transform.SetParent(_rightHand.transform);
    }

    private IEnumerator Timer()
    {
        _roofParticles.Play();
        yield return new WaitForSeconds(_spawnTimer);
        _roofParticles.Stop();
        _floorParticles.Play();
        _enemy.SetReadyAnimation();
        _cameraSwitcher.Switch();
        gameObject.transform.position = _spawnPosition.transform.position;
        SwitchKnives();
        _animator.Play("Attack");
    }

    public void Spawn()
    {
        StartCoroutine(Timer());
    }
}
