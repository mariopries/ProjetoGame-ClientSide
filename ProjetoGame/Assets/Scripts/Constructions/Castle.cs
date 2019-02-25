using System.Collections;
using System.Collections.Generic;

class Castle : Construction
{
    private int qtdSummoners;
    private int atk;
    private int range;

    public Castle(int qtdSummoners, int atk, int range, int hp, int shield, int defense):base(hp, shield, defense)
    {
        this.qtdSummoners = qtdSummoners;
        this.atk = atk;
        this.range = range;
    }

    private void Attack()
    {
        throw new System.NotImplementedException();
    }

    private void Summoners()
    {
        Spawn.Summon();
    }

}
