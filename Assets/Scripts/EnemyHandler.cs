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

    private bool isDead = false;
    private bool hasDamaged = false;
    private bool isAttacking = false;
    
    public int damage;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        playerSpawn = GameObject.Find("SpawnCube");

        switch (typeNPC)
        {
            //tank
            case 1: damage = 10; speed = 5;
                break;
            //heal
            case 2: damage = 1; speed = 10;
                break;
            //speed
            case 3: damage = 5; speed = 15;
                break;
            //useless
            default: damage = 0; speed = 0;
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

            if (hit.transform.CompareTag("Spawn") && !hasDamaged)
            {
                hasDamaged = true;
                isAttacking = true;
                hit.transform.GetComponent<SpawnThingHandler>().TakeDamage(damage);
            }
            else
            {
                if (!isAttacking)
                {
                    transform.Rotate(0, Random.Range(-45, 45), 0, Space.Self);
                }

                if (Random.Range(1,500) == 100)
                {
                    hasDamaged = false;
                }
            }
           
        }
        else
        {
            Debug.DrawRay(transform.position + rayStartPos, transform.TransformDirection(Vector3.forward) * sightRange, Color.white);
            Move(playerSpawn);
           
        }

        checkHealth();

        if (isDead)
        {
            Destroy(this.gameObject);
        }
    }

    public void damageEnemy(int dmg)
    {
        health = health - dmg;
    }

    void Move(GameObject thing)
    {
        float singleStep = Time.deltaTime * speed;
        Vector3 look = (playerSpawn.transform.position - transform.position);
        Vector3 lookVector = look.normalized;
        look.y = 0;
        var rotation = Quaternion.LookRotation(look);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, singleStep);

        transform.Translate(transform.right * singleStep);
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
