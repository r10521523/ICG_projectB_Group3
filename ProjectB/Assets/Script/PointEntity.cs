using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PointEntity : MonoBehaviour
{
    static public int point = 100;
    public Text ScoreText;
    [SerializeField] GameObject m_Region;

    int Total_count = PrimitivesGenerator.pignum;
    int Arrive_count;
    int Jail_count;
    int Out_count;

    // Update is called once per frame
    void Update()
    {
        Arrive_count = WalkingPath.Arrive_count;
        Jail_count = jailEntity.Jail_count;
        Out_count = Region_Entity.Out_count;

        if (Total_count == Arrive_count + Jail_count + Out_count)
        {
            if(Jail_count >= 1)
            {
                UIEntity.Instance.GameComplete();
            }
        }

       if(point == 0)
            UIEntity.Instance.GameOver();

        ScoreText.text = "Score: " + point;
    }

}
