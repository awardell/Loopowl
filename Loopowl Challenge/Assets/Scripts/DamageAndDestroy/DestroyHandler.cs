using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyHandler : MonoBehaviour
{
	[SerializeField]
	private DestroyHandler _root = null;
	[SerializeField]
	private DestroyHandler[] _children;

	[SerializeField]
	private bool _dontDestroy = false;

	[SerializeField]
	private UnityEvent OnDestroyPerformed;

	private bool _handle = true;
	public void PerformDestroy()
	{
		if (_handle)
		{
			if (_root != null)
				_root.PerformDestroy();
			else
			{
				foreach (var child in _children)
				{
					child._handle = false;
				}
				if (!_dontDestroy)
					Destroy(gameObject);

				OnDestroyPerformed?.Invoke();
			}
		}
	}
}
