using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Rotates the particle emitter opposite the direction
//the plasma ball is heading to avoid need for world-space
//simulation for all particles
public class RotatePlasmaVFX : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rigidBody;

    [SerializeField]
    [GetComponent(typeof(Transform))]
    private Transform _transform;

	private void Update()
	{
		if (_rigidBody.velocity.sqrMagnitude > 0f)
		{
			_transform.rotation = Quaternion.LookRotation(_rigidBody.velocity);
		}
	}
}
