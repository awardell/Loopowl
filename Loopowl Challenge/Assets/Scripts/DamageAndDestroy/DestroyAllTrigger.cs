using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAllTrigger : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		var handler = other.GetComponent<DestroyHandler>();
		if (handler != null)
			handler.PerformDestroy();
		else
			Destroy(other.gameObject);
	}
}
