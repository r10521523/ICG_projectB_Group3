using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jailEntity : MonoBehaviour
{
    // Start is called before the first frame update
    public static jailEntity Instance;
    public static int Jail_count = 0;

    public void OnTriggerEnter(Collider other)
    {
        if (UIEntity.IsPlaying)
        {
            Jail_count++;
            //Debug.Log("Jail " + Jail_count);
            if (Jail_count >= PrimitivesGenerator.pignum)
            {
                UIEntity.Instance.GameComplete();
            }
        }
    }

}
   

