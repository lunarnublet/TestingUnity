using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.MessageBus
{
    public interface IMessenger
    {
        MessageSubscription Subscribe<T>(Action<T> onDelivery) where T : IMessage;
        void Unsubscribe<T>(MessageSubscription subscription) where T : IMessage;
        void Publish<T>(T message) where T : IMessage;
    }

    public class MessageSubscription
    {
        public int Handle { get; protected set; }

        public MessageSubscription(int handle)
        {
            Handle = handle;
        }
    }

    public class SubscriptionHolder
    {
        public int Handle { get; protected set; }

        public Action<IMessage> Callback { get; protected set; }

        public SubscriptionHolder(int handle, Action<IMessage> callback)
        {
            Handle = handle;
            Callback = callback;
        }
    }

    public interface IMessage
    {
        object Sender { get; }
    }

    public class Message<T> : IMessage
    {
        private WeakReference _sender;

        public object Sender
        {
            get
            {
                return (_sender == null ? null : _sender.Target);
            }
        }

        public T Content { get; protected set; }

        public Message(object sender, T content)
        {
            if (sender == null)
                throw new ArgumentNullException("sender");

            _sender = new WeakReference(sender);
            Content = content;
        }
    }
}
