using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class Player_Script : Unit_Script
{

    public float stamina;
    public float STmax;
    public float STregen;
    float timeChecker = 0;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Tick();
    
    }

    public bool CheckST(float t)
    {
        return stamina >= t;
    }

    protected override void Tick()
    {
        timeChecker += Time.deltaTime;
        if (timeChecker >= 1)
        {
            if(stamina<STmax) stamina += STregen;
            timeChecker = 0;
        }
    }

    
}
