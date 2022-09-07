using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTarget : MonoBehaviour
{
    [SerializeField] private CameraSwitcher _cameraSwitcher;
    [SerializeField] private GameObject _canvasCamera;
    [SerializeField] private Player _player;
    [SerializeField] private Target _targetToFind;

    private Target _selectedTarget;

    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            if(hit.collider.TryGetComponent<Target>(out Target target))
            {
                _selectedTarget = target;
                _selectedTarget.OnRayEnter();

                if (Input.GetKeyDown(KeyCode.Space) && _targetToFind == _selectedTarget)
                {
                    _canvasCamera.gameObject.SetActive(false);
                    _selectedTarget.OnRayExit();
                    _cameraSwitcher.Switch();
                    _player.gameObject.transform.eulerAngles = new Vector3(0, hit.transform.eulerAngles.y, 0);
                    _player.Spawn();
                }
            }
            else if (_selectedTarget != null && hit.collider != target)
            {
                _selectedTarget.OnRayExit();
                _selectedTarget = null;
            }
        }
    }
}
