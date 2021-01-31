using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootController : ShootController
{
    [SerializeField]
    private EnemyAimTarget _target;

    [SerializeField]
    private float _cooldown = 2f;

    private float _timer = 0f;

	private void Start()
	{
        _timer = _cooldown;
	}

	void Update()
    {
        if (!_target.HasTargeting)
            _timer = _cooldown;
        else if (_timer <= 0f)
        {
            Shoot();
            _timer = _cooldown;
        }
        _timer -= Time.deltaTime;
    }
}
