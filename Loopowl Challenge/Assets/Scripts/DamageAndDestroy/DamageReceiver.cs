using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class DamageReceiver : MonoBehaviour
{
	[SerializeField]
	[FormerlySerializedAs("OnDie")]
	public UnityEvent OnTakeDamage;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag == TagsAndLayers.Tags.DAMAGE)
		{
			TakeDamage();
		}
	}

	private void TakeDamage()
	{
		OnTakeDamage?.Invoke();
	}
}
