using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newRoomData", menuName = "Room/RoomData")]
public class RoomData : ScriptableObject {

    public TextAsset roomMap;
    public int[] monsterWave;
}
