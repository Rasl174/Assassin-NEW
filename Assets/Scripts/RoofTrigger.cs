using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofTrigger : MonoBehaviour
{
    [SerializeField] private CameraSwitcher _cameraSwitcher;
    [SerializeField] private float _waiter;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Player>(out Player player))
        {
            player.TryGetComponent<Animator>(out Animator playerAnimator);
            playerAnimator.Play("Idle Stand");
            _cameraSwitcher.Switch();
            StartCoroutine(Timer());
        }
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(_waiter);
        _cameraSwitcher.Switch();
    }
}
