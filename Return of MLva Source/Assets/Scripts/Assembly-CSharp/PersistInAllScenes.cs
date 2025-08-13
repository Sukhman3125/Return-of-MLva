using UnityEngine;

public class PersistInAllScenes : MonoBehaviour
{
	private static PersistInAllScenes instance;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			Object.DontDestroyOnLoad(base.gameObject);
		}
		else
		{
			Object.Destroy(base.gameObject);
		}
	}
}
