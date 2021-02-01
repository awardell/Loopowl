using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaBallImpact : MonoBehaviour
{
	[SerializeField]
	private GameObject _despawnFXPrefab;

	[SerializeField]
	private int _maxBounces = 1;
	[SerializeField]
	private int _maxGroundStays = 5;

	private int _bounces = 0;
	private int _groundStays = 0;

	private void OnCollisionEnter(Collision collision)
	{
		string tag = collision.collider.tag;
		if (tag == TagsAndLayers.Tags.ENEMY)
			Despawn();
		else if (tag == TagsAndLayers.Tags.GROUND)
		{
			++_bounces;
			if (_bounces > _maxBounces)
				Despawn();
		}
	}

	//prevent it from rolling forever
	private void OnCollisionStay(Collision collision)
	{
		string tag = collision.collider.tag;
		if (tag == TagsAndLayers.Tags.GROUND)
		{
			++_groundStays;
			if (_groundStays > _maxGroundStays)
				Despawn();
		}
	}

	private void Despawn()
	{
		StartCoroutine(DespawnRoutine());
	}

	//We need to wait a smidge before despawning
	//to allow the projectile to provide its impulse
	private IEnumerator DespawnRoutine()
	{
		yield return new WaitForSeconds(.02f);
		Destroy(gameObject);
	}
}
