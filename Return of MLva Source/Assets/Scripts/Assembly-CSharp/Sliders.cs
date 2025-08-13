using UnityEngine;

public class Sliders : MonoBehaviour
{
	[SerializeField]
	private GameObject GraphObj;

	private Graph graphScript;

	[SerializeField]
	private Death deathScript;

	private float OptimalaValue = 43.2f;

	private float MidaValue = 35f;

	private float OptimalbValue = 2.6f;

	private float MidbValue = 3f;

	private float OptimaltValue = -0.3f;

	private float MidtValue;

	private bool aCheck;

	private bool bCheck;

	private bool tCheck;

	[SerializeField]
	private GameObject Key;

	private void Start()
	{
		graphScript = GraphObj.GetComponent<Graph>();
	}

	public void aSlider(float value)
	{
		graphScript.a = MidaValue + (value - 0.5f) * 2f * 25f;
	}

	public void bSlider(float value)
	{
		graphScript.b = MidbValue + (value - 0.5f) * 2f * 2.5f;
	}

	public void tSlider(float value)
	{
		graphScript.t = MidtValue + (value - 0.5f) * 2f * 0.5f;
	}

	private void Update()
	{
		if (OptimalaValue - 1.5f < graphScript.a && graphScript.a < OptimalaValue + 1.5f)
		{
			aCheck = true;
		}
		else
		{
			aCheck = false;
		}
		if (OptimalbValue - 0.2f < graphScript.b && graphScript.b < OptimalbValue + 0.2f)
		{
			bCheck = true;
		}
		else
		{
			bCheck = false;
		}
		if (OptimaltValue - 0.05f < graphScript.t && graphScript.t < OptimaltValue + 0.05f)
		{
			tCheck = true;
		}
		else
		{
			tCheck = false;
		}
		if (aCheck && bCheck && tCheck)
		{
			Key.SetActive(value: true);
			deathScript.KeyWasThere = true;
			Object.Destroy(base.gameObject);
		}
	}
}
