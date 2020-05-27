using DVDWebApi.Data.DataInterfaces;
using DVDWebApi.Models;
using DVDWebApi.Models.Queries;
using System;
using System.Collections.Generic;

namespace DVDWebApi.Data.DataMockup
{
    public class DvdRepositoryMock : IDvdRepository
    {
        private static List<Dvd> dvds = new List<Dvd>
        {
            new Dvd { DvdId = 1, Title = "Dark Knight", Director = "Mike Smith", Notes = "the best",
                Rating = "PG-13", ReleaseYear = 1999 },
            new Dvd { DvdId = 2, Title = "Arkham City", Director = "Bob Allen", Notes = "is good",
                Rating = "PG-13", ReleaseYear = 2005 },
            new Dvd { DvdId = 3, Title = "New York City", Director = "Albert Jones", Notes = "average",
                Rating = "PG-13", ReleaseYear = 2002 }
        };

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Dvd> GetAll()
        {
            return dvds;
        }

        public Dvd GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Dvd dvd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dvd> Search(ListingSearchParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void Update(Dvd dvd)
        {
            throw new NotImplementedException();
        }
    }
}
