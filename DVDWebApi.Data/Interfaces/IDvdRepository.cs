using DVDWebApi.Models;
using DVDWebApi.Models.Queries;
using System.Collections.Generic;

namespace DVDWebApi.Data.DataInterfaces
{
    public interface IDvdRepository
    {
        List<Dvd> GetAll();
        void Insert(Dvd dvd);
        void Update(Dvd dvd);
        Dvd GetById(int id);
        void Delete(int id);
        IEnumerable<Dvd> Search(ListingSearchParameters parameters);
    }
}
