using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float angle;
    [SerializeField]
    private float stairsUpSpeed;
    [SerializeField]
    private GameObject camera;
    [SerializeField]
    private float jumpPower;

    private Rigidbody rigidbody;

    private bool openURLFlag = false;

    private bool jumpFlag = false;

    public static string boothName = "株式会社○○";

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0f, 0f, speed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0f, 0f, -speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, -angle, 0));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, angle, 0));
        }

        if(Input.GetKey(KeyCode.W))
        {
            camera.transform.localPosition = new Vector3(-0.2f, 0.61f, 0.09f);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            camera.transform.localPosition = new Vector3(0.0f, 0.72f, -1.53f);
        }


        if(Input.GetKey(KeyCode.Space))
        {
            if (!jumpFlag)
            {
                rigidbody.AddForce(transform.up * jumpPower);
                jumpFlag = true;
            }
                
        }
        
    }


    private void OnTriggerStay(Collider other)
    {
        //階段上る
        if(other.gameObject.tag == "Stairs")
        {
            transform.Translate(0f, 100f, 0f);
        }
        //ブース、相談室に入る
        if (other.gameObject.tag == "ConsultationRoom" && Input.GetKey(KeyCode.Z))
        {
            boothName = other.gameObject.GetComponent<booth>().Name;
            SceneManager.LoadScene(other.gameObject.tag + "Scene");
        }
        else if(other.gameObject.tag == "Booth" && Input.GetKey(KeyCode.Z))
        {
            SceneManager.LoadScene(other.gameObject.tag + "Scene");
        }
        //URLを開く
        if(other.gameObject.tag == "Booth" && Input.GetKeyDown(KeyCode.X) && !openURLFlag)
        {
            Application.OpenURL(other.gameObject.GetComponent<booth>().BriefingURL);
            openURLFlag = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Booth")
        {
            openURLFlag = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        //地面についている
        if(collision.gameObject.tag == "Ground")
        {
            jumpFlag = false;
        }
    }


    public static string GetBoothName()
    {
        return boothName;
    }

}
