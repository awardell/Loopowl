using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationControls : CharacterAnimationControls
{
	[SerializeField]
	public EnemyAimTarget _aimTarget;

	protected override Vector3 GetTarget()
	{
		return _aimTarget.Target;
	}

	protected override void Update()
	{
		base.Update();
		_animator.SetBool("IsAiming", _aimTarget.HasTargeting);
	}
}
