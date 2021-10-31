using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private IColorDal iColorDal;

        public ColorManager(IColorDal iColorDal)
        {
            this.iColorDal = iColorDal;
        }

        public Color GetById(int id)
        {
            return iColorDal.Get(c => c.Id == id);
        }

        public List<Color> GetAll()
        {
            return iColorDal.GetAll();
        }

        public void Add(Color color)
        {
            iColorDal.Add(color);
        }

        public void Update(Color color)
        {
            iColorDal.Update(color);
        }

        public void Delete(Color color)
        {
            iColorDal.Delete(color);
        }
    }
}
