using UnityEngine;

public class NodeLineRenderer : MonoBehaviour
{
	private LineRenderer lineRenderer;

	private GameObject LineRendererTarget;

	[SerializeField]
	private GameObject key;

	public int CurrentlyOnNode;

	[SerializeField]
	private GameObject[] lines_Green_Red = new GameObject[12];

	[SerializeField]
	private GameObject[] lines_Red_Blue = new GameObject[12];

	[SerializeField]
	private bool[] Green_Red_Already = new bool[12];

	[SerializeField]
	private bool[] Red_Blue_Already = new bool[12];

	private int NoConnected;

	private int NoConnectedPrev;

	private void Start()
	{
		lineRenderer = GetComponent<LineRenderer>();
		lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
		lineRenderer.startColor = Color.red;
		lineRenderer.endColor = Color.red;
		lineRenderer.startWidth = 0.05f;
		lineRenderer.endWidth = 0.05f;
		lineRenderer.positionCount = 2;
	}

	public void RenderLine(GameObject Node)
	{
		LineRendererTarget = Node;
	}

	private void Update()
	{
		if (LineRendererTarget != null)
		{
			lineRenderer.SetPosition(0, base.transform.position);
			lineRenderer.SetPosition(1, LineRendererTarget.transform.position);
			if (LineRendererTarget.CompareTag("GreenNode"))
			{
				CurrentlyOnNode = 0;
			}
			else if (LineRendererTarget.CompareTag("RedNode"))
			{
				CurrentlyOnNode = 1;
			}
			else if (LineRendererTarget.CompareTag("BlueNode"))
			{
				CurrentlyOnNode = 2;
			}
		}
		else
		{
			CurrentlyOnNode = -1;
			lineRenderer.SetPosition(0, base.transform.position);
			lineRenderer.SetPosition(1, base.transform.position);
		}
		if (NoConnected == 15 && NoConnectedPrev == 14)
		{
			GetComponent<Death>().KeyWasThere = true;
			key.SetActive(value: true);
		}
		NoConnectedPrev = NoConnected;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("RedNode") && CurrentlyOnNode == 0)
		{
			int num = LineRendererTarget.GetComponent<NodeInteract>().myIndex * 4 + collision.GetComponent<NodeInteract>().myIndex;
			if (!Green_Red_Already[num])
			{
				LineRendererTarget.GetComponent<NodeInteract>().connectedNodes++;
				lines_Green_Red[num].SetActive(value: true);
				Green_Red_Already[num] = true;
				LineRendererTarget = null;
				NoConnected++;
			}
		}
		else if (collision.CompareTag("BlueNode") && CurrentlyOnNode == 1)
		{
			int num2 = LineRendererTarget.GetComponent<NodeInteract>().myIndex * 3 + collision.GetComponent<NodeInteract>().myIndex;
			if (!Red_Blue_Already[num2])
			{
				LineRendererTarget.GetComponent<NodeInteract>().connectedNodes++;
				lines_Red_Blue[num2].SetActive(value: true);
				Red_Blue_Already[num2] = true;
				LineRendererTarget = null;
				NoConnected++;
			}
		}
		if (collision.CompareTag("Door"))
		{
			CurrentlyOnNode = -1;
			lineRenderer.SetPosition(0, base.transform.position);
			lineRenderer.SetPosition(1, base.transform.position);
			LineRendererTarget = null;
		}
	}
}
