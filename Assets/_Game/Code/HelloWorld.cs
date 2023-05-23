using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework;

public class HelloWorld : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    { 
        var t = GameFramework.Utility.Random.GetRandom();
        Debug.Log(t);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
