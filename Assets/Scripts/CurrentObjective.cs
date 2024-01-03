using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CurrentObjective : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI objectiveText;
    public enum Objective { Size, Color, Shape}

    public Objective objective = Objective.Size;

    private float timer = 30;

    private ColorsInGame colorsInGame;
    public int colorIndex;
    public bool setColorIndex;

    PlayerMass playerMass;
    [SerializeField]
    private GameObject gameOverPlate;

    void Start()
    {
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
            GameOver();
        }
      
    }

    private void ChangeObjective()
    {
        if (objective == Objective.Size)
        {
            objective = Objective.Color;
            colorIndex = Random.Range(0, colorsInGame.dotColor.Length - 1);
            GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().color =
                colorsInGame.dotColor[colorIndex];
            objectiveText.text = "Consume color";
            objectiveText.color = colorsInGame.dotColor[colorIndex];
        }
        else if (objective == Objective.Color)
        {
            objective = Objective.Size;
            GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().color =
                   colorsInGame.playerColor;
            objectiveText.text = "Consume smaller";
            objectiveText.color = colorsInGame.playerColor;
        }
    }

    private void GameOver()
    {
        gameOverPlate.SetActive(true);
        Time.timeScale = 0;

    }
}
