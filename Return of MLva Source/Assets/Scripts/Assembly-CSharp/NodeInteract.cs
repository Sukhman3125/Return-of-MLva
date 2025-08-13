using UnityEngine;

public class NodeInteract : MonoBehaviour
{
	[SerializeField]
	private GameObject Highlight;

	[SerializeField]
	private GameObject Player;

	public bool isActive;

	public int connectedNodes;

	public int myIndex;

	private bool quotaCompleted;

	[SerializeField]
	private int no_of_connections_req;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Highlight.SetActive(value: true);
		isActive = true;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		Highlight.SetActive(value: false);
		isActive = false;
	}

	private void Update()
	{
		if (isActive && Input.GetKeyDown(KeyCode.E) && !base.gameObject.CompareTag("BlueNode") && !quotaCompleted)
		{
			Player.GetComponent<NodeLineRenderer>().RenderLine(base.gameObject);
		}
		if (connectedNodes == no_of_connections_req)
		{
			quotaCompleted = true;
		}
		else if (connectedNodes == no_of_connections_req)
		{
			quotaCompleted = true;
		}
	}
}
