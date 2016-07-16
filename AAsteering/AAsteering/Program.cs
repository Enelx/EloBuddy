using System;
using EloBuddy.SDK.Events;

namespace AAsteering
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += OnLoadingComplete;
        }

        private static void OnLoadingComplete(EventArgs args)
        {
            Steering.Initialize();
        }
    }
}