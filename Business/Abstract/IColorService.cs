﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> GetByName(string colorName);
        IDataResult<List<Color>> GetById(int colorId);
        IResult Add(Color color);
        IResult Delete(Color color);
        IResult Update(Color color);
    }
}
