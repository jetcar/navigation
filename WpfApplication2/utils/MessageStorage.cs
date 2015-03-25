using System;
using System.Collections.Generic;

namespace WpfApplication2.utils
{
    public class MessageStorage
    {

        private IMediator _messageMediator = App.MessageMediator;
        public IMediator InternalMediator
        {
            get { return _messageMediator; }
        }

        public IList<IActionDetails> actions = new List<IActionDetails>();

        public bool SendMessage<T>(T message, string MsgTag)
        {
            return InternalMediator.SendMessage(message, MsgTag);
        }
        public bool Register<T>(IClosable viewModelBase, Action<T> action, string msgTag)
        {
            var type = viewModelBase.GetType();
            foreach (var actionDetailse in actions)
            {
                if (actionDetailse.ViewModel.GetType() == type && actionDetailse.ViewModel.IsClosed && actionDetailse.MethodName == action.Method.Name && actionDetailse.Type == typeof(T) && actionDetailse.MsgTag == msgTag)
                {
                    actionDetailse.ViewModel = viewModelBase;
                    ((ActionDetails<T>)actionDetailse).Action = action;

                }
            }

            foreach (var actionDetailse in actions)
            {
                if (actionDetailse.ViewModel == viewModelBase && actionDetailse.MethodName == action.Method.Name && actionDetailse.Type == typeof(T) && actionDetailse.MsgTag == msgTag)
                {
                    return false;
                }
            }


            var actionDetails = new ActionDetails<T>();
            actionDetails.ViewModel = viewModelBase;
            actionDetails.Action = action;
            actionDetails.Type = typeof(T);
            actionDetails.MsgTag = msgTag;
            actions.Add(actionDetails);
            return InternalMediator.Register(actionDetails);

        }

        public void UnregisterRecipientAndIgnoreTags(IClosable viewModel)
        {
            InternalMediator.UnregisterRecipientAndIgnoreTags(viewModel);
            actions.Clear();
        }

        public void ApplyRegistration()
        {
            foreach (var actionDetail in actions)
            {
                InternalMediator.Register(actionDetail);
            }
        }
    }


}