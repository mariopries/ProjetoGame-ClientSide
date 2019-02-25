using System.Collections;
using System.Collections.Generic;


class BuilderSpawn : Construction
{

    private int cost;
    private int qtdSummoners;

    public BuilderSpawn(int cost, int qtdSummoners, int hp, int shield, int defense) : base(hp, shield, defense)
    {
        this.cost = cost;
        this.qtdSummoners = qtdSummoners;
    }

    private void Summoners()
    {
        Spawn.Summon();
    }


}
