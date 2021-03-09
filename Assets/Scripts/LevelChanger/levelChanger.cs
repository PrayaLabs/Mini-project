using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelChanger : MonoBehaviour
{
    public GameObject[] pipe;
    public bool[] collide_status;
    string level_name;
    int level_no;
    
    // Start is called before the first frame update
    void Start()
    {
        level_name = SceneManager.GetActiveScene().name;
        level_no = int.Parse(level_name[level_name.Length - 1].ToString());
        
    }

    void menu_active()
    {

    }

    public void next_Scene()
    {
        if (level_no >= 1 && level_no <= 5)
        {
            if (pipe[0].GetComponent<pipeScaling>().parentCollider == true)
            {
                level_no++;
                SceneManager.LoadScene("Level5" );
            }
        }
        else if(level_no >=6 && level_no <= 10)
        {
            Debug.Log(level_no);
            if (pipe[0].GetComponent<lowerPipeScaling>().lower_pipe_parentCollider == true && pipe[1].GetComponent<pipeScalingIntermediate>().intermediate_pipe_parentCollider == true)
            {
                level_no++;
                SceneManager.LoadScene("Level" + level_no.ToString());
            }
        }
    }

    public void home_Scene()
    {

    }

    public void restart_scene()
    {
        SceneManager.LoadScene(level_name);
    }
  
}
