using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CheckIfLevelisAvailable : MonoBehaviour
{
	[SerializeField]
	private int LevelNo;

	[SerializeField]
	private Sprite Unlocked;

	private Image image;

	private Button button;

	private void Start()
	{
		image = GetComponent<Image>();
		button = GetComponent<Button>();
		if (PlayerPrefs.GetInt("MaxLevelReached", 1) >= LevelNo)
		{
			image.sprite = Unlocked;
			button.enabled = true;
		}
	}

	public void LoadLevel()
	{
		SceneManager.LoadScene(LevelNo);
	}
}
