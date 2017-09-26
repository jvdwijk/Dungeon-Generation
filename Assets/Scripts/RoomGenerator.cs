using System.Collections;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
	[SerializeField] private GameObject[] _roomPrefabs;
	[SerializeField] private int _roomCount;
	private GameObject[] Rooms;
	
	private void Start () {
		SpawnRooms();
		StartCoroutine(RoomSeperator());
	}
	
	private void SpawnRooms ()
	{
		Rooms = new GameObject[_roomCount];
		//Instantiate the given amount of rooms, Choose random rooms from the prefab list.
		for (var i = 0; i < _roomCount; i++)
		{
			Rooms[i] = Instantiate(_roomPrefabs[Random.Range(0, _roomPrefabs.Length)], new Vector3(0, 0, 1), transform.rotation);
		}
	}

	private IEnumerator RoomSeperator()
	{
		for (var i = 0; i < _roomCount; i++)
		{
			print(MoveObject.CheckPosition(Rooms[i], Rooms));
			while (MoveObject.CheckPosition(Rooms[i], Rooms))
			{
				
				MoveObject.MoveRoom(Rooms[i]);
				yield return new WaitForSeconds(1);
			}
			MoveObject.MoveRoom(Rooms[i]);
		}
	}
	
	//ToDo: connect Exits to other Exits
	//ToDo: Move rooms away from each other
	//ToDo: Make paths to each room.
}
