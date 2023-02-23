using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    [SerializeField] float timer;
    // Start is called before the first frame update
    void Start()
    {
     Destroy(this.gameObject,timer);   
    }
}
