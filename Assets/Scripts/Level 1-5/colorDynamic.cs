using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorDynamic : MonoBehaviour
{
    public Material[] color ;
   public bool coroutine_status;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        if (color.Length != 0) {
            StartCoroutine(color_change());
        }
        coroutine_status = false;
        
        
    }

    // Update is called once per frame
    public IEnumerator color_change()
    {
        coroutine_status = true;
        while (true)
        {
           
            yield return new WaitForSeconds(0.5f);
            i = Random.Range(0, color.Length);
            GetComponent<Renderer>().material = color[i];

        }



    }
}
