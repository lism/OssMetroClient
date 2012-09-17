﻿using Caliburn.Micro;
using OssClientMetro.Events;
using OssClientMetro.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OssClientMetro.ViewModels
{


     [Export(typeof(IRightView))]
    class RightViewModel : Conductor<IRightWorkSpace>.Collection.OneActive, IRightView, IHandle<LoginResultEvent>
    {
        readonly IEventAggregator events;
        readonly IClientService clientService;
        readonly IWindowManager windowManager;

        [ImportingConstructor]
         public RightViewModel(IEventAggregator _events, IClientService _clientService, IWindowManager _windowManager)
         {
             windowManager = _windowManager;
              events = _events;
            events.Subscribe(this);
            clientService = _clientService;
         }

        public void Handle(LoginResultEvent loginResult)
        {
            if (loginResult.result == Result.SUCCESS)
            {
                objectViewModel = new ObjectViewModel(events, clientService, windowManager);
                ActivateItem(objectViewModel);
            }

        }


        ObjectViewModel objectViewModel;

    }


}