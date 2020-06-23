using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public Rigidbody rb;
    //to handle the destroy and sapwn new platform
    bool spawned = false;
    bool destroyed = false;
    public GameObject newPlatformPrefab;
    public Vector3 spawnPos;
    public GameObject[] platforms;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //moving the platform
        rb.MovePosition(rb.position + new Vector3(0, 0, -1) * speed * Time.deltaTime);
        if(rb.position.z < 45 && spawned != true)
        {
            
            Instantiate(platforms[Random.Range(0, 2)], transform.position +  new Vector3(0, 0, 174), new Quaternion(0, 0, 0, 0));
            spawned = true;
        }
        if(rb.position.z < -100 && destroyed != true)
        {
            destroyed = true;
            Destroy(gameObject);
        }
    }
}
