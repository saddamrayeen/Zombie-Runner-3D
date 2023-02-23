using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    [SerializeField]
    GameObject explosionFX;
    [SerializeField] int damageAmount;
    public void OnTriggerEnter(Collider target)
    {
        if (target.tag == MyTags.PLAYER_TAG)
        {
            Instantiate(explosionFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            
            target.GetComponent<PlayerHealth>().ApplyDamage(damageAmount);
        }
        else if (target.tag == "Bullet")
        {
            Instantiate(explosionFX, transform.position, Quaternion.identity);
             Destroy(this.gameObject);
             Destroy(target.gameObject);
        }
    }
}
