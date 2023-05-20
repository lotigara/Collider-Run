using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customization : MonoBehaviour
{
    private SpriteRenderer sprite;
    private ArrayList skins;
    private Button cosmeticsButton;

    void Start()
    {
        cosmeticsButton = this.GetComponent<Button>();
        sprite = this.gameObject.GetComponent<SpriteRenderer>();
        string[] localSkins = PlayerPrefs.GetString("skins").Split('/');
        Debug.Log(localSkins);
        foreach (string skin in skins)
        {
            skins.Add(skin);
        }
        Debug.Log(skins);
        if (PlayerPrefs.GetInt("custom", 0) == 1)
        {
            cosmeticsButton.gameObject.SetActive(true);
        }
    }
}
