using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    //Ressources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //Reference
    public PlayerMovement player;

    //Logic
    public int coin;
    public int experience;

    /*
     * int preferedSkin
     * int coin
     * int experience
     * int weaponLevel
     */

    public void SaveState()
    {
        string s = "";
        s += "0" + "|";
        s += coin.ToString() + "|";
        s += experience.ToString() + "|";
        s += "0";
        PlayerPrefs.SetString("SaveState", s);
        Debug.Log("Save");
    }
    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
            return;
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        //Change player skin
        coin = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        //Change the weapon level

        Debug.Log("Load");
    }
}
