using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotarnave : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frames
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            anim.Play("enemy-animation");
            //anim.SetBool("mover", true);
        }
        else
        {
            anim.SetBool("mover", false);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.Play("enemy-animation");
        }
        else
        {
            anim.SetBool("mover", false);
        }


    }
}

