using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnKeypress : MonoBehaviour
{
    [SerializeField]
    private string _sceneToLoad = "Game";

    private void Update()
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
