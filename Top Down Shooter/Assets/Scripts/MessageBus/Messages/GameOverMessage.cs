using UnityEngine;
using System.Collections;

namespace Assets.Scripts.MessageBus.Messages
{
    public class GameOverMessage : Message<string>
    {
        public GameOverMessage(object sender, string content) : base(sender, content)
        {
        }
    }
}
