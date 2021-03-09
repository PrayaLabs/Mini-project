using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level_logic_1 : MonoBehaviour
{
    public bool game_end = false;
    public GameObject[] pipe_intermediate,pipe_base;
    public ParticleSystem[] effect;
    public string collision_top, collision_bottom;
    public bool collided_top, collided_bottom;





    public void level_complete_logic()
    {

        //Debug.Log(collision.gameObject.name);
        

            if ((collided_top == true && collided_bottom == true) && (pipe_base[0].gameObject.name == collision_top && pipe_base[1].gameObject.name == collision_bottom))
            {

                pipe_intermediate[0].GetComponent<pipe_intermediate_scale_up>().parentCollider = true;
                pipe_intermediate[1].GetComponent<pipe_intermediate_scale_down>().parentCollider = true;
                effect[0].Play();
                effect[1].Play();

                /*---------stop coroutines ----------------*/
                pipe_intermediate[0].GetComponent<colorDynamic>().StopAllCoroutines();
                pipe_intermediate[1].GetComponent<colorDynamic>().StopAllCoroutines();
                pipe_base[0].GetComponent<colorDynamic>().StopAllCoroutines();
                pipe_base[1].GetComponent<colorDynamic>().StopAllCoroutines();
            }
        
    }
}
