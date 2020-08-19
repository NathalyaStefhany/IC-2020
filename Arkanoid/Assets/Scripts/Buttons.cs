using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Buttons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private string textName;
    private Text buttonText, playButtonText, scoreButtonText, quitButtonText, menuButtonText;

    void Awake()
    {
        if(SceneManager.GetActiveScene().name == "Menu")
        {
            playButtonText = GameObject.Find("Play").GetComponent<Text>();
            scoreButtonText = GameObject.Find("Score").GetComponent<Text>();
            quitButtonText = GameObject.Find("Quit").GetComponent<Text>();
        }
        
        else if(SceneManager.GetActiveScene().name == "GameOver" || SceneManager.GetActiveScene().name == "Victory")
        {
            menuButtonText = GameObject.Find("Menu").GetComponent<Text>();
        }
    }

    /*void Start()
    {
        textPlayButton = GameObject.Find("Play").GetComponent<Text>();
        textScoreButton = GameObject.Find("Score").GetComponent<Text>();
        textQuitButton = GameObject.Find("Quit").GetComponent<Text>();
    }*/

    /*private void OnEnable()
    {
        textPlayButton = GameObject.Find("Play").GetComponent<Text>();
        textScoreButton = GameObject.Find("Score").GetComponent<Text>();
        textQuitButton = GameObject.Find("Quit").GetComponent<Text>();
    }*/

    public void OnPointerEnter(PointerEventData eventData)
    {
        textName = eventData.pointerCurrentRaycast.gameObject.name;

        if(textName == "Play" || textName == "Score" || textName == "Quit" || textName == "Menu")
        {
            buttonText = GameObject.Find(textName).GetComponent<Text>();
            buttonText.color = new Color(0.7f, 0.73f, 0.98f);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(SceneManager.GetActiveScene().name == "Menu")
        {
            playButtonText.color = Color.white;
            scoreButtonText.color = Color.white;
            quitButtonText.color = Color.white;
        }
       
        else if (SceneManager.GetActiveScene().name == "GameOver" || SceneManager.GetActiveScene().name == "Victory")
        {
            menuButtonText.color = Color.white;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
