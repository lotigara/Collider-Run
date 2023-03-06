using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;

public class DiscordController : MonoBehaviour
{
    
    public Discord.Discord _discord;
    public string state;
    public string imageKey;
    public string imageText;
    public bool instance;

    public void Start()
    {
        _discord =  new Discord.Discord(clientId: 1075494312055410729, (int)Discord.CreateFlags.Default);

        var activity = new Discord.Activity
        {
        State = state,
        Assets =
        {
            LargeImage = imageKey,
            LargeText = imageText,
        },
        Instance = instance,
        };

        _discord.GetActivityManager().UpdateActivity(activity, (result) =>
        {
            if (result == Discord.Result.Ok)
            {
                Debug.Log("Success!");
            }
            else
            {
                Debug.Log("Failed");
            }
        });
    }
    
    public void Update()
    {
        _discord.RunCallbacks();
    }

    public void OnApplicationQuit()
    {
        _discord.Dispose();
    }
} 