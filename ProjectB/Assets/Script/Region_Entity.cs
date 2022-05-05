using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Region_Entity : MonoBehaviour
{
    static public int Out_count = 0;

    private void OnTriggerExit(Collider other)
    {
        other.tag = "Untagged";
        PointEntity.point -= 100 / PrimitivesGenerator.pignum;
        Out_count ++;
    }
}
