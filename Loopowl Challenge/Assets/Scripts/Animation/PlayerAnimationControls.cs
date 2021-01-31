using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControls : CharacterAnimationControls
{
	public void DoJump()
	{
		_animator.SetTrigger("DoJump");
	}

	protected override Vector3 GetTarget()
	{
		return AimManager.Instance.Target;
	}
}
