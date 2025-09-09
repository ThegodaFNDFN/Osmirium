using HarmonyLib;
using IIDKQuest.Notifications;
using Photon.Pun;
using Photon.Realtime;
using System.IO;
using UnityEngine;
using static IIDKQuest.Menu.Main;

namespace IIDKQuest.Patches
{
    [HarmonyPatch(typeof(MonoBehaviourPunCallbacks), "OnPlayerEnteredRoom")]
    internal class JoinPatch
    {
        private static void Prefix(Player newPlayer)
        {
            if (newPlayer != oldnewplayer)
            {
                NotifiLib.SendNotification("<color=grey>[</color><color=green>JOIN</color><color=grey>] </color><color=white>Name: " + newPlayer.NickName + "</color>");
                oldnewplayer = newPlayer;
            }
        }

        private static Player oldnewplayer;
    }
}