using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovementController : MonoBehaviour
{
	#region serialized
	[SerializeField]
    [GetComponent(typeof(Rigidbody))]
    private Rigidbody _rigidbody;

    [Header("Movement")]
    [SerializeField]
    private float _moveSpeed = 1f;

    [SerializeField]
    private float _haltDuration = .1f;

    [Header("Jump")]
    [SerializeField]
    private float _jumpHeight = 2f;
    [SerializeField]
    private float _jumpSpeed = 10f;
    [SerializeField]
    private float _taperDuration = 0.5f;
    [SerializeField]
    private float _hangDuration = 0.1f;

    [Header("Grounded")]
    [SerializeField]
    private Vector3 _groundedBoxHalfExtents = new Vector3(0.5f, 0.5f, 0.1f);

    [Header("Events")]
    [SerializeField]
    public UnityEvent OnMoveLeft;
    [SerializeField]
    public UnityEvent OnMoveRight;
    [SerializeField]
    public UnityEvent OnStandStill;
    [SerializeField]
    public UnityEvent OnJump;

    [Serializable]
    public class OnIsGroundedChangedEvent : UnityEvent<bool> { }
    [SerializeField]
    public OnIsGroundedChangedEvent OnIsGroundedChanged;
    #endregion

    #region private
    private bool _wasGrounded = false;
	#endregion

	void Update()
    {
        UpdateMovement();

        bool grounded = IsGrounded();
        if (grounded != _wasGrounded)
		{
            _wasGrounded = grounded;
            OnIsGroundedChanged.Invoke(grounded);
		}

        if (grounded && Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(JumpRoutine());
    }

    private bool IsGrounded()
	{
        return Physics.CheckBox(transform.position, _groundedBoxHalfExtents, Quaternion.identity, LayerMask.GetMask(TagsAndLayers.Layers.GROUND));
	}

    private void UpdateMovement()
	{
        var velocity = _rigidbody.velocity;
        if (Input.GetKey(KeyCode.A))
        {
            velocity.x = -_moveSpeed;
            _rigidbody.velocity = velocity;
            OnMoveLeft?.Invoke();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            velocity.x = _moveSpeed;
            _rigidbody.velocity = velocity;
            OnMoveRight?.Invoke();
        }
        else //dampen our x velocity over haltDuration
        {
            float speed = velocity.x >= 0 ? _moveSpeed : -_moveSpeed;
            velocity.x = Mathf.Lerp(speed, 0f, 1f - (velocity.x / speed) + (Time.deltaTime / _haltDuration));
            _rigidbody.velocity = velocity;
            OnStandStill?.Invoke();
        }
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
