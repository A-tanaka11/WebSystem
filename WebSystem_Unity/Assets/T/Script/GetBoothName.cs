using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBoothName : MonoBehaviour
{
    private string name;
    // Start is called before the first frame update
    void Start()
    {
        name = Player.GetBoothName();
        Debug.Log(name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
