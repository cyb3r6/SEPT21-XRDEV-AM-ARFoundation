using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// find the player, rotate towards the player, shoot at player
/// </summary>
public class Cannon : MonoBehaviour
{
    public float turnSpeed = 40f;
    public GameObject cannonBallPrefab;
    public float shootingForce;
    public Transform spawnPoint;

    void OnEnable()
    {
        InvokeRepeating("ShootAtPlayer", 3f, 5f);
    }

    
    void Update()
    {
        if (!RobotPlayer())
        {
            return;
        }
        else
        {
            Vector3 targetDirection = RobotPlayer().transform.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(targetDirection);
            Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
            transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }
    }

    private void ShootAtPlayer()
    {
        if (RobotPlayer())
        {
            GameObject cannonBall = Instantiate(cannonBallPrefab, spawnPoint.position, spawnPoint.rotation);
            cannonBall.GetComponent<Rigidbody>().AddForce(cannonBall.transform.forward * shootingForce);
            Destroy(cannonBall, 2f);
        }
    }

    private GameObject RobotPlayer()
    {
        var robotPlayer = FindObjectOfType<RobotController>();
        if (robotPlayer)
        {
            return robotPlayer.gameObject;
        }
        else
        {
            return default;
        }
    }
}
