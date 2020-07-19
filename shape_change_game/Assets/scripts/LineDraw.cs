using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class LineDraw : MonoBehaviour
{
    public GameObject linePrefab;
    public GameObject curentLine;

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;
    //public PolygonCollider2D poly_collider;
    public List<Vector2> fingerPositions;
    public string platfType = "platform";
    public GameObject platf;
    private bool goodDraw = true;
    Mesh linie;
    public List<Vector3> verts;
    public List<int> triangles;
    public MeshCollider colli;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.AddComponent<MeshFilter>();
        this.gameObject.AddComponent<MeshRenderer>();
        linie = GetComponent<MeshFilter>().mesh;
        this.gameObject.AddComponent<MeshCollider>();
        colli = GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(curentLine);
            CreateLine();
        }
        if (Input.GetMouseButton(0))
        {
            Vector2 tempFingerPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z - Camera.main.transform.position.z));
            Debug.Log(platf.name.ToString());

            if(Vector2.Distance(tempFingerPos, fingerPositions[fingerPositions.Count - 1]) > 0.1f)
            {
                UpdateLine(tempFingerPos);
            }
        }
    }

    void CreateLine()
    {
            linie.Clear();
            verts.Clear();
            triangles.Clear();

            curentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);

            lineRenderer = curentLine.GetComponent<LineRenderer>();

        //edgeCollider = curentLine.GetComponent<EdgeCollider2D>();
            //poly_collider = curentLine.GetComponent<PolygonCollider2D>();

            fingerPositions.Clear();

            fingerPositions.Add(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z - Camera.main.transform.position.z)));

            verts.Add(new Vector3 (Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z - Camera.main.transform.position.z)).x, 
                      Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z - Camera.main.transform.position.z)).y, 
                      transform.position.z - Camera.main.transform.position.z));
            triangles.Add(0);

            fingerPositions.Add(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z - Camera.main.transform.position.z)));
            verts.Add(new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z - Camera.main.transform.position.z)).x,
                     Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z - Camera.main.transform.position.z)).y,
                     transform.position.z - Camera.main.transform.position.z));
            triangles.Add(1);
            lineRenderer.SetPosition(0, fingerPositions[0]);
            lineRenderer.SetPosition(1, fingerPositions[1]);
            linie.vertices = verts.ToArray();
            //edgeCollider.points = fingerPositions.ToArray();
            //poly_collider.points = fingerPositions.ToArray();
        
    }
    

    void UpdateLine(Vector2 newFingerPos)
    {
        fingerPositions.Add(newFingerPos);
        verts.Add(new Vector3(newFingerPos.x, newFingerPos.y, transform.position.z - Camera.main.transform.position.z));
        linie.vertices = verts.ToArray();
        triangles.Add(linie.vertices.Length - 1);
        linie.triangles = triangles.ToArray();

        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, newFingerPos);
        //edgeCollider.points = fingerPositions.ToArray();
        //poly_collider.points = fingerPositions.ToArray();
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
