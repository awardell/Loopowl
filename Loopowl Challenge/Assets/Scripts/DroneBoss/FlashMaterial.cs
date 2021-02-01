using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashMaterial : MonoBehaviour
{
    [SerializeField]
    [GetComponent(typeof(MeshRenderer))]
    private MeshRenderer _renderer;

    [SerializeField]
    private float _duration = .1f;

    [SerializeField]
    private Color _color;

    public void Flash()
    {
        StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
	{
        var mat = _renderer.material;
        var origColor = mat.color;
        mat.color = _color;
        yield return new WaitForSeconds(_duration);
        mat.color = origColor;
	}
}
