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
}
