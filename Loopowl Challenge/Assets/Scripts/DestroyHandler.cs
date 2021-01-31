using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHandler : MonoBehaviour
{
	[SerializeField]
	private DestroyHandler _root = null;
	[SerializeField]
	private DestroyHandler[] _children;

	private bool _handle = true;
	public void DoDestroy()
	{
		if (_handle)
		{
			if (_root != null)
				_root.DoDestroy();
			else
			{
				foreach (var child in _children)
				{
					child._handle = false;
				}
				Destroy(gameObject);
			}
		}
	}
}
