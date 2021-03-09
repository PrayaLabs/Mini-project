using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe_intermediate_scale_down : MonoBehaviour
{
    Vector3 lTemp;
    public bool collided, parentCollider = false;
    public GameObject level_logic;
    string level_status;



    void Start()
    {
        lTemp = transform.localScale;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        // effect.Stop();
        level_status = "";
        PlayerPrefs.SetString("level_status", level_status);
    }

    private void OnCollisionEnter(Collision collision)
    {
        collided = true;
        if (Input.GetMouseButton(0))
        {
            if (gameObject.GetComponent<Renderer>().material.color == collision.gameObject.GetComponent<Renderer>().material.color)
            {
                level_logic.GetComponent<level_logic_1>().collided_bottom = true;
                level_logic.GetComponent<level_logic_1>().collision_bottom = collision.gameObject.name;
                level_logic.GetComponent<level_logic_1>().level_complete_logic();
            }
        }

    }
    private void OnCollisionExit(Collision collision)
    {

        level_logic.GetComponent<level_logic_1>().collided_bottom = false;
        level_logic.GetComponent<level_logic_1>().collision_bottom = "";
    }


    void Update()
    {
        if (!parentCollider)
        {
            if (!collided)
            {
                lTemp.y -= 0.01f;
                transform.localScale = lTemp;
            }
            else
            {
                if (lTemp.y < -0.2f)
                {
                    lTemp.y += 0.01f;
                    transform.localScale = lTemp;
                }
                else
                {
                    collided = false;

                }
            }
        }
    }
}