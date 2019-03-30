using DragonBones;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public bool Andando;
    private float vel;
    private Vector2 direcao;
    public Animator anim;
    public bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        vel = 3;
        direcao = Vector2.zero;
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
        transform.Translate(direcao * vel * Time.deltaTime);

        if (direcao.x != 0 || direcao.y != 0)
        {
            Animacao(direcao);
        }
        else
        {
            anim.SetLayerWeight(1, 0);
        }
    }

    void Inputs()
    {
        direcao = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            direcao += Vector2.up;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direcao += Vector2.down;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direcao += Vector2.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direcao += Vector2.right;
        }
    }

    void Animacao(Vector2 dir)
    {
        anim.SetLayerWeight(1, 1);

        anim.SetFloat("x", dir.x);        
        anim.SetFloat("y", dir.y);

        Flip(dir.x);
    }

    void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

}
