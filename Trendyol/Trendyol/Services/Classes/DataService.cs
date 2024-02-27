using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Messages;
using Trendyol.Services.Interfaces;

namespace Trendyol.Services.Classes;

public class DataService : IDataService
{
    private readonly IMessenger _messenger;

    public DataService(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void SendData(object data)
    {
        _messenger.Send(new DataMessage()
        {
            Data = data
        });
    }
}
