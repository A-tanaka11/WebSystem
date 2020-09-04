using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if(message.active == true && Input.GetKey(KeyCode.Z))
        {
            SceneManager.LoadScene("BoothScene");
        }
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
