using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _player.Move();
        }   
    }
}
