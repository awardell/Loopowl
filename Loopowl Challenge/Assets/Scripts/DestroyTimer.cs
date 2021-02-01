using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
	private float _time = 2.2f;

    private IEnumerator Start()
	{
		yield return new WaitForSeconds(_time);
		Destroy(gameObject);
	}
}
