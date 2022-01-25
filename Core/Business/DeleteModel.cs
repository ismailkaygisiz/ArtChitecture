using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business
{
    public class DeleteModel : IEntity
    {
        public int ID { get; set; }
        public Guid UUID { get; set; }
    }
}
