using UnityEngine;

public class DetectObjectsNew : MonoBehaviour
{
	public int objHeld;

	public GameObject ContainerBottom;

	public GameObject ContainerTop;

	public void InsideBox()
	{
		objHeld++;
	}

	public void OutsideBox()
	{
		objHeld--;
	}
}
