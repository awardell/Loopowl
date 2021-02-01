using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerShootController : ShootController
{
    [SerializeField]
    private float _cooldown = .5f;

    private float _timer = 0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _timer <= 0f)
        {
            Shoot();
            _timer = _cooldown;
        }
        _timer -= Time.deltaTime;
    }
}
