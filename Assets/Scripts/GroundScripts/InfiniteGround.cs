using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteGround : MonoBehaviour
{
    private float

            halfGroundDistance = 100f,
            endOffset = 10f;

    [SerializeField]
    GameObject otherGround;

    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag(MyTags.PLAYER_TAG).transform;
    }

    // Update is called once per frame
    void Update()
    {
        MoveGround();
    
    
    }//update

    private void MoveGround()
    {
        if (
            transform.position.z + halfGroundDistance <
            player.position.z - endOffset
        )
        {
            transform.position =
                new Vector3(otherGround.transform.position.x,
                    otherGround.transform.position.y,
                    otherGround.transform.position.z +
                    (halfGroundDistance * 2));
        }//if statement


    } //move ground



} //class
