using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private Button retryBtn;
    [SerializeField]
    private TextMeshProUGUI gameOverText;
    [SerializeField]
    private GameObject menuScreen;

    // Start is called before the first frame update
    void Start()
    {
        gameOverText.text = "GAME OVER";
        PlayerInteract.isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Reds: " + PlayerInteract.reds + "\nBlues: " + PlayerInteract.blues;

        if(PlayerInteract.isPaused)
        {
            menuScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            menuScreen.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if(PlayerInteract.blues == 0 && PlayerInteract.reds == 0)
        {
            PlayerInteract.isPaused = true;
            gameOverText.text = "YOU WON";
        }
    }

    public void onClick()
    {
        PlayerInteract.isPaused = false;
        PlayerInteract.blues = 5;
        PlayerInteract.reds = 5;
        Debug.Log("Clicked");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
