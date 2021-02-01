using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnKeypress : MonoBehaviour
{
    [SerializeField]
    private string _sceneToLoad = "Game";

    [SerializeField]
    private float _timeout = 1f;

    private float _timer;

	private void Start()
	{
        _timer = _timeout;
	}

	private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer < 0f)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
            else if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(_sceneToLoad);
            }
        }
    }
}
