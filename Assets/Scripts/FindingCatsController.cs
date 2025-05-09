using UnityEngine;
using UnityEngine.UI;

public class FindingCatsController : MonoBehaviour
{
    public Text foundCatsText;
    public Text nameOfEnding;
    public Text endingFoundCatsText;
    public GameObject endingPanel;
    public GameObject baseUIPanel;
    public int foundCats = 0;
    public int maxCats = 9;

    void Start()
    {
        baseUIPanel.SetActive(true);
        endingPanel.SetActive(false);
        foundCatsText.text = "Найдено котов: " + "0" + " | " + maxCats.ToString();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Cat"))
        {
            Destroy(collision.gameObject);
            foundCats++;
            foundCatsText.text = "Найдено котов: " + foundCats.ToString() + " | " + maxCats.ToString();
            
            if (foundCats == maxCats)
            {
                Ending();
            }
        }

        if (collision.gameObject.CompareTag("EndPlatform"))
        {
            Ending();
        }
    }

    public void Ending()
    {
        baseUIPanel.SetActive(false);
        endingPanel.SetActive(true);

        if (foundCats == maxCats)
        {
            nameOfEnding.text = "Самая хорошая концовка!";
            endingFoundCatsText.text = foundCatsText.text;
        }
        
        else if (foundCats < maxCats && foundCats > 0)
        {
            nameOfEnding.text = "Хорошая концовка!";
            endingFoundCatsText.text = foundCatsText.text;
        }
        
        else if (foundCats == 0)
        {
            nameOfEnding.text = "Плохая концовка";
            endingFoundCatsText.text = foundCatsText.text;
        }
            
    }
}