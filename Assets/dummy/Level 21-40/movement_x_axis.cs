using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement_x_axis : MonoBehaviour
{
    public GameObject _right, _left;
    public GameObject[] pipe;
    private Vector3 right_position,left_position;
    // Start is called before the first frame update
    void Start()
    {
       
        right_position = _right.transform.localPosition;
        left_position = _left.transform.localPosition;
        StartCoroutine(position_change());

        
    }

    IEnumerator position_change()
    {
        
        while (true) {
            
            yield return new WaitForSeconds(2.0f);
             _left.transform.localPosition = right_position;
            _right.transform.localPosition = left_position;
            right_position = _right.transform.localPosition;
            left_position = _left.transform.localPosition;
        }

       

        }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level71")
        {
            if (pipe[0].GetComponent<pipe_scale_down_right>().parentCollider && pipe[1].GetComponent<pipe_scale_down_left>().parentCollider)
            {
                StopAllCoroutines();
            }
        }

        else if(SceneManager.GetActiveScene().name == "Level31")
        {
            if (pipe[0].GetComponent<TopScaleDown>().parentCollider && pipe[1].GetComponent<bottomScaleUp>().parentCollider)
            {
                StopAllCoroutines();
            }
        }
    }


}
