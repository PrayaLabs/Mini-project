using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class power : MonoBehaviour
{
    public GameObject pipe_up, pipe_down;
    public Material pipe_up_color, pipe_down_color;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        pipe_up.GetComponent<Renderer>().material = pipe_up_color;
        pipe_down.GetComponent<Renderer>().material = pipe_down_color;
        pipe_down.GetComponent<colorDynamic>().enabled = false;
        pipe_up.GetComponent<colorDynamic>().enabled = false;
        pipe_down.GetComponent<colorDynamic>().StopAllCoroutines();
        pipe_up.GetComponent<colorDynamic>().StopAllCoroutines();
      
        gameObject.SetActive(false);
        
    }
}
