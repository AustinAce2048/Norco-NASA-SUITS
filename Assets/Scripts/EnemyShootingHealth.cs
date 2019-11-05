using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyShootingHealth : MonoBehaviour {

    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth = 0;

    [SerializeField] private int roundsPerMinute = 0;
    public GameObject firePoint;
    private bool fireRateCooldown = false;

    [SerializeField] private float fieldOfViewAngle = 110f;
    [SerializeField] private float firingAngle = 5f;
    public bool playerInSight;
    [SerializeField] private Vector3 lastSighting;
    [SerializeField] private GameObject player;
    private bool lastSightingRunOnce = false;
    public GameObject laserBolt;
    private Vector3 spawnPosition;

    void Start () {
        //Set enemy health
        currentHealth = maxHealth;

        //Set shooting values
        roundsPerMinute = 200;
        player = GameObject.Find ("Player");
        spawnPosition = transform.position;
    }

    void Update () {
        //Enemy vision
        Vector3 playerDirection = player.transform.position - transform.position;
        float angle = Vector3.Angle (playerDirection, transform.forward);
        if (angle <= fieldOfViewAngle) {
            RaycastHit hit;
            if (Physics.Raycast (transform.position, playerDirection, out hit, 100f)) {
                if (hit.collider.gameObject == player) {
                    playerInSight = true;
                    lastSightingRunOnce = true;
                } else {
                    if (lastSightingRunOnce) {
                        playerInSight = false;
                        lastSighting = player.transform.position;
                        lastSightingRunOnce = false;
                    }
                }
            }
            if (angle <= firingAngle && !fireRateCooldown) {
                Shoot ();
            }
        }

        if (playerInSight) {
            GetComponent<AIPath> ().destination = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);
            transform.LookAt (player.transform);
        } else {
            GetComponent<AIPath> ().destination = spawnPosition;
        }
    }

    void Shoot () {
        fireRateCooldown = true;
        Instantiate (laserBolt, firePoint.transform.position, firePoint.transform.rotation);
        StartCoroutine (fireRateWait ());
    }

    IEnumerator fireRateWait () {
        yield return new WaitForSeconds (60f / roundsPerMinute);
        fireRateCooldown = false;
    }

    public void TakeDamage (int hurtPoints) {
        if (currentHealth - hurtPoints <= 0) {
            //Die
            Destroy (this.gameObject);
        } else {
            //Take damage
            currentHealth -= hurtPoints;
        }
    }

}