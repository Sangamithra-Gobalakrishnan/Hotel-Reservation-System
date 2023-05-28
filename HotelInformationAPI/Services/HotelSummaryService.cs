using HotelInformationAPI.Interface;
using HotelInformationAPI.Models;
using System;

namespace HotelInformationAPI.Services
{
    public class HotelSummaryService : IHotelSummaryService<Hotel, string, double, int>
    {
        private readonly IRepo<Hotel, int> _repo;

        public HotelSummaryService(IRepo<Hotel,int> repo) 
        {
            _repo = repo;
        }

        public ICollection<Hotel> GetAll()
        {
            var hotels = _repo.GetAll();
            if (hotels != null)
                return hotels;
            return null;
        }

        public ICollection<Hotel> GetByLocation(string location)
        {
            List<Hotel> hotels = new List<Hotel>();
            var hotel = _repo.GetAll();
            if(hotel != null)
            {
                foreach(var item in hotel)
                {
                    if(item.City.ToLower() == location.ToLower())
                    {
                        hotels.Add(item);
                    }
                }
                return hotels;
            }
            return null;
        }

        public ICollection<Hotel> GetByPriceRange(double range)
        {
            List<Hotel> hotels = new List<Hotel>();
            var hotel = _repo.GetAll();
            if (hotel != null)
            {
                foreach (var item in hotel)
                {
                    if (range <= item.MinimumPriceRange)
                    {
                        hotels.Add(item);
                    }
                }
                return hotels;
            }
            return null;
        }

        public int GetCount(string hotel)
        {
            var hotels = _repo.GetAll();
            if (hotels != null)
            {
                foreach (var item in hotels)
                {
                    if (item.Name.ToLower() == hotel.ToLower())
                    {
                        return item.NumberOfRooms;
                    }
                }
            }return 0;
        }
    }
}
