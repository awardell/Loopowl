using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//a very basic state machine controller for enemy movement
//The enemy will walk back and forth within the _patrolArea
public class EnemyMovementController : MovementController
{
	[SerializeField]
	private BoxCollider _patrolArea = null;

	public enum MovementDirection
	{
		Left,
		Right,
		StandStill
	}

	[SerializeField]
	private MovementDirection _movementDirection = MovementDirection.StandStill;

	protected override bool ShouldMoveLeft()
	{
		return _movementDirection == MovementDirection.Left;
	}

	protected override bool ShouldMoveRight()
	{
		return _movementDirection == MovementDirection.Right;
	}

	protected override void Update()
	{
		if (_patrolArea == null)
			_movementDirection = MovementDirection.StandStill;
		else
		{
			switch (_movementDirection)
			{
				case MovementDirection.Left:
				case MovementDirection.StandStill:
					if (_rigidbody.transform.position.x <= _patrolArea.bounds.min.x)
						_movementDirection = MovementDirection.Right;
					else
						_movementDirection = MovementDirection.Left;
					break;
				case MovementDirection.Right:
					if (_rigidbody.transform.position.x >= _patrolArea.bounds.max.x)
						_movementDirection = MovementDirection.Left;
					break;
			}
		}

		base.Update();
	}
}
