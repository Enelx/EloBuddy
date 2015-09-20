using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;

namespace AntiBronzeBuddys
{
    class Program
    {
        static List<string> _allowed = new List<string> { "/mute all", "/msg", "/r", "/w", "/surrender", "/nosurrender", "/help", "/dance", "/d", "/taunt", "/t", "/joke", "/j", "/laugh", "/l", "/ff" };

        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            Chat.Say("/mute all");

            Chat.OnInput += Chat_OnInput;
        }

        private static void Chat_OnInput(ChatInputEventArgs args)
        {
            args.Process = false;

            if (_allowed.Any(str => args.Input.StartsWith(str)))
            {
                args.Process = true;
            }
        }
    }
}
