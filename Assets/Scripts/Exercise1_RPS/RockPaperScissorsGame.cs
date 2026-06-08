/*
 * Assignment: Rock Paper Scissors Lizard Spock Game
 * 
 * Objective:
 * Implement a fully functional Rock Paper Scissors Lizard Spock game using Unity and C#. The player selects a choice via UI buttons, 
 * the computer randomly selects its choice, and the game determines the winner based on the game rules.
 * 
 * Requirements:
 * 1. The player can choose from five options: Rock, Paper, Scissors, Lizard, or Spock by pressing designated buttons in the scene.
 * 2. The computer randomly selects one of the five choices each turn.
 * 3. Game logic determines the winner based on the following rules:
 *    - Rock beats Scissors and Lizard
 *    - Scissors beats Paper and Lizard
 *    - Paper beats Rock and Spock
 *    - Lizard beats Paper and Spock
 *    - Spock beats Scissors and Rock
 * 4. Ties occur when both the player and computer choose the same option.
 * 5. All game results (player choice, computer choice, and outcome) should be output using Debug.Log.
 * 6. Use an enum to represent the five choices instead of strings.
 * 7. Update the OnClick() method in the editor to use enums instead of strings.
 * 
 * Instructions:
 * - Attach the script to any active GameObject in your Unity scene.
 * - Change the OnClick method on the UI buttons in the scene to use enums instead of strings.
 * - Observe the game results in the Console after each button press.
 * 
 * Hint:
 * - Start by just fixing up the strings and doing Rock Paper Scissors. 
 * - Once you have that working, add in the Lizard and Spock options and update the game logic accordingly.
 * - Lastly, change the method to use enums instead of strings.
 *
 */

using System;
using UnityEditor;
using UnityEngine;

public class RockPaperScissorsGame : MonoBehaviour
{
    public enum Choice
    {
        Rock,
        Paper,
        Scissors,
        Lizard,
        Spock
    }

    private enum Outcome
    {
        Win,
        Lose,
        Tie
    }

    private Choice GetRandomChoice(int enumLen)
    {
        return (Choice)UnityEngine.Random.Range(0, enumLen);
    }

    public void RockPaperScissors(int playerChoice)
    {
        Debug.Log("You chose: " + (Choice)playerChoice);

        int enumLen = Enum.GetNames(typeof(Choice)).Length; // doesn't support generic in this Unity version? Use older syntax 
        Choice computerChoice = GetRandomChoice(enumLen);

        Debug.Log("Computer chose: " + computerChoice);

        GetResult((Choice)playerChoice, computerChoice);
    }

    private void GetResult(Choice p1, Choice p2)
    {
        Outcome res;

        if (p1 == p2)
        {
            res = Outcome.Tie;
        }
        else
        {
            switch (p1)
            {
                case Choice.Rock:
                    res = (p2 == Choice.Scissors || p2 == Choice.Lizard) ? Outcome.Win : Outcome.Lose;
                    break;
                case Choice.Scissors:
                    res = (p2 == Choice.Paper || p2 == Choice.Lizard) ? Outcome.Win : Outcome.Lose;
                    break;
                case Choice.Paper:
                    res = (p2 == Choice.Rock || p2 == Choice.Spock) ? Outcome.Win : Outcome.Lose;
                    break;
                case Choice.Lizard:
                    res = (p2 == Choice.Paper || p2 == Choice.Spock) ? Outcome.Win : Outcome.Lose;
                    break;
                case Choice.Spock:
                    res = (p2 == Choice.Scissors || p2 == Choice.Rock) ? Outcome.Win : Outcome.Lose;
                    break;
                default:
                    res = Outcome.Tie;
                    break;
            }
        }

        if (res == Outcome.Win){
            Debug.Log($"You win! {p1} beats {p2}.");
        }
        else if (res == Outcome.Lose)
        {
            Debug.Log($"You lose! {p2} beats {p1}.");
        }
        else
        {
            Debug.Log($"It's a tie! Both chose {p1}.");
        }
    }
}
