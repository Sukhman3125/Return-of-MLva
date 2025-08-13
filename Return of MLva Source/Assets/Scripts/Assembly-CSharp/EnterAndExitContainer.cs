using UnityEngine;

public class EnterAndExitContainer : MonoBehaviour
{
	[SerializeField]
	private DetectObjectsNew detectObjectsNewScript;

	private Vector2 prevPos;

	private float maxX;

	private float minX;

	private float maxY;

	private float minY;

	private void Start()
	{
		prevPos = base.transform.position;
		maxX = detectObjectsNewScript.ContainerTop.transform.position.x;
		minX = detectObjectsNewScript.ContainerBottom.transform.position.x;
		maxY = detectObjectsNewScript.ContainerTop.transform.position.y;
		minY = detectObjectsNewScript.ContainerBottom.transform.position.y;
		if (base.transform.position.x <= maxX && base.transform.position.x >= minX && base.transform.position.y <= maxY && base.transform.position.y >= minY)
		{
			detectObjectsNewScript.InsideBox();
		}
	}

	private void Update()
	{
		if ((prevPos.x > maxX || prevPos.y > maxY || prevPos.x < minX || prevPos.y < minY) && base.transform.position.x < maxX && base.transform.position.x > minX && base.transform.position.y < maxY && base.transform.position.y > minY)
		{
			detectObjectsNewScript.InsideBox();
		}
		else if (prevPos.x < maxX && prevPos.y < maxY && prevPos.x > minX && prevPos.y > minY && (base.transform.position.x > maxX || base.transform.position.x < minX || base.transform.position.y > maxY || base.transform.position.y < minY))
		{
			detectObjectsNewScript.OutsideBox();
		}
		prevPos = base.transform.position;
	}
}
