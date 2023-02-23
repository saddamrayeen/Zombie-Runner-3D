using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    [SerializeField]
    GameObject

            bloodFX,
            explosionFX;

    Rigidbody body;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    private void Die()
    {
        body.velocity = Vector3.zero;
        GetComponent<Collider>().enabled = false;
        GetComponentInChildren<Animator>().Play("Idle");
        FindObjectOfType<GamePlayController>().addZombieScore();
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        transform.localScale = new Vector3(1f, 1f, 0.2f);
        transform.position =
            new Vector3(transform.position.x, 0.2f, transform.position.z);
    }

    private void DestroyOBJ()
    {
        Destroy(gameObject, 3f);
    }

    public void OnTriggerEnter(Collider target)
    {
        if (target.tag == MyTags.PLAYER_TAG || target.tag == "Bullet")
        {
            Instantiate(bloodFX, transform.position, Quaternion.identity);
            DestroyOBJ();

            //increase score
            Die();
            if (target.tag == "Bullet")
            {
                Destroy(target.gameObject);
            }
        }
    }
}
