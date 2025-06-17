using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReiseApp.Core.Messages;

public class ReiseRefresh : ValueChangedMessage<string>
{

    public ReiseRefresh(string value) : base(value)
    {


    }

}
