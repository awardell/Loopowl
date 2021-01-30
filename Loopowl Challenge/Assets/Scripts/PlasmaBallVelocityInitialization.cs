using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaBallVelocityInitialization : MonoBehaviour
{
    [SerializeField]
    [GetComponent(typeof(Rigidbody))]
    private Rigidbody _rigidbody;

	[SerializeField]
	[GetComponent(typeof(Transform))]
	private Transform _transform;

	[SerializeField]
	private float _initSpeed = 1f;

	private void Start()
	{
		var velocity = (AimManager.Instance.Target - _transform.position).normalized * _initSpeed;
		velocity.z = 0f;
		_rigidbody.velocity = velocity;
	}
}
