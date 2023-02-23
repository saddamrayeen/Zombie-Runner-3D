using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScripts : MonoBehaviour
{
   public Rigidbody mybody;

    // Start is called before the first frame update
    void Start()
    {
        mybody = GetComponent<Rigidbody>();
    }

    public void ShootBullet(float speed)
    {
        mybody.AddForce(transform.position.normalized * speed);
        Invoke("DestroyBullet", 5f);
    }

    public void DestroyBullet()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag == "Obstacle")
        {
            Destroy(this.gameObject);
        }
    }
}
