using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public Enemy EnemyScript; //y
    public GameObject playerCenter;  //y
    public float range = 5f;  //y
    public float fieldOfView = 45f;
  //private Vector3 eyePosition;
    private float distanceToPlayer;
    private float angleToPlayer;
    private Vector3 targedDirection;
    private RaycastHit whatHasBeenHit;

    private void start()
    {
        EnemyScript = GetComponent<Enemy>();
        if (playerCenter == null)
        {
            playerCenter = GameObject.FindWithTag("Player");
        }
    }


    void Update()
    {
        targedDirection = playerCenter.transform.position - this.transform.position;
       
        angleToPlayer = Vector3.Angle(targedDirection.transform.forward);
       
        distanceToPlayer = Vector3.Distance(playerCenter.transform.position, this.transform.position);
        
        //Debug.DrawRay(this.transform.position, transform.forward * range, color.green, 1, true);
        
        if  (angleToPlayer < fieldOfView && distanceToPlayer < range)
        {
            if (Physics.Raycast(this.transform.position, targetDirection, out whatHasBeenHit, range))
            {
                if (whatHasBeenHit.collider.gameObject.tag == "Player")
                {
                    //Debug.DrawRay(transform.position, targetDirection, Color.red, 1, true);
                   // debug.Log("seen Player");
                    enemyScript.state = 2;
                }
                else
                {
                    enemyScript.state = 1;
                }
            }
        }
    }
}
