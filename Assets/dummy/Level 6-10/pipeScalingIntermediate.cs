using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pipeScalingIntermediate : MonoBehaviour
{
    Vector3 lTemp;
    public bool collided, intermediate_pipe_parentCollider = false, scale_status=false;
    public ParticleSystem effect;
    public GameObject pipe_dynamic,pipeScalinglower, button_ui, canvas_prefab;
    string level_status;
    public int tap_count = 0;



    void Start()
    {
        lTemp = transform.localScale;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        // effect.Stop();
        button_ui.GetComponent<Button>().interactable = false;
        level_status = "";
        PlayerPrefs.SetString("level_status", level_status);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name != pipe_dynamic.gameObject.name)
        {
            scale_status = false;
        }

        // if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        if (Input.GetMouseButton(0))
        {
            if (tap_count <= 2)
            {
                ++tap_count;
            }
            if (gameObject.GetComponent<Renderer>().material.color == collision.gameObject.GetComponent<Renderer>().material.color && collision.gameObject.name==pipe_dynamic.gameObject.name)
            {
                //Debug.Log("ParentCollider");
                lTemp.y = pipe_dynamic.transform.position.y;
                intermediate_pipe_parentCollider = true;
                canvas_prefab.SetActive(true);
                button_ui.GetComponent<Button>().interactable = true;
                effect.Play();
                scale_status = true;


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
        if (tap_count <= 2)
        {
            StartCoroutine(Scaleup());
        }
        else
        {
            StopCoroutine(Scaleup());
            lTemp.y = 0.23f;
            transform.localScale = lTemp;
            canvas_prefab.SetActive(true);
        }

        
    
    }

    IEnumerator Scaleup()
    {
        if (!intermediate_pipe_parentCollider && !scale_status)
        {
            if (!collided)
            {
                lTemp.y += 0.01f;
                transform.localScale = lTemp;
            }
            else
            {
                if (lTemp.y >= 0.2f)
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
        yield return null;
    }
}
