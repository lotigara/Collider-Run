using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;

public class DiscordController : MonoBehaviour
{
    public Discord.Discord discord;
    public string state;
    public string details;
    public string imageText;
    public void Start()
    {
        discord = new Discord.Discord(1075494312055410729, (System.UInt64)Discord.CreateFlags.Default);
        var activityManager = discord.GetActivityManager();
        var activity = new Discord.Activity
        {
            State = state,
            Details = details,
            Assets =
            {
                LargeImage = "discord",
                LargeText = imageText,
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