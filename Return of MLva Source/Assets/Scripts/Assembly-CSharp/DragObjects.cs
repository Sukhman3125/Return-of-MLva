using UnityEngine;

public class DragObjects : MonoBehaviour
{
	private Vector2 difference = Vector2.zero;

	private Vector2 InitialPos;

	[SerializeField]
	private Transform UpperBound;

	[SerializeField]
	private Transform LowerBound;

	private void Start()
	{
		InitialPos = base.transform.position;
	}

	private void OnMouseDown()
	{
		difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - base.transform.position;
	}

	private void OnMouseDrag()
	{
		base.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
	}

	private void Update()
	{
		if (base.transform.position.x > UpperBound.position.x || base.transform.position.x < LowerBound.position.x)
		{
			base.transform.position = InitialPos;
		}
		if (base.transform.position.y > UpperBound.position.y || base.transform.position.y < LowerBound.position.y)
		{
			base.transform.position = InitialPos;
		}
	}
}
