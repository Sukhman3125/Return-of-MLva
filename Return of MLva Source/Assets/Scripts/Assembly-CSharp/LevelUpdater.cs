using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUpdater : MonoBehaviour
{
	private void Start()
	{
		PlayerPrefs.SetInt("CurrentLevel", SceneManager.GetActiveScene().buildIndex);
		if (SceneManager.GetActiveScene().buildIndex > PlayerPrefs.GetInt("MaxLevelReached", 1))
		{
			PlayerPrefs.SetInt("MaxLevelReached", SceneManager.GetActiveScene().buildIndex);
		}
	}
}
