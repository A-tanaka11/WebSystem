using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBoothCol : MonoBehaviour
{
    [SerializeField]
    private GameObject message;


    // Start is called before the first frame update
    void Start()
    {
        //message = GameObject.FindGameObjectWithTag("GoBooth_Message");
        //message.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            message.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            message.SetActive(false);
        }
    }

}
