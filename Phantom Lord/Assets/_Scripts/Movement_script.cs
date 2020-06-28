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
        MoveHorizontal();
        MoveVertical();
        PlayerRotation();
        Dash();
    }

    public void MoveHorizontal()
    {
        transform.Translate(transform.right *Input.GetAxis("Horizontal") * speed * Time.deltaTime);
    }

    public void MoveVertical()
    {

        transform.Translate(transform.forward*Input.GetAxis("Vertical") * speed * Time.deltaTime);
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
            
            /*transform.Translate(dir * dashMod * speed * Time.deltaTime);
            transform.Translate(dir * dashMod * speed/2 * Time.deltaTime);
            transform.Translate(dir * dashMod * speed/4 * Time.deltaTime);*/
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
        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0) return body.transform.forward;
        else return body.transform.forward * Input.GetAxis("Vertical") + body.transform.right * Input.GetAxis("Horizontal");
    }
}
