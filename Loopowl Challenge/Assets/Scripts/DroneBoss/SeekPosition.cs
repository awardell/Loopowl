using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekPosition : MonoBehaviour
{
	[SerializeField]
	private Transform _targetPosition;

    [SerializeField]
    [GetComponent(typeof(Rigidbody))]
    private Rigidbody _rigidbody;

	[SerializeField]
	private float percent = .1f;

	private void FixedUpdate()
	{
		var difference = _targetPosition.position - _rigidbody.transform.position;
		float delta = percent * Time.fixedDeltaTime;
		var position = _rigidbody.transform.position + (difference * delta);
		_rigidbody.MovePosition(position);
	}
}
