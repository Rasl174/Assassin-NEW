using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSwicher : MonoBehaviour
{
    [SerializeField] private GameObject _waypointCanvas;
    [SerializeField] private float _timer;
    [SerializeField] private Outline _enemyOutline;

    private bool _isActive = false;
    private bool _isOutlineActive = false;

    private void Start()
    {
        _waypointCanvas.SetActive(false);
    }

    private void Update()
    {
        if (_isActive == false && gameObject.active)
        {
            _isActive = true;
            StartCoroutine(ArrowTimer());
        }
        if (_isOutlineActive == false && _enemyOutline.enabled == true)
        {
            _isOutlineActive = true;
            _waypointCanvas.SetActive(false);
        }
        else if (_isOutlineActive == true && _enemyOutline.enabled == false)
        {
            _isOutlineActive = false;
            _waypointCanvas.SetActive(true);
        }
    }

    private IEnumerator ArrowTimer()
    {
        yield return new WaitForSeconds(_timer);
        _waypointCanvas.SetActive(true);
    }
}
