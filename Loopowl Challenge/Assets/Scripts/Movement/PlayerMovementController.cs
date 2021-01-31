using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovementController : MovementController
{
	[Header("Jump")]
    [SerializeField]
    private float _jumpHeight = 2f;
    [SerializeField]
    private float _jumpSpeed = 10f;
    [SerializeField]
    private float _taperDuration = 0.5f;
    [SerializeField]
    private float _hangDuration = 0.1f;
    [SerializeField]
    public UnityEvent OnJump;

	protected override bool ShouldMoveLeft()
	{
        return Input.GetKey(KeyCode.A);
    }

	protected override bool ShouldMoveRight()
    {
        return Input.GetKey(KeyCode.D);
    }

	protected override void Update()
    {
        base.Update();
        if (_wasGrounded && Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(JumpRoutine());
    }

    //I personally like a "video game" jump and a physics engine fall
    //This coroutine turns off gravity and manually takes care of the jump
    //We could improve this by turning back on gravity if the coroutine is cancelled
    //Probably by using await instead of a coroutine, or using an update method
    //This is good enough for a demo.
    private IEnumerator JumpRoutine()
	{
        OnJump?.Invoke();

        void SetYVelocity(float y)
		{
            var velocity = _rigidbody.velocity;
            velocity.y = y;
            _rigidbody.velocity = velocity;
		}

        _rigidbody.useGravity = false;
        float duration = _jumpHeight / _jumpSpeed;
        while (duration > 0f && Input.GetKey(KeyCode.Space))
		{
            SetYVelocity(_jumpSpeed);
            duration -= Time.deltaTime;
            yield return null;
		}

		for (float t = _taperDuration; t > 0; t -= Time.deltaTime)
		{
			float speed = Mathf.Clamp01(t / _taperDuration) * _jumpSpeed;
			SetYVelocity(speed);
			yield return null;
		}

		for (float t = _hangDuration; t > 0; t -= Time.deltaTime)
        {
            SetYVelocity(0f);
            yield return null;
        }

        SetYVelocity(0f);
        _rigidbody.useGravity = true;
	}
}
