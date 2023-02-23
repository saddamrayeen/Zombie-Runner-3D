using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    Animator anim;
    void Awake()
    {
anim = Camera.main.GetComponent<Animator>();
    }
   public void PlayGame()
{
anim.Play("Camera");
}
public void LoadMainScene()
{
SceneManager.LoadScene("GamePlay");
}
}
