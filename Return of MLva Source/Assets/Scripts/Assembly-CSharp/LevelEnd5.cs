using UnityEngine;

public class LevelEnd5 : MonoBehaviour
{
	[SerializeField]
	private GameObject[] containers = new GameObject[3];

	[SerializeField]
	private DetectObjectsNew[] detectObjectsNew = new DetectObjectsNew[3];

	[SerializeField]
	private GameObject Key;

	[SerializeField]
	private Death death;

	private void Start()
	{
		for (int i = 0; i < containers.Length; i++)
		{
			detectObjectsNew[i] = containers[i].GetComponent<DetectObjectsNew>();
		}
	}

	private void Update()
	{
		if (detectObjectsNew[0].objHeld + detectObjectsNew[1].objHeld + detectObjectsNew[2].objHeld == 13)
		{
			Key.SetActive(value: true);
			death.KeyWasThere = true;
			base.enabled = false;
		}
	}
}
