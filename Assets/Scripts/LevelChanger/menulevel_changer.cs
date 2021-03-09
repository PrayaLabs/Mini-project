using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menulevel_changer : MonoBehaviour
{
    public void change_scene()
    {
        SceneManager.LoadScene("Level5");
    }
}
