using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject player;
    int enemyHealth = 10;
    public float speed = 4f;
    LevelManager lm;
    public int weaponDamage;
    public TextMeshProUGUI healthBar;
    // Start is called before the first frame update
    void Start()
    {
        weaponDamage = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        lm = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(player.transform);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sword"))
            weaponDamage = 4;
        else if (other.gameObject.CompareTag("Star"))
            weaponDamage = 2;
        else if (other.gameObject.CompareTag("Bullet"))
            weaponDamage = 1;
        enemyHealth = enemyHealth - weaponDamage;
        healthBar.text = enemyHealth + " HP";
        if (enemyHealth <= 0)
        {
            lm.AddPoints(1);
            Destroy(gameObject);
            //Destroy(other.gameObject);
        }
    }
}