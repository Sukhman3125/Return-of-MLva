using UnityEngine;

public class DoorInLevel : MonoBehaviour
{
	[SerializeField]
	private GameObject Shadow;

	[SerializeField]
	private GameObject EHelper;

	[SerializeField]
	private Transform OtherDoor;

	[SerializeField]
	private Transform OrignalRoom;

	[SerializeField]
	private Transform SideRoom;

	[SerializeField]
	private GameObject Player;

	[SerializeField]
	private GameObject Camera;

	private AudioSource AudioSource;

	private bool DoorIsActive;

	private void Start()
	{
		AudioSource = GetComponent<AudioSource>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		DoorIsActive = true;
		Shadow.SetActive(value: true);
		EHelper.SetActive(value: true);
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		DoorIsActive = false;
		Shadow.SetActive(value: false);
		EHelper.SetActive(value: false);
	}

	private void Update()
	{
		if (!DoorIsActive || !Input.GetKeyDown(KeyCode.E))
		{
			return;
		}
		if (!AudioSource.isPlaying)
		{
			AudioSource.Play();
		}
		Player.transform.position = OtherDoor.position;
		if (Camera.transform.position == OrignalRoom.position + Vector3.back * 10f)
		{
			Camera.transform.position = SideRoom.position + Vector3.back * 10f;
			if (Player.GetComponent<Movements>().AntiGravity_Level2)
			{
				Player.GetComponent<Movements>().AntiGravityEnabled = true;
			}
		}
		else
		{
			Camera.transform.position = OrignalRoom.position + Vector3.back * 10f;
			if (Player.GetComponent<Movements>().AntiGravity_Level2)
			{
				Player.GetComponent<Movements>().AntiGravityEnabled = false;
			}
		}
	}
}
