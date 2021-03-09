using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottomScaleUp : MonoBehaviour
{
    Vector3 lTemp;
    
    public bool collided, parentCollider = false;
    public ParticleSystem effect;
    public GameObject pipe_dynamic;
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

        // if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        if (Input.GetMouseButton(0))
        {
            if (gameObject.GetComponent<Renderer>().material.color == collision.gameObject.GetComponent<Renderer>().material.color && collision.gameObject.name == pipe_dynamic.gameObject.name)
            {
                //Debug.Log("ParentCollider");
                lTemp.y = pipe_dynamic.transform.position.y;
                parentCollider = true;
                effect.Play();



                /*-------------- Stop Coroutine------------------------*/
                pipe_dynamic.GetComponent<colorDynamic>().StopAllCoroutines();
                GetComponent<colorDynamic>().StopAllCoroutines();



            }

            else { collided = true; }

        }
        else
        {
            collided = true;
        }
    }


    void Update()
    {
        if (!parentCollider)
        {
            if (!collided)
            {
                lTemp.y += 0.01f;
                transform.localScale = lTemp;
            }
            else
            {
                if (lTemp.y > 0.2f)
                {
                    lTemp.y -= 0.01f;
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