using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    public GameObject[] Corazones;
    private int vida;

    private float checkPointPositionX, checkPointPositiony;

    public Animator animator;

    private void Start()
    {

        vida = Corazones.Length;
         
        if (PlayerPrefs.GetFloat("checkPointPositionX") != 0)
        {
            transform.position=(new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("checkPointPositionY")));
        }
        
    }

    private void CheckLife()
    {

        if (vida < 1)
        {
            Destroy(Corazones[0].gameObject);
            animator.Play("hit");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
        else if (vida < 2)
        {
            Destroy(Corazones[1].gameObject);
            animator.Play("hit");
        }
        else if (vida < 3)
        {
            Destroy(Corazones[2].gameObject);
            animator.Play("hit");
        }

    }

    private void Debug(string v)
    {
        throw new NotImplementedException();
    }

    public void reachedCheckPoint(float x, float y)
    {
        PlayerPrefs.SetFloat("checkPointPositionX",x);
        PlayerPrefs.SetFloat("checkPointPositionY", y);
    }

    public void PlayerDamage()
    {
        vida--;
        CheckLife();

        



    }
}
