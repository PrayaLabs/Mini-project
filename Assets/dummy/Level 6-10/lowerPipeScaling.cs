using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lowerPipeScaling : MonoBehaviour
{
    Vector3 lTemp;
    public bool collided, lower_pipe_parentCollider = false;
    public ParticleSystem effect;
    public GameObject pipe_scaling_intermediate, button_ui, canvas_prefab;
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

        // if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        if (Input.GetMouseButton(0))
        {

            if (tap_count <= 2)
            {
                ++tap_count;
            }

            if (gameObject.GetComponent<Renderer>().material.color == collision.gameObject.GetComponent<Renderer>().material.color && collision.gameObject.name == "Pipe-scaling-intermediate")
            {
                //Debug.Log("ParentCollider");
                lTemp.y = pipe_scaling_intermediate.transform.position.y;
                lower_pipe_parentCollider = true;
               
                effect.Play();

                /*------------Remove pipe scaling script----------------*/
                GetComponent<lowerPipeScaling>().enabled = false;
                pipe_scaling_intermediate.GetComponent<pipeScalingIntermediate>().enabled = true;

                /*-------------- Stop Coroutine------------------------*/
                pipe_scaling_intermediate.GetComponent<colorDynamic>().StopAllCoroutines();
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
            lTemp.y = 1.5f;
            transform.localScale = lTemp;
            canvas_prefab.SetActive(true);
        }

       
    }

    IEnumerator Scaleup()
    {

        if (!lower_pipe_parentCollider)
        {
            if (!collided)
            {
                lTemp.y += 0.01f;
                transform.localScale = lTemp;
            }
            else
            {
                if (lTemp.y != 1.5f)
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