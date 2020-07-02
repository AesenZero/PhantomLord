using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Script : MonoBehaviour
{
    public BattleSystem_Script BS;
    public float weapon_dmg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider ot)
    {
        if(ot.tag == "Enemy")
        {
            BattleSystem_Script EnemyBS = ot.GetComponent<BattleSystem_Script>();
            EnemyBS.GetDMG(BS.DealFinalDMG(weapon_dmg));
        }
    }
}
