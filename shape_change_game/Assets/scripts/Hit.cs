using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public Rigidbody rb;
    //public MeshCollider mc;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(canvas, new Vector3 (0, 0, 0), Quaternion.identity);//add game over to screen
        Time.timeScale = 0f;
    }
}
