using Microsoft.Xbox.Services.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerConnected : MonoBehaviour
{

    [Serializable]
    public struct ListMenu
    {
        public GameObject gameObjectGo;
        public GameObject gameObjectBack;
    }
    public ListMenu[] Menu;

    public GameObject Player1;
    public GameObject Player2;
    
    public Text StatusPanel;

    private PlayerAuthenticationBase player1Authentication;
    private PlayerAuthenticationBase player2Authentication;

    //private GameObject backToMenu;
    //private GameObject goToMenu;


    // Start is called before the first frame update
    void Start()
    {
        //// filho / pai
        //menuOptionsReturn.Add("Personalizar", "Principal");
        //menuOptionsReturn.Add("PersonalizarTeste", "Personalizar");
        //menuOptionsReturn.Add("Settings", "Principal");
        

        player1Authentication = Player1.GetComponent<PlayerAuthenticationBase>();
        player2Authentication = Player2.GetComponent<PlayerAuthenticationBase>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    //public void GoMenu(string goMenu)
    //{

    //    if (goMenu == "")
    //        return;

    //    this.DesativarMenus();

    //    //ativa o novo menu
    //    goToMenu = GameObject.Find(goMenu);
    //    goToMenu.SetActive(true);

    //}

    //public void BackMenu(string currentMenu)
    //{

    //    this.DesativarMenus();

    //    string backMenu = this.GetMenuBack(currentMenu);

    //    //ativa o novo menu
    //    backToMenu = GameObject.Find(backMenu);
    //    backToMenu.SetActive(true);
    //}

    //private string GetMenuBack(string goMenu)
    //{
    //    string backMenu;
    //    menuOptionsReturn.TryGetValue(goMenu, out backMenu);
    //    return backMenu;
    //}

    private GameObject DesativarMenu()
    {
        return GameObject.FindGameObjectWithTag("Menu");
    }

    public void GoMenu(string menuGo)
    {
        GameObject gameObject = this.DesativarMenu();
        gameObject.SetActive(false);
        
        foreach (var item in Menu)
        {

            if (item.gameObjectGo.name == menuGo)
            {
                item.gameObjectGo.SetActive(true);
                Button btn = item.gameObjectGo.GetComponentInChildren<Button>();
                if(btn != null)
                    btn.Select();
            }
                
        }

    }

    public void BackMenu()
    {

        GameObject gameObject = this.DesativarMenu();
        if (gameObject.name == "Principal")
            return;

        gameObject.SetActive(false);

        foreach (var item in Menu)
        {

            if (item.gameObjectGo == gameObject)
            {
                item.gameObjectBack.SetActive(true);
                Button btn = item.gameObjectBack.GetComponentInChildren<Button>();
                if (btn != null)
                    btn.Select();
            }
                

        }

    }

}
