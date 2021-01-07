using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHandler : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject[] projectilePrefabs;

    private int projectile = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //This here code is not made by me, but was made by iKabyLake30, I think I understand it maybe now.
        //https://answers.unity.com/questions/1699631/player-rotating-towards-mouse-3d.html
        //This is what I thought of doing, but I didn't know how to do it lol

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

        if (Input.GetMouseButtonDown(0))
        {
            ShootProjectile();
        }
    }
    void ShootProjectile()
    {
        //This function is what the name describes it to be, It shoots the projectile
        //But this function ALSO will change each projectile just because why not.
        Instantiate(projectilePrefabs[projectile],transform.position,transform.rotation);
    }
}
