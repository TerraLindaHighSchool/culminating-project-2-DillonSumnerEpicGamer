using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnThingHandler : MonoBehaviour
{
    public GameObject healthOBJ;
    private bool gameOver = false;

    [SerializeField] private int health = 1000;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkHealth();
    }

    public void TakeDamage(int dmg)
    {
        health = health - dmg;
    }

    void checkHealth()
    {
        SpriteRenderer healthColour = healthOBJ.GetComponent<SpriteRenderer>();
        if (health > 500)
        {
            healthColour.color = Color.green;
        }
        else if (health > 100)
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
            gameOver = true;
            Debug.LogError("GAME OVER");
        }
    }
}
