using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb2d;
    public SpriteRenderer sprRdr;
    public Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis ("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis ("Vertical");

        if(Mathf.Abs(moveHorizontal)> 0 || Mathf.Abs(moveVertical)>0){
            if(Mathf.Abs(moveHorizontal)> Mathf.Abs(moveVertical)){
                //sprites horizontal
                if(moveHorizontal<0){
                    
                    sprRdr.sprite =sprites[System.Array.FindIndex(sprites, s => s.name == "player_8")];
                }
                else{
                    sprRdr.sprite =sprites[System.Array.FindIndex(sprites, s => s.name == "player_13")];
                }
            }
            else{
                //sprites vertical
                if(moveVertical<0){
                    
                    sprRdr.sprite =sprites[System.Array.FindIndex(sprites, s => s.name == "player_0")];
                }
                else{
                    sprRdr.sprite =sprites[System.Array.FindIndex(sprites, s => s.name == "player_4")];
                }
            }
        }
        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        transform.position+= new Vector3(moveHorizontal * speed, moveVertical * speed,0);
    }
}