using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField]
    private CharacterHealth _playerHealth;
    [SerializeField]
    private Image[] _healthPips;

	private void Update()
	{
		int curHealth = _playerHealth.GetCurHealth();
		for (int i = 0; i < _healthPips.Length; ++i)
		{
			_healthPips[i].enabled = curHealth > i;
		}
	}
}
