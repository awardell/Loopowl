using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Manages where the user is aiming on the screen
public class AimManager : MonoBehaviour
{
	public static AimManager Instance { get; private set; } = null;

	public Vector3 Target { get; private set; } = Vector3.zero;

	public Vector3 ScreenTarget { get; private set; } = Vector3.zero;

	[SerializeField]
	private Camera _camera;

	[SerializeField]
	private Transform _targetTransform; //Cinemachine needs this

	private Plane _plane;

	private void Awake()
	{
		Instance = this;
		_plane = new Plane(Vector3.back, 0f);
	}

	private void Update()
	{
		//clamp our screen point to our viewport
		var bottomLeft = _camera.ViewportToScreenPoint(Vector3.zero);
		var topRight = _camera.ViewportToScreenPoint(new Vector3(1f, 1f, 0f));
		var screenPoint = Input.mousePosition;
		screenPoint.x = Mathf.Clamp(screenPoint.x, bottomLeft.x, topRight.x);
		screenPoint.y = Mathf.Clamp(screenPoint.y, bottomLeft.y, topRight.y);
		ScreenTarget = screenPoint;

		//get the position we're targeting
		Ray ray = _camera.ScreenPointToRay(screenPoint);
		float hit;
		if (_plane.Raycast(ray, out hit))
		{
			Target = ray.GetPoint(hit);
			_targetTransform.position = Target;
		}
	}
}
