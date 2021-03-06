﻿using System;
using Xpto.GangOfFourPatterns.Behavioral.ChainOfResponsibility.Enums;
using Xpto.GangOfFourPatterns.Behavioral.ChainOfResponsibility.Interfaces;
using Xpto.GangOfFourPatterns.Behavioral.ChainOfResponsibility.ValueObject;

namespace Xpto.GangOfFourPatterns.Behavioral.ChainOfResponsibility.Notifiers
{
    public class BuyerRefusalNotifier : INotifier
    {
        public INotifier Next { get; set; }
           
        public void Notify(Action<InfoValueObject> execute, InfoValueObject info)
        {
            if (info.Status == Status.CustomerRefusal)
            {
                info.Message = "Buyer Refuses your offer.";
                execute(info);
            }
            else
            {
                Next?.Notify(execute, info);
            }
        }
    }
}
