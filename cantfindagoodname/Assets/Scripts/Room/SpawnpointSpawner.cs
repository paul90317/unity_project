using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnpointSpawner : MonoBehaviour {
    public enum NeighbourDoor{
        Bottom,
        Top,
        Left,
        Right
    };

    System.Random rnd = new System.Random();
    public NeighbourDoor openingDirection;
    private SetRoomDoor templates; // Component for roomTemplate
    private bool flag = false; // flag for spawned or not
    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Room").GetComponent<SetRoomDoor>();
        // 0.1s delay Function call
        Invoke("Spawn", 0.1f);
    }
    private void Spawn()
    {
        if (!flag)
        {
            int randomInt;
            switch (openingDirection)
            {
                case NeighbourDoor.Bottom:
                    randomInt = rnd.Next(templates.bottomRooms.Count);
                    Instantiate(templates.bottomRooms[randomInt], transform.position, Quaternion.identity);
                    break;
                case NeighbourDoor.Top:
                    randomInt = rnd.Next(templates.topRooms.Count);
                    Instantiate(templates.topRooms[randomInt], transform.position, Quaternion.identity);
                    break;
                case NeighbourDoor.Left:
                    randomInt = rnd.Next(templates.leftRooms.Count);
                    Instantiate(templates.leftRooms[randomInt], transform.position, Quaternion.identity);
                    break;
                case NeighbourDoor.Right:
                    randomInt = rnd.Next(templates.rightRooms.Count);
                    Instantiate(templates.rightRooms[randomInt], transform.position, Quaternion.identity);
                    break;
                default: break;
            }
            flag = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) // is component of spawnPoint
    {
        if (collision.CompareTag("SpawnPoint"))
        {
            if (collision.GetComponent<SpawnpointSpawner>().flag == false && flag == false)
            {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            flag = true;
        }
    }
}
