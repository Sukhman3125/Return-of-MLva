using UnityEngine;

public class KeyKeyBackLevel4 : MonoBehaviour
{
	[SerializeField]
	private GameObject[] bins = new GameObject[3];

	[SerializeField]
	private DetectObject[] detectObjects = new DetectObject[3];

	[SerializeField]
	private GameObject Key;

	[SerializeField]
	private Death death;

	private void Start()
	{
		for (int i = 0; i < bins.Length; i++)
		{
			detectObjects[i] = bins[i].GetComponent<DetectObject>();
		}
	}

	private void Update()
	{
		if (detectObjects[0].done && detectObjects[1].done && detectObjects[2].done)
		{
			Key.SetActive(value: true);
			death.KeyWasThere = true;
			base.enabled = false;
		}
	}
}
