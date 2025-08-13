using UnityEngine;

public class PlayerKey : MonoBehaviour
{
	private Movements MovementsScript;

	private SpriteRenderer spriteRenderer;

	public bool PlayerHasKey;

	private Vector2 initialKeyPos;

	private void Start()
	{
		MovementsScript = GetComponentInParent<Movements>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		initialKeyPos = base.transform.localPosition;
	}

	public void PlayersGetsKey()
	{
		PlayerHasKey = true;
	}

	public void PlayersLosesKey()
	{
		PlayerHasKey = false;
	}

	private void Update()
	{
		if (PlayerHasKey)
		{
			spriteRenderer.enabled = true;
		}
		else
		{
			spriteRenderer.enabled = false;
		}
		if (MovementsScript.xInput == 1f)
		{
			spriteRenderer.flipX = false;
			base.transform.localPosition = initialKeyPos;
		}
		else if (MovementsScript.xInput == -1f)
		{
			spriteRenderer.flipX = true;
			base.transform.localPosition = new Vector2(0f - initialKeyPos.x, base.transform.localPosition.y);
		}
	}
}
