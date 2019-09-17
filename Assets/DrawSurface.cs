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

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.RaycastNonAlloc(ray, hits, 100f, mask) > 0)
            {
                Debug.Log("dasd");

                GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                go.transform.localScale = Vector3.one * .2f;
                go.transform.position = hits[0].point;

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



        }

        

    }



}
