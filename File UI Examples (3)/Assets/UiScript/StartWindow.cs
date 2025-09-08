using UnityEngine;
using UnityEngine.UI;

public class StartWindow : GenericWindow
{
    public bool canContinue = true;

    public GameObject startPanel;
    public GameObject gameOverPanel;

    public Button continueButton;
    public Button newGameButton;
    public Button optionButton;

    protected void Awake()
    {
        continueButton.onClick.AddListener(OnClickContinue);
        //continueButton.onClick.AddListener(() => Debug.Log("OnClickContinue"));
        newGameButton.onClick.AddListener(OnClickNewGame);
        optionButton.onClick.AddListener(OnClickOption);
    }

    public override void Open()
    {
        continueButton.gameObject.SetActive(canContinue);
        firstSelected = continueButton.gameObject.activeSelf ? continueButton.gameObject : newGameButton.gameObject;

        base.Open();

    }

    public void OnClickContinue()
    {
        Debug.Log("OnClickContinue");
    }

    public void OnClickNewGame()
    {
        //Debug.Log("OnClickNewGame");
        startPanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    public void OnClickOption()
    {
        Debug.Log("OnClickOption");
    }

    
}
