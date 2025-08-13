using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSideUI : MonoBehaviour
{
	[SerializeField]
	private GameObject MenuButton;

	[SerializeField]
	private Image MusicIconSpriteRenderer;

	[SerializeField]
	private Sprite MusicIconOn;

	[SerializeField]
	private Sprite MusicIconOff;

	[SerializeField]
	private AudioSource bgAudio;

	private Canvas canvas;

	private bool PlayMusic;

	private void Start()
	{
		canvas = GetComponent<Canvas>();
	}

	private void Update()
	{
		if (SceneManager.GetActiveScene().buildIndex == 0)
		{
			MenuButton.SetActive(value: false);
		}
		else
		{
			MenuButton.SetActive(value: true);
		}
		if (canvas.worldCamera == null)
		{
			canvas.worldCamera = Camera.main;
		}
	}

	public void PlayStopMusic()
	{
		if (PlayMusic)
		{
			bgAudio.Play();
			MusicIconSpriteRenderer.sprite = MusicIconOn;
			PlayMusic = false;
		}
		else
		{
			bgAudio.Stop();
			MusicIconSpriteRenderer.sprite = MusicIconOff;
			PlayMusic = true;
		}
	}

	public void GoToMenu()
	{
		SceneManager.LoadScene(0);
	}
}
