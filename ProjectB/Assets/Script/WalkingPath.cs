using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingPath : MonoBehaviour
{
    Vector3 Destination_location = new Vector3(-11.4f, 0f, 11.7f);
    float MoveSpeed = 0.001f;
    //float MoveSpeed = 0f;
    private float FirstSpeed;
    public static int Arrive_count = 0;

    const float ROTATION_VELOCITY = 90f;

    // Start is called before the first frame update
    void Start()
    {
        FirstSpeed = Vector3.Distance(this.transform.position, Destination_location) * MoveSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (UIEntity.IsPlaying)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, Destination_location, MoveSpeed);
            MoveSpeed = CalculateNewSpeed();

            Vector3 diffVec = Destination_location - this.transform.position;

            if (diffVec == Vector3.zero)
            {
                Destroy(this.gameObject);
                PointEntity.point -= 100/ PrimitivesGenerator.pignum;
                Arrive_count ++;              
            }

            var PigQuaternion =
                Quaternion.FromToRotation(
                    Vector3.forward,
                    new Vector3(diffVec.x, 0f, diffVec.z));

            this.transform.localRotation = Quaternion.RotateTowards(
                this.transform.localRotation,
                PigQuaternion,
                ROTATION_VELOCITY * Time.deltaTime);
        }

        float CalculateNewSpeed()
        {
            float temp = Vector3.Distance(this.transform.position, Destination_location);

            if (temp == 0)
                return temp;
            else
                return (FirstSpeed / temp);
        }
    }
        
}
