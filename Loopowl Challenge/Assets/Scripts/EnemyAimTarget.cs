using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAimTarget : MonoBehaviour
{
    [SerializeField]
    private Collider _zoneOfAwareness;
	[SerializeField]
	private Rigidbody _rigidbody;
	[SerializeField]
	[Tooltip("How long after the player leaves the _zomeOfAwareness before enemy loses target")]
	private float _targetingDurationFalloff = 0.2f;

	public bool HasTargeting { get { return _targeting != null; } }
    public Vector3 Target { get; private set; } = Vector3.zero;

	//how far away to target if we don't have a _targeting
	private const float LOOKAHEAD = 5f;

	private Transform _targeting = null;
	private float _targetingTimer = 0f;

	private void Update()
	{
		if (_targeting != null && _targetingTimer < 0f)
		{
			_targeting = null;
		}

		_targetingTimer -= Time.deltaTime;

		if (_targeting != null)
		{
			Target = _targeting.position;
		}
		else
		{
			Target = _rigidbody.transform.position + (_rigidbody.velocity.normalized * LOOKAHEAD);
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.tag == TagsAndLayers.Tags.PLAYER)
		{
			_targeting = other.transform;
			_targetingTimer = _targetingDurationFalloff;
		}
	}
}
