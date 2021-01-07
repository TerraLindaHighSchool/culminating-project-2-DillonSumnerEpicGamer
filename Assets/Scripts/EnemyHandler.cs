using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    public GameObject playerSpawn;
    public GameObject healthShowingThing;

    [Range(1, 3)]
    [SerializeField]private int typeNPC;
    [Range(0, 100)]
    [SerializeField] private int health = 100;

    private bool hasSeenPlayer = false;
    private bool isAttackingSpawn = false;
    private bool isDead = false;

    
    private int damage;

    // Start is called before the first frame update
    void Start()
    {
        switch (typeNPC)
        {
            //tank
            case 1: damage = 10;
                break;
            //heal
            case 2: damage = 1;
                break;
            //speed
            case 3: damage = 5;
                break;
            //useless
            default: damage = 0;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rayStartPos = new Vector3(0, 1, 0);
        RaycastHit hit;

        float sightRange = 10;

        if (Physics.Raycast(transform.position + rayStartPos, transform.TransformDirection(Vector3.forward), out hit, sightRange))
        {
           Debug.DrawRay(transform.position + rayStartPos, transform.TransformDirection(Vector3.forward) * sightRange, Color.yellow);
            transform.Rotate(0, Random.Range(-45,45), 0, Space.Self);
            if (hit.transform.CompareTag("EditorOnly"))
            {
                Debug.Log(hit.transform.name);
            }
        }
        else
        {
           Debug.DrawRay(transform.position + rayStartPos, transform.TransformDirection(Vector3.forward) * sightRange, Color.white);
           if (!isAttackingSpawn)
           {
                moveToSpawn();
           }
        }

        checkHealth();
    }

    void moveToPlayer()
    {

    }

    void moveToSpawn()
    {

    }

    void checkHealth()
    {
        SpriteRenderer healthColour = healthShowingThing.GetComponent<SpriteRenderer>();
        if (health > 50)
        {
            healthColour.color = Color.green;
        }
        else if (health > 10)
        {
            healthColour.color = Color.yellow;
        }
        else if (health > 0)
        {
            healthColour.color = Color.red;
        }
        else
        {
            healthColour.color = Color.black;
            isDead = true;
        }
    }
}
