using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelLogic : MonoBehaviour
{
    
    public bool game_end=false;
    public GameObject[] pipe_top, pipe_bottom;
    public ParticleSystem[] effect;
    public string left_collision, right_collision;
    public bool left_collided, right_collided;
    

    

    
    public void level_complete_logic()
    {
        
        //Debug.Log(collision.gameObject.name);
        if (Input.GetMouseButton(0))
        {

            if((left_collided == true && right_collided == true) && (pipe_bottom[0].gameObject.name == right_collision&& pipe_bottom[1].gameObject.name == left_collision))
            {
                
                pipe_top[0].GetComponent<pipe_scale_down_right>().parentCollider = true;
                pipe_top[1].GetComponent<pipe_scale_down_left>().parentCollider = true;
                effect[0].Play();
                effect[1].Play();

                /*---------stop coroutines ----------------*/
                pipe_top[0].GetComponent<colorDynamic>().StopAllCoroutines();
                pipe_top[1].GetComponent<colorDynamic>().StopAllCoroutines();
                pipe_bottom[0].GetComponent<colorDynamic>().StopAllCoroutines();
                pipe_bottom[1].GetComponent<colorDynamic>().StopAllCoroutines();
            }
        }
    }
}
