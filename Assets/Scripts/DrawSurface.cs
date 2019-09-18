using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using seyahdoo.pooling.v3;

public class DrawSurface : MonoBehaviour
{

    public GameSettings gameSettings;

    public Camera cam;
    public LayerMask mask;
    private readonly RaycastHit[] hits = new RaycastHit[1];

    public float cubeDistance = .1f;
    public Vector3 drawStart;




    private void Awake()
    {
        Pool.CreatePool<Wheel>(null, 4, 10);
        Pool.CreatePool<Cube>(null, 20, 1000);
    }

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Physics.RaycastNonAlloc(ray, hits, 100f, mask);

        if (Input.GetMouseButtonDown(0))
        {
            //Start Drawing Car
            Wheel w = Pool.Get<Wheel>();
            w.transform.position = hits[0].point;
            w.transform.localScale = Vector3.one * gameSettings.wheelRadius;
            drawStart = hits[0].point;
        }
        else if (Input.GetMouseButton(0))
        {
            //Draw Intermediate Parts
            if(Vector3.Distance(drawStart, hits[0].point) > cubeDistance)
            {
                DrawCube(drawStart, hits[0].point, .1f, Vector3.up);
                drawStart = hits[0].point;
            }

        }
        else if (Input.GetMouseButtonUp(0))
        {
            //End Drawing Car
            Wheel w = Pool.Get<Wheel>();
            w.transform.position = hits[0].point;
            w.transform.localScale = Vector3.one * gameSettings.wheelRadius;

            DrawCube(drawStart, hits[0].point, .1f, Vector3.up);

            //TODO put car to the track

            
            
        }



    }

    public void DrawCube(Vector3 pos1, Vector3 pos2, float thiccnes, Vector3 up)
    {
        GameObject go = Pool.Get<Cube>().gameObject;

        go.transform.position = pos1;
        go.transform.localScale = new Vector3(thiccnes, thiccnes, Vector3.Distance(pos1, pos2));
        go.transform.LookAt(pos2, up);

    }


}
