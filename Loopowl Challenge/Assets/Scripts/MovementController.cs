using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class MovementController : MonoBehaviour
{
    #region serialized
    [SerializeField]
    [GetComponent(typeof(Rigidbody))]
    protected Rigidbody _rigidbody;

    [Header("Movement")]
    [SerializeField]
    private float _moveSpeed = 1f;

    [SerializeField]
    private float _haltDuration = .1f;

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

    [Serializable]
    public class OnIsGroundedChangedEvent : UnityEvent<bool> { }
    [SerializeField]
    public OnIsGroundedChangedEvent OnIsGroundedChanged;
    #endregion

    #region private
    protected bool _wasGrounded = false;
    #endregion

    protected abstract bool ShouldMoveLeft();
    protected abstract bool ShouldMoveRight();

    protected virtual void Update()
    {
        UpdateMovement();

        bool grounded = IsGrounded();
        if (grounded != _wasGrounded)
        {
            _wasGrounded = grounded;
            OnIsGroundedChanged.Invoke(grounded);
        }
    }

    protected bool IsGrounded()
    {
        return Physics.CheckBox(transform.position, _groundedBoxHalfExtents, Quaternion.identity, LayerMask.GetMask(TagsAndLayers.Layers.GROUND));
    }

    private void UpdateMovement()
    {
        var velocity = _rigidbody.velocity;
        if (ShouldMoveLeft())
        {
            velocity.x = -_moveSpeed;
            _rigidbody.velocity = velocity;
            OnMoveLeft?.Invoke();
        }
        else if (ShouldMoveRight())
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
}
