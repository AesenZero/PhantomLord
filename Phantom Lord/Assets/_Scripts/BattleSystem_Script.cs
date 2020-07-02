using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem_Script : MonoBehaviour
{
    public Unit_Script UNIT;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual float DealFinalDMG(float mod)
    {
        return mod;
    }

    public virtual void GetDMG(float dmg)
    {

    }

    public virtual float DealDMG()
    {
        return 0;
    }
}
