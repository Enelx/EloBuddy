using System;
using EloBuddy;
using EloBuddy.SDK.Events;

namespace FAKERyze
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += OnLoadingComplete;
        }

        private static void OnLoadingComplete(EventArgs args)
        {
            if (Player.Instance.Hero != Champion.Ryze) return;
            Ryze.Initialize();
            Chat.Print("FAKERyze Loaded - made by Enelx");
        }
    }
}