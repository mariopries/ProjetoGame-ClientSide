using DragonBones;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public bool Andando;
    private float vel;
    private Vector2 dir;
    public Animator anim;
    private UnityArmatureComponent armatureComponent;
    private int _moveDir;
    private int _IdleDir;

    // Start is called before the first frame update
    void Start()
    {
        vel = 3;
        dir = Vector2.zero;
        armatureComponent = GetComponent<UnityArmatureComponent>();
        armatureComponent.animation.Play("Idle_Frente");
        Debug.Log(armatureComponent);
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
        transform.Translate(dir * vel * Time.deltaTime);
    }

    void Inputs()
    {
        dir = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            dir += Vector2.up;
            this.Move(1);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            dir += Vector2.down;
            this.Move(2);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir += Vector2.left;
            this.Move(3);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            dir += Vector2.right;
            this.Move(4);
        }

        else
        {
            this.Move(5);
        }

    }

    public void Move(int direcao)
    {
        if (_moveDir == direcao)
        {
            return;
        }
        switch (direcao)
        {
            case 5:
                this._IdleDir = _moveDir;
                this.ChangeAnimationIdle();
                break;
            default:
                this._moveDir = direcao;
                this.ChangeAnimation();
                break;
        }
        
    }

    public void ChangeAnimationIdle()
    {
        if (_IdleDir == 1)
        {
            armatureComponent.armature.flipX = false;
            armatureComponent.animation.FadeIn("Idle_Frente");
        }
        if (_IdleDir == 2)
        {
            armatureComponent.armature.flipX = false;
            armatureComponent.animation.FadeIn("Idle_Frente");
        }
        if (_IdleDir == 3)
        {
            armatureComponent.armature.flipX = true;
            armatureComponent.animation.FadeIn("Idle_Lado");
        }
        if (_IdleDir == 4)
        {
            armatureComponent.armature.flipX = false;
            armatureComponent.animation.FadeIn("Idle_Lado");
        }
    }

    public void ChangeAnimation()
    {
        if (_moveDir == 1)
        {
            armatureComponent.armature.flipX = false;
            armatureComponent.animation.FadeIn("Andando_Costas");
        }
        if (_moveDir == 2)
        {
            armatureComponent.armature.flipX = false;
            armatureComponent.animation.FadeIn("Andando_Frente");
        }
        if (_moveDir == 3)
        {
            armatureComponent.armature.flipX = true;
            armatureComponent.animation.FadeIn("Andando_Direita");
        }
        if (_moveDir == 4)
        {
            armatureComponent.armature.flipX = false;
            armatureComponent.animation.FadeIn("Andando_Direita");
        }
    }
}
