using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private float vel;
    private Vector2 dir;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        vel=3;
        dir= Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
        transform.Translate(dir*vel*Time.deltaTime);

        AtualizaAnimation();
    }

    void Inputs()
    {
        dir=Vector2.zero;
        if(Input.GetKey(KeyCode.UpArrow)){
            dir+=Vector2.up;
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            dir+=Vector2.down;
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            dir+=Vector2.left;
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            dir+=Vector2.right;
        }
    }

    void AtualizaAnimation(){

    }
}
