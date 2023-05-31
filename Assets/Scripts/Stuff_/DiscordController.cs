using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;

public class DiscordController : MonoBehaviour
{
    public Discord.Discord discord;
    public void Start()
    {
        discord = new Discord.Discord(1075494312055410729, (System.UInt64)Discord.CreateFlags.Default);
        var activityManager = discord.GetActivityManager();
        var activity = new Discord.Activity
        {
            Assets =
            {
                LargeImage = "discord",
                LargeText = "The Main Hero and Logo of The Game",
            },
            Timestamps = 
            {
                Start = 5,
            }
        };
        activityManager.UpdateActivity
        (activity, (res) =>
        {
            if (res == Discord.Result.Ok)
            {
                Debug.Log("Discord Activity is set!");
            }
            else
            {
                Debug.LogError("Discord Activity is failed :(");
            }
        });
        //discord.RunCallbacks();
    }

    public void Update()
    {
        discord.RunCallbacks();
    }
    public void OnApplicationQuit()
    {
        discord.Dispose();
    }
} 