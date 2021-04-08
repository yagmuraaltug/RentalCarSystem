using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   public class Card:IEntity
    {

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string CardExpirationDate { get; set; }
        public int CardCvv { get; set; }
    }
}
