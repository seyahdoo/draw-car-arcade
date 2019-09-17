using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDrawer : MonoBehaviour
{

    public GameObject prefab;

    public void DrawCube(Vector3 pos1, Vector3 pos2, float thiccnes, Vector3 up)
    {
        GameObject go = Instantiate(prefab);

        go.transform.position = pos1;
        go.transform.localScale = new Vector3(thiccnes, thiccnes, Vector3.Distance(pos1, pos2));
        go.transform.LookAt(pos2, up);

    }



}
