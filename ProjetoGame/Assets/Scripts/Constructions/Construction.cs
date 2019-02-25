using System.Collections;
using System.Collections.Generic;

class Construction
{
    private int hp;
    private int shield;
    private int defense;
    private bool isDestroyed;

    public Construction(int hp, int shield, int defense)
    {
        this.hp = hp;
        this.shield = shield;
        this.defense = defense;
        this.isDestroyed = false;
    }

    public bool IsDestruido
    {
        get => isDestroyed;
        set
        {
            if( this.hp <= 0 && this.shield <= 0 )
                isDestroyed = value;
        }
    }

    public int HP { get => hp; }
    public int Shield { get => shield;}

    public void ReceiveDamage(int damage)
    {
        damage = (this.defense > 0) ? this.ApplyDefense(damage) : damage;
        damage = (this.shield > 0) ? this.DecreaseShield(damage) : damage;

        if (damage > 0)
        {
            DecreaseHP(damage);
        }

    }

    private int DecreaseShield(int damage)
    {
        if (this.shield > damage)
        {
            this.shield -= damage;
            damage = 0;
        }
        else
        {
            damage -= this.shield;
            this.shield = 0;
        }
        return damage;
    }

    private void DecreaseHP(int damage)
    {
        if (this.hp > damage)
        {
            this.hp -= damage;
        }
        else
        {
            this.hp = 0;
            this.isDestroyed = true;
        }
    }

    private int ApplyDefense(int damage)
    {
        damage = BaseCalculation.DecreasePercentage(damage, this.defense);
        return damage;
    }

}
