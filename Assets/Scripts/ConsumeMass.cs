using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumeMass : MonoBehaviour
{ 
    
    private PlayerMass playerMass;
    private CurrentObjective currentObjective;
    private ColorsInGame colorsInGame;
    
    public GameObject spawnDrop;
    private bool timeToDrop;
    private float dropTimer; 
    public float dropTime = 0.2f;
   
    void Start()
    {
        playerMass = GetComponent<PlayerMass>();
        currentObjective = GameObject.FindGameObjectWithTag("GameController").GetComponent<CurrentObjective>();
        colorsInGame = GameObject.FindGameObjectWithTag("GameController").GetComponent<ColorsInGame>();
        dropTimer = dropTime;
    }

    private void Update()
    {
        if (timeToDrop)
        {
             if (dropTimer > 0)
            {
                dropTimer -= Time.deltaTime;
            }
            else
            {

                Instantiate(spawnDrop, transform.position, transform.rotation);
                float newMass = playerMass.newMass -= Random.Range((playerMass.newMass / 10), (playerMass.newMass / 20));
                playerMass.ChangeizeOnPlayerMass(newMass);

                dropTimer = dropTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (currentObjective.objective == CurrentObjective.Objective.Size)
        {
            collision.TryGetComponent<Mass>(out Mass dotMass);
            collision.TryGetComponent<DotColor>(out DotColor dotColor);

            if (playerMass.mass > dotMass.mass && dotColor.consumeble)
            {
                float newMass = playerMass.newMass + (dotMass.mass / 10);
                playerMass.ChangeizeOnPlayerMass(newMass);
                dotMass.consumed = true;
                dotColor.consumeble = false;


            }
            else timeToDrop = true;
        }

        else if (currentObjective.objective == CurrentObjective.Objective.Color)
        {
            collision.TryGetComponent<DotColor>(out DotColor dotColor);
            collision.TryGetComponent<Mass>(out Mass dotMass);

            if (currentObjective.colorIndex == dotColor.colorIndex && dotColor.consumeble)
            {
                float newMass = playerMass.newMass + (dotMass.mass / 10);
                playerMass.ChangeizeOnPlayerMass(newMass);
                dotMass.consumed = true;
                dotColor.consumeble = false;
            }
            else timeToDrop = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (currentObjective.objective == CurrentObjective.Objective.Size)
        {
            collision.TryGetComponent<Mass>(out Mass dotMass);
            collision.TryGetComponent<DotColor>(out DotColor dotColor);

            if (playerMass.mass < dotMass.mass && dotColor.consumeble)
            {
                timeToDrop = false;
                dropTimer = dropTime;

            }
        }

        else if (currentObjective.objective == CurrentObjective.Objective.Color)
        {
            collision.TryGetComponent<DotColor>(out DotColor dotColor);
            collision.TryGetComponent<Mass>(out Mass dotMass);

            if (currentObjective.colorIndex != dotColor.colorIndex && dotColor.consumeble)
            {
                timeToDrop = false;
                dropTimer = dropTime;

            }

        }

    }
}
