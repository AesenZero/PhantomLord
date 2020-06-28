using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Script : MonoBehaviour
{
    public Player_Script PL;
    public Scrollbar HP_Bar;
    public Scrollbar Stamina_Bar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HP_Bar.size = PL.HP / PL.HPmax;
        Stamina_Bar.size = PL.stamina / PL.STmax;
    }
}
