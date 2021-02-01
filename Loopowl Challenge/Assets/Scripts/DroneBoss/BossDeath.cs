﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeath : MonoBehaviour
{
    [SerializeField]
    [GetComponent(typeof(Rigidbody))]
    private Rigidbody _rigidbody;

    [SerializeField]
    private Behaviour[] _toDisable;

    [SerializeField]
    private Vector3 _torqueImpulse = new Vector3(100f, 0f, 300f);

    public void CommenceDeath()
	{
        _rigidbody.useGravity = true;
        _rigidbody.constraints = RigidbodyConstraints.None;
        _rigidbody.AddTorque(_torqueImpulse, ForceMode.Impulse); //give it a little spin while it dies

        foreach (var comp in _toDisable)
            comp.enabled = false;

        StartCoroutine(DeathRoutine());
	}

    private IEnumerator DeathRoutine()
	{
        yield return new WaitForSeconds(3f);
    }
}
