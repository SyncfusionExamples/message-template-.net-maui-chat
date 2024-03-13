using Syncfusion.Maui.Chat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiChat
{
    public class ViewModel : INotifyPropertyChanged
    {
        #region Fields

        /// <summary>
        /// Collection of messages or conversation.
        /// </summary>
        private ObservableCollection<object> messages;

        /// <summary>
        /// current user of chat.
        /// </summary>
        private Author currentUser;

        #endregion

        #region Constructor
        public ViewModel()
        {
            this.messages = new ObservableCollection<object>();
            this.currentUser = new Author() { Name = "Nancy", Avatar = "peoplecircle16.png" };
            this.GenerateMessages();
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the group message conversation.
        /// </summary>
        public ObservableCollection<object> Messages
        {
            get
            {
                return this.messages;
            }

            set
            {
                this.messages = value;
            }
        }

        /// <summary>
        /// Gets or sets the current author.
        /// </summary>
        public Author CurrentUser
        {
            get
            {
                return this.currentUser;
            }
            set
            {
                this.currentUser = value;
                RaisePropertyChanged("CurrentUser");
            }
        }

        #endregion

        #region INotifyPropertyChanged
        /// <summary>
        /// Property changed handler.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Occurs when property is changed.
        /// </summary>
        /// <param name="propName">changed property name</param>
        public void RaisePropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        #endregion

        #region Message Generation
        private void GenerateMessages()
        {
            this.messages.Add(new TextMessage()
            {
                Author = new Author() { Name = "Travel Bot", Avatar = "flight.png" },
                Text = "Select your preferred airline company.",
            });

            this.messages.Add(new TextMessage()
            {
                Author = currentUser,
                Text = "Air Canada $2700",
            });

            this.messages.Add(new TextMessage()
            {
                Author = new Author() { Name = "Travel Bot", Avatar = "flight.png"},
                Text = "Congratulations ! Your booking has been conformed. A conformation along with your ticket has been sent to your email",
            });

            this.messages.Add(new TextMessage()
            {
                Author = new Author() { Name = "Travel Bot", Avatar = "flight.png"},
                Text = "Bon Voyage",
            });

            this.messages.Add(new TextMessage()
            {
                Author = currentUser,
                Text = "Thank you",
            });

            this.messages.Add(new TextMessage()
            {
                Author = new Author() { Name = "Travel Bot", Avatar = "flight.png"},
                Text = "How would you rate your interaction with our travel bot?",
            });
        }
        #endregion
    }
}
