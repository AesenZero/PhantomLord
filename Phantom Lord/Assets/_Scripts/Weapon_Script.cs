using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Script : MonoBehaviour
{
    public BattleSystem_Script BS;
    public float weapon_dmg;
    public string enemyTag;
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
        if(ot.tag == enemyTag && !ot.isTrigger)
        {
            BattleSystem_Script EnemyBS = ot.GetComponentInParent<BattleSystem_Script>();
            EnemyBS.GetDMG(BS.DealFinalDMG(weapon_dmg));
            EnemyBS.PushAway(BS.DirToUnit(EnemyBS));
        }
    }
}
