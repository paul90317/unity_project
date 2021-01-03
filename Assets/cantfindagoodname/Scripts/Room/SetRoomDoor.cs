using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRoomDoor : MonoBehaviour {
    [SerializeField] public List<GameObject> bottomRooms, topRooms, leftRooms, rightRooms;

    public GameObject closedRoom;
}
