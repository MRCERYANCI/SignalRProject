using SignalR.EntityLayer.Entities;
using SignalRDataAccessLayer.Abstract;

namespace SignalRDataAccessLayer.Abstract
{
    public interface ICategoryDal : IGenericDal<Category>
    {
        public int CategoryCount();
        public int AciveCategoryCount();
        public int pasiveCategoryCount();
    }
}
