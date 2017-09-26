using UnityEngine;

public static class MoveObject
{
    public static bool CheckPosition(GameObject room, GameObject[] rooms)
    {
        var currentRoomWidth = room.GetComponent<Collider>().bounds.size;
        var roomPosition = room.transform.position;
        var roomRect = new Rect(roomPosition,currentRoomWidth);
        for (var i = 0; i < rooms.Length; i++)
        {
            if(room.gameObject == rooms[i].gameObject) continue;
            var checkingRoomWidth = rooms[i].GetComponent<Collider>().bounds.size;
            var checkingRoomPosition = rooms[i].transform.position;
            var checkingRoomRect = new Rect(checkingRoomPosition, checkingRoomWidth);
            //&& roomPosition.z == checkingRoomPosition.z
            if (roomRect.Overlaps(checkingRoomRect)) return true;
        }
        return false;
    }
    
    public static void MoveRoom(GameObject room)
    {
        room.transform.position += new Vector3(0,5,0);
    }
}