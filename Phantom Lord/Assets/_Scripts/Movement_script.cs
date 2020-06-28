using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_script : MonoBehaviour
{

    public float speed;
    public float dashMod;
    public float dashCost;
    public GameObject body;
    public Player_Script player;
    public Rigidbody rb;
    public float dashTime;
    public float dashTimeFull;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerRotation();
        Dash();
    }

    public void PlayerMove()
    {
        transform.Translate((transform.right *Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical")) * speed * Time.deltaTime);
    }


    public void PlayerRotation()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); ;
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {

            Vector3 target = hit.point;
            target.y = 0;
            target.y = body.transform.position.y;

            body.transform.LookAt(target);
        }
    }

    public void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && player.CheckST(dashCost))
        {            
            dashTime = dashTimeFull;
            player.stamina -= dashCost;
        }

        if (dashTime > 0)
        {
            rb.velocity = GetDir() * dashMod * speed;
            dashTime -= Time.deltaTime;
        }
        else rb.velocity = Vector3.zero;

    }

    public Vector3 GetDir()
    {
        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0) return transform.forward;
        else return transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
    }
}
