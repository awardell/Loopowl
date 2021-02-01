
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    [GetComponent(typeof(Rigidbody))]
    private Rigidbody _rigidbody;

	[SerializeField]
	private float _speed;

	private void Start()
	{
		var target = PlayerReferences.Instance.playerTarget;
		_rigidbody.velocity = (target.position - transform.position).normalized * _speed;
	}

	private void OnCollisionEnter(Collision collision)
	{
		Destroy(gameObject);
	}
}
