using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class ChangeMaterial : MonoBehaviour
{
    public VideoPlayer moves;

    public Material Test;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //動画を停止
        if (Input.GetKey(KeyCode.N))
        {
            moves.enabled = false;
            GetComponent<Renderer>().material.mainTexture = Test.mainTexture;
        }
    }
}
