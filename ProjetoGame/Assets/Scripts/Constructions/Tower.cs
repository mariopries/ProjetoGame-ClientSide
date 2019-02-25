using System.Collections;
using System.Collections.Generic;

class Tower : Construction
{
    private int cost;
    private int range;
    private int atk;
    

    public Tower(int cost, int range, int atk, int hp, int shield, int defense) : base(hp, shield, defense)
    {
        this.cost = cost;
        this.range = range;
        this.atk = atk;
        
    }

    private void Attack() {
        throw new System.NotImplementedException();
    }

}
