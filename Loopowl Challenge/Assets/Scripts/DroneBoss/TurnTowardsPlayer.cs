using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTowardsPlayer : MonoBehaviour
{
    [SerializeField]
    [GetComponent(typeof(Transform))]
    private Transform _transform;

    void Update()
    {
        _transform.LookAt(PlayerReferences.Instance.playerTarget.position);
    }
}
