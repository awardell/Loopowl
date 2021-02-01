using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneBehaviour : MonoBehaviour
{
	[SerializeField]
	private string _sceneName = "GameOver";

    public void Load(float wait)
	{
		StartCoroutine(LoadGameOverRoutine(wait));
	}

	private IEnumerator LoadGameOverRoutine(float wait)
	{
		yield return new WaitForSeconds(wait);
		SceneManager.LoadScene(_sceneName);
	}
}
