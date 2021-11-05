using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    interface IColorService
    {
        IDataResult<Color> GetById(int id);
        IDataResult<List<Color>> GetAll();
        IResult Add(Color color);
        IResult Update(Color color);
        IResult Delete(Color color);
    }
}
