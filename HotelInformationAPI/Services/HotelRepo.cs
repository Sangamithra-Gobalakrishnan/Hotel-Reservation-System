using HotelInformationAPI.Interface;
using HotelInformationAPI.Models;
using System.Diagnostics;

namespace HotelInformationAPI.Services
{
    public class HotelRepo:IRepo<Hotel,int>
    {
        private readonly HotelContext _hotelContext;

        public HotelRepo(HotelContext hotelContext)
        {
            _hotelContext = hotelContext;
        }

        public Hotel Add(Hotel item)
        {
            try
            {
                _hotelContext.HotelInformation.Add(item);
                _hotelContext.SaveChanges();
                return item;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(item);
            }
            return null;
        }

        public Hotel Delete(int key)
        {
            try
            {
                var hotelInfo = _hotelContext.HotelInformation.FirstOrDefault(r => r.HotelId == key);
                if (hotelInfo != null)
                {
                    var deleteRooms = _hotelContext.RoomInformation.Where(r => r.HotelId == key);
                    _hotelContext.RoomInformation.RemoveRange(deleteRooms);
                    _hotelContext.SaveChanges();
                    Hotel info = new Hotel();
                    info.HotelId = hotelInfo.HotelId;
                    info.Name = hotelInfo.Name;
                    info.Description = hotelInfo.Description;
                    info.Address = hotelInfo.Address;
                    info.ContactNumber = hotelInfo.ContactNumber;
                    info.City = hotelInfo.City;
                    info.Country = hotelInfo.Country;
                    info.AverageRating = hotelInfo.AverageRating;
                    info.NumberOfRooms = hotelInfo.NumberOfRooms;
                    _hotelContext.Remove(hotelInfo);
                    _hotelContext.SaveChanges();
                    return info;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null;
        }

        public ICollection<Hotel> GetAll()
        {
            try
            {
                var hotelInfo = _hotelContext.HotelInformation;
                if (hotelInfo != null)
                {
                    return hotelInfo.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null;
        }

        public Hotel Update(Hotel item)
        {
            try
            {
                var hotelInfo = _hotelContext.HotelInformation.FirstOrDefault(r => r.HotelId == item.HotelId);
                if (hotelInfo != null)
                {
                    hotelInfo.HotelId = item.HotelId;
                    hotelInfo.Name = item.Name;
                    hotelInfo.Description = item.Description;
                    hotelInfo.Address = item.Address;
                    hotelInfo.ContactNumber = item.ContactNumber;
                    hotelInfo.City = item.City;
                    hotelInfo.Country = item.Country;
                    hotelInfo.AverageRating = item.AverageRating;
                    hotelInfo.NumberOfRooms = item.NumberOfRooms;
                    _hotelContext.SaveChanges();
                    return hotelInfo;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(item);
            }
            return null;
        }
    }
}
