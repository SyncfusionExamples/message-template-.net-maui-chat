using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Maui.Chat;
using Syncfusion.Maui.Chat.Internals;

namespace MauiChat
{
    public class ChatMessageTemplateSelector : DataTemplateSelector
    {
        #region Fields

        private readonly DataTemplate? incomingDataTemplate;
        private readonly DataTemplate? outgoingDataTemplate;
        private readonly DataTemplate? ratingDataTemplate;

        #endregion

        #region Public Properties

        public SfChat? Chat { get; set; }
        #endregion

        #region Constructor
        public ChatMessageTemplateSelector()
        {
            this.incomingDataTemplate = new DataTemplate(typeof(IncomingMessageTemplate));
            this.outgoingDataTemplate = new DataTemplate(typeof(OutgoingMessageTemplate));
            this.ratingDataTemplate = new DataTemplate(typeof(RatingTemplate));
        }
        #endregion

        #region Override methods
        protected override DataTemplate? OnSelectTemplate(object item, BindableObject container)
        {
            var message = item as IMessage;
            if (message == null || Chat == null)
            {
                return null;
            }

            if (message.Author == Chat!.CurrentUser)
            {
                return outgoingDataTemplate;
            }
            else
            {
                if (item as ITextMessage != null)
                {
                    if ((item as ITextMessage)!.Text == "How would you rate your interaction with our travel bot?")
                    {
                        return ratingDataTemplate;
                    }
                    else
                    {
                        return incomingDataTemplate;
                    }
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion
    }
}
