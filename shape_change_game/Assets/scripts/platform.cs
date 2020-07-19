using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public LineDraw drawing;
    public GameObject drawingObject;
    // Start is called before the first frame update
    public float speed;
    public Rigidbody rb;
    //to handle the destroy and sapwn new platform
    bool spawned = false;
    bool destroyed = false;
    public GameObject newPlatformPrefab;
    public Vector3 spawnPos;
    public GameObject[] platforms;
    public GameObject self;
    public bool done = false;
    void Start()
    {
        self = this.gameObject;
        Debug.Log(self.name.ToString());
        drawingObject = GameObject.FindGameObjectWithTag("Line").gameObject;
        Debug.Log(drawingObject.name.ToString());
        drawing = drawingObject.GetComponent<LineDraw>();
    }

    // Update is called once per frame
    void Update()
    {
        //moving the platform
        rb.MovePosition(rb.position + new Vector3(0, 0, -1) * speed * Time.deltaTime);
        if(rb.position.z < 45 && spawned != true)
        {
            
            /*GameObject platf =  */Instantiate(platforms[UnityEngine.Random.Range(0, 2)], transform.position +  new Vector3(0, 0, 174), new Quaternion(0, 0, 0, 0));
            
            spawned = true;
        }
        if(rb.position.z < -100 && destroyed != true)
        {
            destroyed = true;
            Destroy(gameObject);
        }
        if(rb.position.z < 90 && !done)
        {
            /*drawing.platfType = self.name.ToString();
            drawing.platf = self;
            drawing.SetPlatf(self);*/
            drawingObject.GetComponent<LineDraw>().platf = self;
            drawingObject.GetComponent<LineDraw>().SetPlatf(self);
            done = true;
        }
    }
}
