using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NumberWizard : MonoBehaviour
{
    int minValue;
    int maxValue;
    int guess;
    int numberOfGuesses;
    bool modeChosen = false;
    bool firstGuess = false;

    void Start()
    {              
        Debug.Log("Want to play a game? Choose the difficulty level by pressing accurate number.<color=green> 1) easy</color> " +
            "<color=yellow>2) normal</color><color=red> 3) hard</color> ");     
    }


    void Update()
    {
     
         // GAMEPLAY
            if(modeChosen == false)
                 {
                    ModeChoosing();
                 }
            if (modeChosen == true)
                 {
                    FirstGuess();
                 }


            if (Input.GetKeyDown(KeyCode.UpArrow) && firstGuess)
            {
                ChoosingGreaterNumber();
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) && firstGuess)
            {
                ChoosingSmallerNumber();
            }

            if (Input.GetKeyDown(KeyCode.Return) && firstGuess)
            {
                GameOver();
            }

            if (Input.GetKeyDown(KeyCode.R) && firstGuess)
            {
            ReloadingScene();
            }

        //FUNCTIONS
        void ModeChoosing()
        {
            switch (Input.inputString)
            {
                case "1":
                    maxValue = 500;
                    modeChosen = true;
                    break;
                case "2":
                    maxValue = 1000;
                    modeChosen = true;
                    break;
                case "3":
                    maxValue = 5000;
                    modeChosen = true;
                    break;
            }
        }
        void FirstGuess()
        {

            guess = (minValue + maxValue) / 2;

            Debug.Log($"<color=red>Okay, imagine an integer number beetwen {minValue } and {maxValue}, you don't know that yet but I can read your mind</color>");
            
            Debug.Log("I guess I'm not that smart and I need your help."
            + " Is your number greater (press up arrow) or smaller (press down) than " + guess + "? " + "If I guess your number press Enter.");

            numberOfGuesses++;
            maxValue += 1;
            modeChosen = false;
            firstGuess = true;

        }

        void ChoosingGreaterNumber()
        {
            minValue = guess;
            guess = (minValue + maxValue) / 2;
            Debug.Log("Is your number greater or smaller than " + guess);
            numberOfGuesses++;
        }

        void ChoosingSmallerNumber()
        {
            maxValue = guess;
            guess = (minValue + maxValue) / 2;
            Debug.Log("Is your number greater or smaller than " + guess);
            numberOfGuesses++;
        }

        void GameOver()
        {
            Debug.Log("Buahahah I knew it!!! I won in " + numberOfGuesses + " guesses. You see, that wasn't game for you, but for me, I suppose. If you want to play with me one more time press R");
        }

        void ReloadingScene()
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
