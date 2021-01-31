using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageReceiver : MonoBehaviour
{
	[SerializeField]
	public UnityEvent OnDie;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag == TagsAndLayers.Tags.DAMAGE)
		{
			Die();
		}
	}

	private void Die()
	{
		OnDie?.Invoke();
	}
}
