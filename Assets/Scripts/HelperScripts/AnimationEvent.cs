using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    PlayerController playerController;
    Animator sliderAnim;

   void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag(MyTags.PLAYER_TAG).GetComponent<PlayerController>();
        sliderAnim = GetComponent<Animator>();

    }

    public void ResetAnimationAndShoot()
    {
       
        playerController.canShoot = true;
         sliderAnim.Play("Idle");
    }
}
