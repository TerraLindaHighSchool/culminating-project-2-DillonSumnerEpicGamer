using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHandler : MonoBehaviour
{
    public ParticleSystem explosionParticle;

    public int damage;

    private bool isExploded = false;

    [SerializeField]private float speed = 50f;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (transform.position.y < -200)
        {
            DestroyThis();
        }
    }

    void Explode()
    {
        isExploded = true;
        explosionParticle.Play();
        Invoke("DestroyThis", 1);
    }

    void DestroyThis()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground") && !isExploded)
        {
            Explode();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyHandler>().damageEnemy(damage);
        }
        
    }

}
