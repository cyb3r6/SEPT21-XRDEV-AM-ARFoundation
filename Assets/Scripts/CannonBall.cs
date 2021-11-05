using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        var robotController = collision.collider.GetComponent<RobotController>();

        if (robotController)
        {
            Destroy(collision.gameObject);
            GameManager.instance.LoseLives();
        }
    }
}
