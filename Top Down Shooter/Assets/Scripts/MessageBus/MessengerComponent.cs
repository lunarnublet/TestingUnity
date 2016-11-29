using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Assets.Scripts.MessageBus
{

    public class MessengerComponent : MonoBehaviour, IMessenger
    {
        private Dictionary<Type, IList<SubscriptionHolder>> _subscriptions = new Dictionary<Type, IList<SubscriptionHolder>>();

        public MessageSubscription Subscribe<T>(Action<T> onDelivery) where T : IMessage
        {
            Action<IMessage> callback = onDelivery as Action<IMessage>;

            int handle = -1;
            if (_subscriptions.ContainsKey(typeof(T)))
            {
                handle = _subscriptions[typeof(T)].Count + 1;
                _subscriptions[typeof(T)].Add(new SubscriptionHolder(handle, callback));
            }
            else
            {
                List<SubscriptionHolder> list = new List<SubscriptionHolder>();
                handle = 1;

                list.Add(new SubscriptionHolder(handle, callback));
                _subscriptions.Add(typeof(T), list);
            }

            MessageSubscription sub = new MessageSubscription(handle);
            return sub;
        }

        void IMessenger.Unsubscribe<T>(MessageSubscription subscription)
        {
            if (_subscriptions.ContainsKey(typeof(T)))
            {
                SubscriptionHolder holder = _subscriptions[typeof(T)].SingleOrDefault(x => x.Handle == subscription.Handle);
                if (holder != null)
                {
                    _subscriptions[typeof(T)].Remove(holder);
                }
            }
        }

        void IMessenger.Publish<T>(T message)
        {
            if (_subscriptions.ContainsKey(typeof(T)))
            {
                foreach(SubscriptionHolder holder in _subscriptions[typeof(T)])
                {
                    holder.Callback(message as IMessage);
                }
            }
        }
    }
}
