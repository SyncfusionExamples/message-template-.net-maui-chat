# message-template-.net-maui.chat
This sample demonstrates how to display chat messages using user-defined templates in .NET MAUI Chat (SfChat).

## Sample

```xaml
<ContentPage.Resources>
    <ResourceDictionary>
        <local:ChatMessageTemplateSelector Chat="{x:Reference sfChat}" x:Key="templateSelector"/>
    </ResourceDictionary>
</ContentPage.Resources>

<ContentPage.BindingContext>
    <local:ViewModel/>
</ContentPage.BindingContext>

<ContentPage.Content>
    <sfChat:SfChat x:Name="sfChat"
                   Messages="{Binding Messages}"
                   CurrentUser="{Binding CurrentUser}"
                   MessageTemplate="{StaticResource templateSelector}"/>
</ContentPage.Content>

TemplateSelector:

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
```
## Requirements to run the demo

To run the demo, refer to [System Requirements for .NET MAUI](https://help.syncfusion.com/maui/system-requirements)

## Troubleshooting:
### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.

## License

Syncfusion® has no liability for any damage or consequence that may arise from using or viewing the samples. The samples are for demonstrative purposes. If you choose to use or access the samples, you agree to not hold Syncfusion® liable, in any form, for any damage related to use, for accessing, or viewing the samples. By accessing, viewing, or seeing the samples, you acknowledge and agree Syncfusion®'s samples will not allow you seek injunctive relief in any form for any claim related to the sample. If you do not agree to this, do not view, access, utilize, or otherwise do anything with Syncfusion®'s samples.