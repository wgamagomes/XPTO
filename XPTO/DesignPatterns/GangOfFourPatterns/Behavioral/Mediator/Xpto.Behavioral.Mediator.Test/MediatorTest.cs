﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Xpto.Behavioral.Mediator.CSharpThreeDesignPatternsBook;
namespace Xpto.Behavioral.Mediator.Test
{
    class MediatorTest
    {
        private CSharpThreeDesignPatternsBook.Mediator _mediator;
        private Colleague _head1;
        private Colleague _branch;
        private Colleague _head2;

        [SetUp]
        public void Setup()
        {
            _mediator = new CSharpThreeDesignPatternsBook.Mediator();// Two from head office and one from a branch office 
            _head1 = new Colleague(_mediator, "John");
            _branch = new Colleague(_mediator, "David");
            _head2 = new Colleague(_mediator, "Lucy");
        }

        [Test]
        public void Should_Send_Message()
        {
 

            _head1.Send("Meeting on Tuesday, please all ack");
            _branch.Send("Ack"); // by design does not get a copy 
           
        }

        [Test]
        public void Should_Block_Messages()
        {
          

            _head1.Send("Meeting on Tuesday, please all ack");
            _branch.Send("Ack"); // by design does not get a copy 
            _mediator.Block(_branch.Receive); // temporarily gets no messages 
            _head1.Send("Still awaiting some Acks");           
        }

        [Test]
        public void Should_Unblock_Messages()
        {
       

            _head1.Send("Meeting on Tuesday, please all ack");
            _branch.Send("Ack"); // by design does not get a copy 
            _mediator.Block(_branch.Receive); // temporarily gets no messages 
            _head1.Send("Still awaiting some Acks");
            _head2.Send("Ack");
            _mediator.Unblock(_branch.Receive); // open again 
            _head1.Send("Thanks all");
        }
    }
}
