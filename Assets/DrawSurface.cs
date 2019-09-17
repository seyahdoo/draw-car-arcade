using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawSurface : MonoBehaviour
{

    Vector3 pos;
    bool recorded = false;

    public Camera cam;
    public LayerMask mask;
    readonly RaycastHit[] hits = new RaycastHit[1];

    public CubeDrawer drawer;

    public float cubeDistance = .1f;
    public Vector3 drawStart;


    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Physics.RaycastNonAlloc(ray, hits, 100f, mask);

        if (Input.GetMouseButtonDown(0))
        {
            //Start Drawing Car


        }
        else if (Input.GetMouseButton(0))
        {
            //Draw Intermediate Parts
            if (!recorded)
            {
                recorded = true;
                pos = hits[0].point;    
            }
            else
            {
                recorded = false;
                drawer.DrawCube(pos, hits[0].point, .1f, Vector3.up);
            }
            

        }
        else if (Input.GetMouseButtonUp(0))
        {
            //End Drawing Car
            


        }



    }



}
