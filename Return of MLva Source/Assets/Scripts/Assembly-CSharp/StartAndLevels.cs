using UnityEngine;
using UnityEngine.SceneManagement;

public class StartAndLevels : MonoBehaviour
{
	[SerializeField]
	private GameObject Camera;

	[SerializeField]
	private Transform MenuTransform;

	[SerializeField]
	private Canvas MainCanvas;

	[SerializeField]
	private Canvas LevelCanvas;

	private Vector3 initialCameraPos;

	private void Start()
	{
		initialCameraPos = Camera.transform.position;
		MainCanvas.enabled = true;
		LevelCanvas.enabled = false;
	}

	public void StartLevel()
	{
		SceneManager.LoadScene(PlayerPrefs.GetInt("CurrentLevel", 1));
	}

	public void LevelMenu()
	{
		Camera.transform.position = MenuTransform.position + 10f * Vector3.back;
		MainCanvas.enabled = false;
		LevelCanvas.enabled = true;
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Camera.transform.position = initialCameraPos;
			MainCanvas.enabled = true;
			LevelCanvas.enabled = false;
		}
	}
}
