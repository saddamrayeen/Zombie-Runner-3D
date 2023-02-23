using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmoothFollow : MonoBehaviour
{
    public Transform player;

    public float distance = 3.6f;

    public float height = 3.5f;

    public float height_Damping = 3.25f;

    public float rotation_Damping = 0.27f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(MyTags.PLAYER_TAG).transform;
    }

    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        //player

        float wantedRotationAngle = player.eulerAngles.y;
        float wantedHeight = player.position.y + height;

        //camera
        float currentRotationAngle = transform.eulerAngles.y;
        float currentheight = transform.position.y;

        currentRotationAngle =
            Mathf
                .LerpAngle(currentRotationAngle,
                wantedRotationAngle,
                rotation_Damping * Time.deltaTime);

        currentheight =
            Mathf
                .Lerp(currentheight,
                wantedHeight,
                height_Damping * Time.deltaTime);

        Quaternion currentRotation = Quaternion.Euler(0f, currentRotationAngle, 0f);
        transform.position = player.position;
        transform.position -= currentRotation * Vector3.forward * distance;

        transform.position = new Vector3(transform.position.x, currentheight, transform.position.z);
    }
}
