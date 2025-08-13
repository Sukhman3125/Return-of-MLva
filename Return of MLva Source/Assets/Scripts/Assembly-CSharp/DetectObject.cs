using UnityEngine;

public class DetectObject : MonoBehaviour
{
	[SerializeField]
	private string BinType;

	private int noOfObjects;

	public bool done;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag(BinType))
		{
			Object.Destroy(collision.gameObject);
			noOfObjects++;
		}
	}

	private void Update()
	{
		if (noOfObjects == 4)
		{
			done = true;
		}
	}
}
