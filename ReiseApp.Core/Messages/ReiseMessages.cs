using CommunityToolkit.Mvvm.Messaging.Messages;
using ReiseApp.Data.Models;

namespace ReiseApp.Core.Messages
{
    public class ReiseMessages : ValueChangedMessage<Reise>
    {
        public ReiseMessages(Reise value) : base(value)
        {
        }
    }
}
