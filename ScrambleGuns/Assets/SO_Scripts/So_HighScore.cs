using UnityEngine;
[CreateAssetMenu]
public class So_HighScore : ScriptableObject
{
    public SO_IntList currentScore; 
    public int highScore;

    public void SetHighScore()
    {
        if (highScore < currentScore.lastInt)
        {
            highScore = currentScore.lastInt;
        }
        
    }
}
