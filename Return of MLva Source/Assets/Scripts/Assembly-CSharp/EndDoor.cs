using UnityEngine;

public class EndDoor : MonoBehaviour
{
	[SerializeField]
	private float RayCastLength;

	[SerializeField]
	private Sprite OpenedDoorSprite;

	private Sprite ClosedDoorSprite;

	[SerializeField]
	private LayerMask PlayerlayerMask;

	private Collider2D myCollider;

	private SpriteRenderer myRenderer;

	private AudioSource AudioSource;

	private void Start()
	{
		AudioSource = GetComponent<AudioSource>();
		myCollider = GetComponent<Collider2D>();
		myRenderer = GetComponent<SpriteRenderer>();
		ClosedDoorSprite = myRenderer.sprite;
	}

	private void FixedUpdate()
	{
		RaycastHit2D raycastHit2D = Physics2D.Raycast(base.transform.position, Vector2.left, RayCastLength, PlayerlayerMask);
		if (raycastHit2D.collider != null && raycastHit2D.collider.gameObject.GetComponent<Movements>().myKey.GetComponent<PlayerKey>().PlayerHasKey)
		{
			myCollider.enabled = false;
			myRenderer.sprite = OpenedDoorSprite;
			raycastHit2D.collider.gameObject.GetComponent<Movements>().myKey.GetComponent<PlayerKey>().PlayersLosesKey();
			base.enabled = false;
			AudioSource.Play();
		}
	}

	public void RestoreOnDeath()
	{
		myCollider.enabled = true;
		myRenderer.sprite = ClosedDoorSprite;
	}
}
