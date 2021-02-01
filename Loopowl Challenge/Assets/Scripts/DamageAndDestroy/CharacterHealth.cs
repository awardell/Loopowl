using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField]
    private int _startHealth = 3;

    [SerializeField]
    public UnityEvent OnHealthDepleted;

    private int _curHealth = 0;

	private void OnEnable()
	{
        _curHealth = _startHealth;
	}

	public void Damage(int amount)
	{
        _curHealth -= amount;
        if (_curHealth <= 0)
            OnHealthDepleted?.Invoke();
	}

    public int GetCurHealth()
	{
        return _curHealth;
	}
}
