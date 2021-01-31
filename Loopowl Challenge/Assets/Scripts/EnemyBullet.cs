
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
		var player = GameObject.FindGameObjectWithTag("Player"); //we should really hold this in a manager, adam
		var target = player?.GetComponent<TargetTransform>()?.target;
		if (target != null)
		{
			_rigidbody.velocity = (target.position - transform.position).normalized * _speed;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		Destroy(gameObject);
	}
}
