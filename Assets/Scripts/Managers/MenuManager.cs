using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject MainMenuPanel;

    [SerializeField]
    private GameObject CreditPanel;

    // Start is called before the first frame update
    void Start()
    {
        ActivateMenu();   
    }
    

    public void ActivateMenu()
    {
        MainMenuPanel.SetActive(true);
        CreditPanel.SetActive(false);
    }

    public void ActivateCredit()
    {
        MainMenuPanel.SetActive(false);
        CreditPanel.SetActive(true);
    }

    public void PlayButtonClick()
    {
        GameManager.Instance.CurrentState = Etats.EnJeu;
    }

    public void Quit(){
        Debug.Log("quitting");
        Application.Quit();
    }
}
