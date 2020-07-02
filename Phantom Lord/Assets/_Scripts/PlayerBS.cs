using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class PlayerBS : BattleSystem_Script
{
    public Weapon_Script weapon;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        UNIT = GetComponent<Player_Script>();
        weapon.BS = GetComponent<PlayerBS>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        tempSwing();
    }

    public override float DealFinalDMG(float mod)
    {
        return DealDMG() + mod;
    }

    public override float DealDMG()
    {
        return UNIT.Damage;
    }

    // DMG < DEFENSE
    public override void GetDMG(float dmg)
    {
        UNIT.HP -= (dmg - UNIT.Defense);
    }


    public void tempSwing()
    {

        if (Input.GetKey(KeyCode.Mouse0)) anim.SetBool("Attack_Pressed", true);
        else anim.SetBool("Attack_Pressed", false);
    }
}
