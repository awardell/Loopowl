using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField]
    [GetComponent(typeof(RectTransform))]
    private RectTransform _rectTransform;

	private void Start()
	{
		Cursor.visible = false;
	}

	//Quick and dirty. We're using a constant pixel size canvas
	//which allows this to match 1:1
	private void Update()
    {
        _rectTransform.anchoredPosition = AimManager.Instance.ScreenTarget;
    }
}
