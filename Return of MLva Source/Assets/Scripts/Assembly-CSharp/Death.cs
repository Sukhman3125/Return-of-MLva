using System.Collections;
using UnityEngine;

public class Death : MonoBehaviour
{
	[SerializeField]
	private string SpikeTag;

	[SerializeField]
	private float TimeOffset = 0.5f;

	[SerializeField]
	private Transform SpawnPoint;

	[SerializeField]
	private GameObject DeadBodyPrefab;

	[SerializeField]
	private GameObject Key;

	[SerializeField]
	private GameObject myKey;

	[SerializeField]
	private GameObject EndDoorObj;

	[SerializeField]
	private GameObject myCamera;

	[SerializeField]
	private AudioSource DeathSound;

	private GameObject InstansisatedDeadBody;

	private Rigidbody2D rbPlayer;

	private Movements MovementsScript;

	private PlayerKey playerKeyScript;

	private bool isAlreadyDying;

	private Vector3 CameraInitialPos;

	public bool KeyWasThere;

	private void Start()
	{
		rbPlayer = GetComponent<Rigidbody2D>();
		playerKeyScript = myKey.GetComponent<PlayerKey>();
		MovementsScript = base.gameObject.GetComponent<Movements>();
		CameraInitialPos = myCamera.transform.position;
		KeyWasThere = Key.activeSelf;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag(SpikeTag) && !isAlreadyDying)
		{
			Die();
			playerKeyScript.PlayersLosesKey();
			Key.SetActive(KeyWasThere);
			EndDoorObj.GetComponent<EndDoor>().enabled = true;
			EndDoorObj.GetComponent<EndDoor>().RestoreOnDeath();
			myCamera.transform.position = CameraInitialPos;
		}
	}

	private void Die()
	{
		isAlreadyDying = true;
		StartCoroutine(DyingWait());
		if (InstansisatedDeadBody == null)
		{
			InstansisatedDeadBody = Object.Instantiate(DeadBodyPrefab, new Vector2(base.transform.position.x, base.transform.position.y - 0.3f), Quaternion.identity);
		}
		else
		{
			InstansisatedDeadBody.transform.position = base.transform.position;
		}
		InstansisatedDeadBody.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(MovementsScript.xInput * MovementsScript.WalkSpeed / 2f, 0f);
		base.transform.position = SpawnPoint.position;
		DeathSound.Play();
	}

	private IEnumerator DyingWait()
	{
		yield return new WaitForSeconds(TimeOffset);
		isAlreadyDying = false;
	}
}
