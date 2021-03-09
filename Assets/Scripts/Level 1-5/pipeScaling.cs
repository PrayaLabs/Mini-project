using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class pipeScaling : MonoBehaviour
{
    Vector3 lTemp;
    public bool collided,parentCollider = false;
    public ParticleSystem effect;
    public Text level_status_text;
    public GameObject pipe_dynamic, button_ui, canvas_prefab, power_prefab;
    string level_status;
   
    public int tap_count=0;
    
    
    


    void Start() {
        lTemp = transform.localScale;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        button_ui.GetComponent<Button>().interactable = false;
        level_status = "";
        
    }

    private void OnCollisionEnter(Collision collision)
    {

       // if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
       if(Input.GetMouseButton(0))
        {
            if (tap_count <=2)
            {
                ++tap_count;
            }
          

            if(gameObject.GetComponent<Renderer>().material.color == collision.gameObject.GetComponent<Renderer>().material.color)
            {
                //Debug.Log("ParentCollider");
                lTemp.y = pipe_dynamic.transform.position.y;
                parentCollider = true;
                canvas_prefab.SetActive(true);
                level_status_text.text = "LEVEL COMPLETED";
                button_ui.GetComponent<Button>().interactable = true;
                effect.Play();

                /*-------------- Stop Coroutine------------------------*/
               pipe_dynamic.GetComponent<colorDynamic>().StopAllCoroutines();

                GetComponent<colorDynamic>().StopAllCoroutines();



            }

            else {
                collided = true;
            }
           
        }
        else
        {
            collided = true;
        }
    }
        

    void Update()
    {
        if(tap_count == 1 && lTemp.y<1.8f)
        {
            if (pipe_dynamic.gameObject.GetComponent<Renderer>().material.color != gameObject.GetComponent<Renderer>().material.color)
            {
             
                power_prefab.SetActive(true);
            }
            else
            {
                power_prefab.SetActive(false);
               
            }
            
        }
        if (tap_count <= 2)
        {
            StartCoroutine(Scaleup());
        }
        else
        {
            StopCoroutine(Scaleup());
            lTemp.y = 1.5f;
            transform.localScale = lTemp;
            level_status_text.text = "TRY AGAIN";
            canvas_prefab.SetActive( true);
        }
    }

    IEnumerator Scaleup()
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
