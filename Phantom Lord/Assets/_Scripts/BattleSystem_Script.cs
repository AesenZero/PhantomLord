using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem_Script : MonoBehaviour
{
    public Unit_Script UNIT;

    public float pushTime;
    public float pushTimeFull;
    public Vector3 pushDir;
    public Rigidbody RB;
    public float pushForce;
    public float pushMod = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        PushingAway();
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

    public virtual void PushAway(Vector3 pD)
    {
        pushTime = pushTimeFull;
        pushDir = pD;
    }

    protected virtual void PushingAway()
    {
        if (pushTime > 0)
        {
            pushTime -= Time.deltaTime;
            RB.velocity = pushDir * pushForce * Time.deltaTime *pushMod;
            
        }
        else RB.velocity = Vector3.zero;
    }

    public virtual Vector3 DirToUnit(BattleSystem_Script Ot)
    {
        Vector3 temp = Ot.transform.position - transform.position;
        temp.y = 0;
        return temp.normalized;
    }
}
