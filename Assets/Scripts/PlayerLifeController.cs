using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeController : MonoBehaviour
{
    public int maxPlayerHp = 20;
    public int playerHp = 20;
    public bool canAttack = true;
    public float cooldownBetweenAttacks = 0.6f;
    public int attackDamage = 1;
    public GameObject checkpoint;
    public Text attemptText;
    public int attempt = 1;
    public int maxAttempt = 100;

    void Start()
    {
        attemptText.text = "Попытка 1" + " | " + maxAttempt.ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Checkpoint"))
        {    
            checkpoint = other.gameObject;
            checkpoint.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("UsedCheckpoint");
            playerHp = maxPlayerHp;
        }

        if (other.gameObject.CompareTag("DeathBarrier")) Die();
    }

    public void Die() 
    {
        transform.position = checkpoint.gameObject.transform.position;
        attempt++;
        attemptText.text = "Попытка " + attempt.ToString() + " | " + maxAttempt.ToString();

        if (attempt >= maxAttempt)
        {
            gameObject.GetComponent<FindingCatsController>().Ending();
        }
    }
}
