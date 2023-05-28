using HotelInformationAPI.Interface;
using HotelInformationAPI.Models;

namespace HotelInformationAPI.Services
{
    public class HotelService : IService<Hotel, int>
    {
        private readonly IRepo<Hotel, int> _repo;

        public HotelService(IRepo<Hotel,int> repo) 
        { 
            _repo = repo;
        }
        public Hotel Add(Hotel item)
        {
            var addInfo =  _repo.Add(item);
            if (addInfo != null)
                return addInfo;
            return null;
        }
        public Hotel Delete(int key)
        {
            var delInfo = _repo.Delete(key);
            if(delInfo != null) 
                return delInfo;
            return null;
        }

        public Hotel Update(Hotel item)
        {
            var updateInfo = _repo.Update(item);
            if(updateInfo != null)
                return updateInfo;
            return null;
        }
    }
}
