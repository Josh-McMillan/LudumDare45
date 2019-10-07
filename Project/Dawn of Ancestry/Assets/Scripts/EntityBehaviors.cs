using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBehaviors : MonoBehaviour
{
    public static Vector2 Seek(Transform entity, Vector2 target, ref Vector2 velocity, float stoppingRadius, float maxspeed, float maxforce)
    {
        Vector2 currentPosition = new Vector2(entity.position.x, entity.position.y);

        Vector2 desired = target - currentPosition;

        desired.Normalize();
        /*
                if (Vector2.Distance(currentPosition, desired) < stoppingRadius)
                {
                    float speed = Map(maxspeed, 0.0f, stoppingRadius, 0.0f, maxspeed);
                    desired *= speed;
                }
                else
                {
                }
         */
        desired *= maxspeed;

        Vector2 steering = desired - velocity;

        steering = Vector2.ClampMagnitude(steering, maxforce);

        velocity = steering;

        return steering;
    }

    public static float Map(float value, float fromMin, float fromMax, float toMin, float toMax)
    {
        return (value - fromMin) / (toMin - fromMin) * (toMax - fromMax) + fromMax;
    }
}
