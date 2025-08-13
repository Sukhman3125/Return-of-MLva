using UnityEngine;

public class Graph : MonoBehaviour
{
	private Vector2[] GraphPoints = new Vector2[100];

	public float a;

	public float b;

	public float t;

	public float StartPosX = -10f;

	public float EndPosX = 30f;

	public Transform bottomLeft;

	public Transform topRight;

	public float StartPosY = -10f;

	public float EndPosY = 50f;

	[SerializeField]
	private Canvas canvas;

	[SerializeField]
	private Transform Camera;

	private LineRenderer lineRenderer;

	private void Start()
	{
		lineRenderer = base.gameObject.AddComponent<LineRenderer>();
		lineRenderer.positionCount = GraphPoints.Length;
		lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
		lineRenderer.startColor = Color.black;
		lineRenderer.endColor = Color.black;
		lineRenderer.startWidth = 0.03f;
		lineRenderer.endWidth = 0.03f;
		lineRenderer.sortingOrder = 2;
	}

	private void Update()
	{
		for (int i = 0; i < GraphPoints.Length; i++)
		{
			float num = StartPosX + (float)i * (EndPosX / (float)(GraphPoints.Length - 1));
			float y = a / (1f + b * Mathf.Exp(t * num));
			GraphPoints[i] = new Vector2(num, y);
		}
		for (int j = 0; j < GraphPoints.Length; j++)
		{
			float x = Map(GraphPoints[j].x, StartPosX, EndPosX, bottomLeft.position.x, topRight.position.x);
			float y2 = Map(GraphPoints[j].y, StartPosY, EndPosY, bottomLeft.position.y, topRight.position.y);
			lineRenderer.SetPosition(j, new Vector3(x, y2, 0f));
		}
		if (Camera.transform.position.x != 0f)
		{
			canvas.enabled = true;
		}
		else
		{
			canvas.enabled = false;
		}
	}

	private float Map(float value, float inMin, float inMax, float outMin, float outMax)
	{
		if (inMax == inMin)
		{
			Debug.LogError("InMin and InMax cannot be equal! Cannot map values.");
			return 0f;
		}
		return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
	}
}
