using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Reference to our game objects
    public GameObject playButton;
    public GameObject backToMainMenuButton; //added last
    public GameObject playerShip;
    public GameObject enemySpawner;//reference to our enemy spawner
    public GameObject GameOverGO;//reference to the game over image
    public GameObject scoreUITextGO; //reference to the score text UI game object
    public GameObject TimeCounterGO; //reference to the time counter game object
    public GameObject GameTitleGO; //reference to the GameTitleGO

    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver,
    }

    GameManagerState GMstate;

    // Start is called before the first frame update
    void Start()
    {
        GMstate = GameManagerState.Opening;
    }

    //Function to update the game manager state
    void UpdateGameManagerState()
    {
        switch (GMstate)
        {
            case GameManagerState.Opening:

                //Hide game over
                GameOverGO.SetActive(false);

                //Display the game title
                GameTitleGO.SetActive(true);

                //Set play button visible (active)
                playButton.SetActive(true);

                //Set back to main menu button visible
                backToMainMenuButton.SetActive(true);

                break;
            case GameManagerState.Gameplay:

                //Reset the score
                scoreUITextGO.GetComponent<GameScore>().Score = 0;

                //hide play button on game play state
                playButton.SetActive(false);

                //hide main menu button on game play state
                backToMainMenuButton.SetActive(false);

                //hide the game title
                GameTitleGO.SetActive(false);

                //set the player visible (active) and init the player lives
                playerShip.GetComponent<PlayerControl>().Init();

                //Start enemy spawner
                enemySpawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();

                //Start the time counter
                TimeCounterGO.GetComponent<TimeCounter>().StartTimeCounter();

                break;
            case GameManagerState.GameOver:

                //Stop the time counter
                TimeCounterGO.GetComponent<TimeCounter>().StopTimeCounter();
                
                //Stop enemy spawner
                enemySpawner.GetComponent<EnemySpawner>().UnscheduleEnemySpawner();

                //Display game over
                GameOverGO.SetActive(true);

                //Change game manager state to Opening state after 8 seconds
                Invoke("ChangeToOpeningState", 8f);


                break;
        }
    }

    //Function to set the game manager state
    public void SetGameManagerState(GameManagerState state)
    {
        GMstate = state;
        UpdateGameManagerState();
    }

    //Our play button will call this function
    //when the user clicks the button.
    public void StartGamePlay()
    {
        GMstate = GameManagerState.Gameplay;
        UpdateGameManagerState();
    }

    //Function to change game manager state to opening state
    public void ChangeToOpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }

    public void ClickToHome()
    {
        SceneManager.LoadScene(0);
    }

}
