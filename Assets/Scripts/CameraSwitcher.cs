using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _camera1;
    [SerializeField] private GameObject _camera2;
    [SerializeField] private GameObject _camera3;
    [SerializeField] private GameObject _camera4;
    [SerializeField] private GameObject _camera5;
    [SerializeField] private GameObject _camera6;

    private MobileBlur _blur;

    private int _switchCount = 0;

    private void Awake()
    {
        _blur = GetComponent<MobileBlur>();
        _blur.enabled = false;
        _camera2.gameObject.SetActive(false);
        _camera3.gameObject.SetActive(false);
        _camera4.gameObject.SetActive(false);
        _camera5.gameObject.SetActive(false);
        _camera6.gameObject.SetActive(false);
    }

    public void Switch()
    {
        if(_switchCount == 0)
        {
            _camera1.gameObject.SetActive(false);
            _camera2.gameObject.SetActive(true);
            _switchCount++;
        }
        else if(_switchCount == 1)
        {
            _camera2.gameObject.SetActive(false);
            _camera3.gameObject.SetActive(true);
            _switchCount++;
        }
        else if(_switchCount == 2)
        {
            _blur.enabled = true;
            _camera3.gameObject.SetActive(false);
            _camera4.gameObject.SetActive(true);
            _switchCount++;
        }
        else if(_switchCount == 3)
        {
            _blur.enabled = false;
            _camera4.gameObject.SetActive(false);
            _camera5.gameObject.SetActive(true);
            _switchCount++;
        }
        else if(_switchCount == 4)
        {
            _camera5.gameObject.SetActive(false);
            _camera6.gameObject.SetActive(true);
            _switchCount++;
        }
    }
}
