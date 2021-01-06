using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHandler : MonoBehaviour
{
    private Rigidbody rb;
    public ParticleSystem explosionParticle;

    [SerializeField]private float speed = 50f;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void DestroyThis()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
      if (collision.gameObject.CompareTag("Ground"))
        {
            explosionParticle.Play();
            Debug.Log("Hit Ground");
        }
    }

}
