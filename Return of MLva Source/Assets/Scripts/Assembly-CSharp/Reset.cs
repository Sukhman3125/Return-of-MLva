using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
	public void resetEverything()
	{
		PlayerPrefs.SetInt("MaxLevelReached", 1);
		PlayerPrefs.SetInt("CurrentLevel", 1);
		SceneManager.LoadScene(0);
	}
}
