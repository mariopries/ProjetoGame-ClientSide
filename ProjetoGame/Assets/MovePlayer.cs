using DragonBones;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private float vel;
    private Vector2 dir;
    public Animator anim;
    private UnityArmatureComponent armatureComponent;

    public MovePlayer()
    {
        armatureComponent = GetComponent<UnityArmatureComponent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        vel = 3;
        dir = Vector2.zero;

        armatureComponent = GetComponent<UnityArmatureComponent>();
        armatureComponent.animation.Play("Idle_Frente");

        //UnityFactory.factory.LoadDragonBonesData("Personagem/Personagem_0001_ske");
        //UnityFactory.factory.LoadTextureAtlasData("Personagem/Personagem_0001_tex");

        //var armatureComponent = UnityFactory.factory.BuildArmatureComponent("Personagem");

        armatureComponent.animation.Play("Idle_Frente");
        Debug.Log(armatureComponent);
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
        transform.Translate(dir * vel * Time.deltaTime);
        AtualizaAnimation();
    }

    void Inputs()
    {
        dir = Vector2.zero;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            dir += Vector2.up;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            dir += Vector2.down;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir += Vector2.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            dir += Vector2.right;
        }
    }

    void AtualizaAnimation()
    {
        if (Input.GetKey(KeyCode.UpArrow) && armatureComponent.animation.lastAnimationName != "Andando_Costas")
        {
            armatureComponent.armature.flipX = false;
            armatureComponent.animation.Play("Andando_Costas");
        }
        if (Input.GetKey(KeyCode.DownArrow) && armatureComponent.animation.lastAnimationName != "Andando_Frente")
        {
            armatureComponent.armature.flipX = false;
            armatureComponent.animation.Play("Andando_Frente");
        }
        if (Input.GetKey(KeyCode.LeftArrow) && !armatureComponent.armature.flipX)
        {
            armatureComponent.armature.flipX = true;
            armatureComponent.animation.Play("Andando_Direita");
        }
        if (Input.GetKey(KeyCode.RightArrow) && armatureComponent.armature.flipX)
        {
            armatureComponent.armature.flipX = false;
            armatureComponent.animation.Play("Andando_Direita");           
        }
    }
}
