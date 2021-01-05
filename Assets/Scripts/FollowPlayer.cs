using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //public variables
    public GameObject player;
    public GameObject player_weapon;
    //private variables
    [SerializeField] private Vector3 cameraOffset = new Vector3(0, 7, -10);

    // Update is called once per frame
    void LateUpdate()
    {
        //move camera to player + offset
        transform.position = player.transform.position + cameraOffset;
    }
}
