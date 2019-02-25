using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgramTeste : MonoBehaviour
{

    Castle castle;
    Tower tower;
    BuilderSpawn bspawn;

    // Start is called before the first frame update
    void Start()
    {
        castle = new Castle(0, 0, 0, 500, 100, 25);
        tower = new Tower(0, 0, 0, 200, 50, 10);
        bspawn = new BuilderSpawn(0, 0, 100, 60, 25);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Teste A");

            castle.ReceiveDamage(100);

            Debug.Log("Vida Castle : "+castle.HP);
            Debug.Log("Escudo Castle : " + castle.Shield);
            Debug.Log("Vida destruido? : " + castle.IsDestruido);


            tower.ReceiveDamage(100);

            Debug.Log("Vida Castle : " + tower.HP);
            Debug.Log("Escudo Castle : " + tower.Shield);
            Debug.Log("Vida destruido? : " + tower.IsDestruido);




        }
        
    }
}
