using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimitivesGenerator : MonoBehaviour
{
    [SerializeField] GameObject m_PigPrefab;
    float region1_left_bound = -12f;
    float region1_right_bound = -11f;
    float region1_up_bound = -4.5f;
    float region1_down_bound = 12.5f;

    float region2_left_bound = -11f;
    float region2_right_bound = 7f;
    float region2_up_bound = 10f;
    float region2_down_bound = 13f;

    public static int pignum = 4;

    public void Start()
    {
        GeneratePrimitives(m_PigPrefab, pignum/2);
    }
    void GeneratePrimitives(GameObject primitive, int count)
    {
        for(int i = 0; i < count; i++)
        {
            var primitiveIns = GameObject.Instantiate(primitive);
            primitiveIns.transform.localPosition = new Vector3(
                Random.Range(region1_up_bound, region1_down_bound), 0.1f, Random.Range(region1_left_bound, region1_right_bound));
        }

        for (int i = 0; i < count; i++)
        {
            var primitiveIns = GameObject.Instantiate(primitive);
            primitiveIns.transform.localPosition = new Vector3(
                Random.Range(region2_up_bound, region2_down_bound), 0.1f, Random.Range(region2_left_bound, region2_right_bound));
        }
    }

}
