using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effects_stop : MonoBehaviour
{
    public ParticleSystem[] effects;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < effects.Length; i++)
        {
            effects[i].Stop();
        }
    }

   
}
