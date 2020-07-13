using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class LineDraw : MonoBehaviour
{
    public GameObject linePrefab;
    public GameObject curentLine;

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;
    public List<Vector2> fingerPositions;
    public string platfType = "platform";
    public GameObject platf;
    private bool goodDraw = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateLine();
        }
        if (Input.GetMouseButton(0))
        {
            Vector2 tempFingerPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z - Camera.main.transform.position.z));
            Debug.Log(platf.name.ToString());
            if(platf.name.ToString() == "platform")
            {
                if(tempFingerPos.x < -1.92f || tempFingerPos.x > 2.2f)
                {
                    goodDraw = false;
                }
            }
            else if (platf.name.ToString() == "platform2")
            {
                if (tempFingerPos.x < -1.92f || tempFingerPos.x > 2.2f)
                {
                    goodDraw = false;
                }
            }
            else if (platf.name.ToString() == "platform3")
            {
                if (tempFingerPos.x < -1.92f || tempFingerPos.x > 2.2f)
                {
                    goodDraw = false;
                }
            }

            if(Vector2.Distance(tempFingerPos, fingerPositions[fingerPositions.Count - 1]) > .1f)
            {
                UpdateLine(tempFingerPos);
            }
        }
        if (platf.GetComponent<Rigidbody>().position.z < 0.30f)
        {
            if (!goodDraw)
            {
                GameOver();
            }
            else
            {
                AddPoints(5);
            }
            Destroy(curentLine);
        }
    }

    void CreateLine()
    {       
            Destroy(curentLine);
            curentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
            lineRenderer = curentLine.GetComponent<LineRenderer>();
            edgeCollider = curentLine.GetComponent<EdgeCollider2D>();
            fingerPositions.Clear();
            fingerPositions.Add(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z - Camera.main.transform.position.z)));
            fingerPositions.Add(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z - Camera.main.transform.position.z)));
            lineRenderer.SetPosition(0, fingerPositions[0]);
            lineRenderer.SetPosition(1, fingerPositions[1]);
            edgeCollider.points = fingerPositions.ToArray();
        
    }
    

    void UpdateLine(Vector2 newFingerPos)
    {
        fingerPositions.Add(newFingerPos);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, newFingerPos);
        edgeCollider.points = fingerPositions.ToArray();
    }

    public void GameOver()
    {

    }

    public void AddPoints(int n)
    {

    }

    public void SetPlatf(GameObject plt)
    {
        platf = plt;
    }
}
