using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class booth : MonoBehaviour
{
    [SerializeField]
    private string name;

    //説明会のURL
    [SerializeField]
    private string briefingURL = "https://www.google.com/";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string BriefingURL
    {
        get { return briefingURL; }
        set { briefingURL = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
}
