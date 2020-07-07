using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_BS : BattleSystem_Script
{
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        UNIT = GetComponent<Enemy_Script>();  
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public override float DealDMG()
    {
        return UNIT.Damage;
    }

    public override void GetDMG(float dmg)
    {
        UNIT.HP -= (dmg - UNIT.Defense);
    }
}
