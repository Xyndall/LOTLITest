using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToRoom : MonoBehaviour
{
    public bool doorTouched;

    public RoomType roomType;

    [SerializeField]
    Vector3 pos;

    public Animator transition;
    float transitionTime = 1.5f;

    GameObject player;
    float playerYPos = 1;

    int roomNumber;

    private void Start()
    {
        transition = GameObject.FindWithTag("Transition").GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.tag == "Player" && !doorTouched)
        {
            player = other.gameObject;

            StartCoroutine(RoomTransition());

            switch (roomType)
            {

                case RoomType.Upgrade:
                    RoomManager.instance.SpawnUpgradeRoom();

                    break;

                case RoomType.Shop:
                    RoomManager.instance.SpawnShopRoom();

                    break;

                case RoomType.Challenge:
                    RoomManager.instance.SpawnChallengeRoom();
                    break;
            }
        }


    }

    IEnumerator RoomTransition()
    {
        roomNumber = RoomManager.instance.RoomNumber;
        transition.SetTrigger("Start");
        doorTouched = true;
        yield return new WaitForSeconds(transitionTime);

        pos = RoomManager.instance.RoomSpawn[roomNumber].transform.position;
        pos.y = playerYPos;

        player.transform.position = pos;
        
        DestroyRoom();

        doorTouched = false;
        
    }


    void DestroyRoom()
    {

        Destroy(transform.parent.gameObject);

    }

}
