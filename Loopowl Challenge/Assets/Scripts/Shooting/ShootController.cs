using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class ShootController : MonoBehaviour
{
    [SerializeField]
    private Transform _spawnPosition;

    [SerializeField]
    private GameObject _shotPrefab;

    [SerializeField]
    private float _shootDelay = 0f;

    [SerializeField]
    public UnityEvent OnShoot;

    protected void Shoot()
    {
        OnShoot?.Invoke();
        StartCoroutine(ShootRoutine());
    }

    private IEnumerator ShootRoutine()
	{
        yield return new WaitForSeconds(_shootDelay);
        Instantiate(_shotPrefab, _spawnPosition.position, Quaternion.identity);
    }
}
