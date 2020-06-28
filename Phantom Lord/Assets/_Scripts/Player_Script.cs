using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{

    public float HP;
    public float HPmax;
    public float stamina;
    public float STmax;
    public float STregen;
    float timeChecker = 0;
    // Start is called before the first frame update
    void Start()
    {
        
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

    public void Tick()
    {
        timeChecker += Time.deltaTime;
        if (timeChecker >= 1)
        {
            if(stamina<STmax) stamina += STregen;
            timeChecker = 0;
        }
    }
}
