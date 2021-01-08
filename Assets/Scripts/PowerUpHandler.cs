using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHandler : MonoBehaviour
{
    [Range(1, 3)]
    [SerializeField]private int powerupType;

    private int HealthPotAdd = 500;

    private GameObject spawn;

    // Start is called before the first frame update
    void Start()
    {
        spawn = GameObject.Find("SpawnCube");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("owo");
        switch (powerupType)
        {
            case 1: spawn.GetComponent<SpawnThingHandler>().AddHealth(HealthPotAdd); break;
        }
        Destroy(this.gameObject);
    }
}
