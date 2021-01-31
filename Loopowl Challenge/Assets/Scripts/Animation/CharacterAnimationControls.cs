using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterAnimationControls : MonoBehaviour
{
	[SerializeField]
	[GetComponent(typeof(Animator))]
	protected Animator _animator;

	[SerializeField]
	protected Transform _transform;

	[SerializeField]
	protected Rigidbody _rigidbody;

	public void SetIsGrounded(bool value)
	{
		_animator.SetBool("IsGrounded", value);
	}

	public void DoShoot()
	{
		_animator.SetTrigger("DoShoot");
	}

	protected abstract Vector3 GetTarget();

	private void Update()
	{
		//face left or right
		if (GetTarget().x < _transform.position.x)
		{
			//facing left
			_transform.rotation = Quaternion.Euler(0f, 180f, 0f);
			_animator.SetFloat("XVelocity", -_rigidbody.velocity.x);
		}
		else
		{
			//right
			_transform.rotation = Quaternion.identity;
			_animator.SetFloat("XVelocity", _rigidbody.velocity.x);
		}

		_animator.SetFloat("YVelocity", _rigidbody.velocity.y);
	}

	private void OnAnimatorIK(int layerIndex)
	{
		_animator.SetLookAtWeight(1f, 1f, 1f, 1f); //Does this need to be every IK update?
		_animator.SetLookAtPosition(GetTarget());
	}
}
