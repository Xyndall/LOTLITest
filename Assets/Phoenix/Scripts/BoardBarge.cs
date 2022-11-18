using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardBarge : MonoBehaviour
{
    public Transform Destination;
    public GameObject Text;
    public GameObject Player;
    bool inTrigger;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (inTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player.transform.position = Destination.position;
                Debug.Log("Move");
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Text.SetActive(true);
            inTrigger = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Text.SetActive(false);
            inTrigger = false;
        }

    }
}
