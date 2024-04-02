﻿using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDataAccessLayer.Abstract
{
    public interface IBasketDal : IGenericDal<Basket>
    {
        List<Basket> GetBasketsByTableNumber(int TableNumberId);
    }
}
