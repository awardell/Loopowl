using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tweens the pitch and volume of a sound to give an effect
//like deactivating a machine
public class SoundTweenOff : MonoBehaviour
{
	[SerializeField]
	[GetComponent(typeof(AudioSource))]
	private AudioSource _audioSource;

	[SerializeField]
	private float _tweenDuration = 3f;

	[SerializeField]
	private float _targetPitch = .5f;

    public void Activate()
	{
		StartCoroutine(TweenRoutine());
	}

	private IEnumerator TweenRoutine()
	{
		float startVolume = _audioSource.volume;
		float startPitch = _audioSource.pitch;

		float t = 0;
		while (t < _tweenDuration)
		{
			t += Time.deltaTime;

			float delta = Mathf.Clamp(t / _tweenDuration, 0f, 1f);
			_audioSource.volume = Mathf.Lerp(startVolume, 0f, delta);
			_audioSource.pitch = Mathf.Lerp(startPitch, _targetPitch, delta);

			yield return null;
		}
	}
}
