using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootController : MonoBehaviour
{
    [SerializeField]
    private Transform _spawnPosition;

    [SerializeField]
    private GameObject _shotPrefab;

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

    private void Shoot()
	{
        Instantiate(_shotPrefab, _spawnPosition.position, Quaternion.identity);
	}
}
