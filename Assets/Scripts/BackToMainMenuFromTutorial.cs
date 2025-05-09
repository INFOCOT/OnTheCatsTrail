using UnityEngine;

public class BackToMainMenuFromTutorial : MonoBehaviour
{
    public GameObject tutorialPanel;
    public GameObject mainMenuPanel;

    void Start()
    {
        tutorialPanel.SetActive(false);
        mainMenuPanel.SetActive(true);    
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && tutorialPanel.activeSelf)
        {
            tutorialPanel.SetActive(false);
            mainMenuPanel.SetActive(true);
        }   
    }
}
