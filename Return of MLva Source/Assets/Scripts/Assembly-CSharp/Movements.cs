using System.Collections;
using UnityEngine;

public class Movements : MonoBehaviour
{
	[Header("Keys")]
	[SerializeField]
	private KeyCode WalkForward = KeyCode.D;

	[SerializeField]
	private KeyCode WalkForwardAlt = KeyCode.RightArrow;

	[SerializeField]
	private KeyCode WalkBackward = KeyCode.A;

	[SerializeField]
	private KeyCode WalkBackwardAlt = KeyCode.LeftArrow;

	[SerializeField]
	private KeyCode JumpKey = KeyCode.Space;

	[SerializeField]
	private KeyCode JumpKeyAlt = KeyCode.UpArrow;

	[Space]
	[Header("Adjustments")]
	public float WalkSpeed = 3f;

	[SerializeField]
	private float JumpHeight = 1f;

	[SerializeField]
	private float animationDelay = 0.15f;

	[SerializeField]
	private float RayDistance = 1f;

	[SerializeField]
	private LayerMask WallsLayer;

	public bool AntiGravity_Level2;

	[Space]
	[Header("References")]
	[SerializeField]
	private Sprite IdleSprite;

	[SerializeField]
	private Sprite WalkSprite;

	[SerializeField]
	private string wallsTag;

	[SerializeField]
	private string KeyTag;

	[SerializeField]
	private Transform TopPosition;

	[SerializeField]
	private Transform BottomPosition;

	public GameObject myKey;

	[HideInInspector]
	public float xInput;

	private bool JumpKeyDown;

	private bool WalkAnimActive;

	private SpriteRenderer SpriteRenderer;

	private Rigidbody2D rb;

	private Coroutine WalkCoroutine;

	[HideInInspector]
	public bool AntiGravityEnabled;

	[SerializeField]
	private AudioSource WalkSound;

	private void Start()
	{
		SpriteRenderer = GetComponent<SpriteRenderer>();
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		InputHandler();
		if (JumpKeyDown && (rb.linearVelocity.y == 0f || AntiGravityEnabled))
		{
			Jump();
		}
	}

	private void FixedUpdate()
	{
		Walk();
	}

	private void InputHandler()
	{
		if (Input.GetKey(WalkForward) || Input.GetKey(WalkForwardAlt))
		{
			xInput = 1f;
		}
		else if (Input.GetKey(WalkBackward) || Input.GetKey(WalkBackwardAlt))
		{
			xInput = -1f;
		}
		else
		{
			xInput = 0f;
		}
		if (Input.GetKeyDown(JumpKey) || Input.GetKeyDown(JumpKeyAlt))
		{
			JumpKeyDown = true;
		}
		else
		{
			JumpKeyDown = false;
		}
	}

	private void Jump()
	{
		rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Sqrt(2f * Mathf.Abs(Physics.gravity.y) * JumpHeight));
	}

	private void Walk()
	{
		if (!StopWalking())
		{
			if (xInput != 0f)
			{
				base.transform.Translate(xInput * WalkSpeed * Time.deltaTime, 0f, 0f);
			}
			if (!WalkAnimActive)
			{
				WalkCoroutine = StartCoroutine(PlayerWalkAnimation());
			}
			if (!WalkSound.isPlaying && rb.linearVelocity.y == 0f && xInput != 0f)
			{
				WalkSound.Play();
			}
			else if (WalkSound.isPlaying && (rb.linearVelocity.y != 0f || xInput == 0f))
			{
				WalkSound.Stop();
			}
		}
		else
		{
			WalkSound.Stop();
			if (WalkCoroutine != null)
			{
				StopCoroutine(WalkCoroutine);
				WalkCoroutine = null;
				SpriteRenderer.sprite = IdleSprite;
				WalkAnimActive = false;
			}
		}
		if (xInput == 1f)
		{
			SpriteRenderer.flipX = false;
		}
		if (xInput == -1f)
		{
			SpriteRenderer.flipX = true;
		}
	}

	private IEnumerator PlayerWalkAnimation()
	{
		WalkAnimActive = true;
		while (xInput != 0f)
		{
			SpriteRenderer.sprite = WalkSprite;
			yield return new WaitForSeconds(animationDelay);
			SpriteRenderer.sprite = IdleSprite;
			yield return new WaitForSeconds(animationDelay);
		}
		WalkAnimActive = false;
	}

	private bool StopWalking()
	{
		Vector2 direction = new Vector2(xInput, 0f);
		RaycastHit2D raycastHit2D = Physics2D.Raycast(TopPosition.position, direction, RayDistance, WallsLayer);
		RaycastHit2D raycastHit2D2 = Physics2D.Raycast(BottomPosition.position, direction, RayDistance, WallsLayer);
		RaycastHit2D raycastHit2D3 = Physics2D.Raycast(base.transform.position, direction, RayDistance, WallsLayer);
		if (raycastHit2D.collider != null && raycastHit2D.collider.gameObject.CompareTag(wallsTag))
		{
			return true;
		}
		if (raycastHit2D2.collider != null && raycastHit2D2.collider.gameObject.CompareTag(wallsTag))
		{
			return true;
		}
		if (raycastHit2D3.collider != null && raycastHit2D3.collider.gameObject.CompareTag(wallsTag))
		{
			return true;
		}
		return false;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag(KeyTag))
		{
			myKey.GetComponent<PlayerKey>().PlayersGetsKey();
			collision.gameObject.SetActive(value: false);
		}
	}
}
