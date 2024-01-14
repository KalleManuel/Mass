using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CurrentObjective : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI objectiveText;
    public enum Objective { ConsumeSmaller, ConsumeSameColor, ConsumeBigger, ConsumeOtherColor}

    public Objective objective = Objective.ConsumeSmaller;

    private float timer = 30;

    private ColorsInGame colorsInGame;
    public int colorIndex;
    public bool setColorIndex;

    PlayerMass playerMass;
    [SerializeField]
    private GameObject gameOverPlate;

    void Start()
    {
        Time.timeScale = 1;
        colorsInGame = GameObject.FindGameObjectWithTag("GameController").GetComponent<ColorsInGame>();
        playerMass = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMass>();
        setColorIndex = true;
        gameOverPlate.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            
            timer -= Time.deltaTime;

        }   
        else
        {
            timer = 30;
            ChangeObjective();

        }

        if (playerMass.mass < 0.3f)
        {
            playerMass.mass = 0.309f;
            GameOver();
        }
      
    }

    private void ChangeObjective()
    {
        objective = (Objective)Random.Range(0, 4);
        
        if (objective == Objective.ConsumeSameColor)
        {
            
            colorIndex = Random.Range(0, colorsInGame.dotColor.Length - 1);
            GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().color =
                colorsInGame.dotColor[colorIndex];
            objectiveText.text = "Consume same color";
            objectiveText.color = colorsInGame.dotColor[colorIndex];
        }
        else if (objective == Objective.ConsumeSmaller)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().color =
                   colorsInGame.black;
            objectiveText.text = "Consume smaller";
            objectiveText.color = colorsInGame.black;
        }

        else if (objective == Objective.ConsumeBigger)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().color =
                   colorsInGame.white;
            objectiveText.text = "Consume bigger";
            objectiveText.color = colorsInGame.black;
        }

        else if (objective == Objective.ConsumeOtherColor)
        {

            colorIndex = Random.Range(0, colorsInGame.dotColor.Length - 1);
            GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().color =
                colorsInGame.dotColor[colorIndex];
            objectiveText.text = "Consume other color";
            objectiveText.color = colorsInGame.dotColor[colorIndex];
        }
    }

    private void GameOver()
    {
        gameOverPlate.SetActive(true);
        Time.timeScale = 0;

    }
}
