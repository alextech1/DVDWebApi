using DVDWebApi.Data.DataInterfaces;
using DVDWebApi.Models;
using DVDWebApi.Models.Queries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace DVDWebApi.Data.DataMockup
{
    public class DvdRepositoryMock : IDvdRepository
    {
        private static List<Dvd> dvds = new List<Dvd>
        {
            new Dvd { DvdId = 1, Title = "Dark Knight", Director = "Mike Smith", Notes = "the best",
                Rating = "PG-13", ReleaseYear = 1999, ImageFileName = "dvd2.png" },
            new Dvd { DvdId = 2, Title = "Arkham City", Director = "Bob Allen", Notes = "is good",
                Rating = "PG-13", ReleaseYear = 2005, ImageFileName = "dvd2.png" },
            new Dvd { DvdId = 3, Title = "New York City", Director = "Albert Jones", Notes = "average",
                Rating = "PG-13", ReleaseYear = 2002, ImageFileName = "dvd2.png" },
            new Dvd { DvdId = 4, Title = "Dark Knight 2", Director = "Mike Smith", Notes = "cool movie",
                Rating = "PG-13", ReleaseYear = 1999, ImageFileName = "dvd2.png" },
            new Dvd { DvdId = 5, Title = "Arkham City 2", Director = "Bob Allen", Notes = "average movie",
                Rating = "PG", ReleaseYear = 2005, ImageFileName = "dvd2.png" },
            new Dvd { DvdId = 6, Title = "New York City 2", Director = "Albert Jones", Notes = "better movie",
                Rating = "PG-13", ReleaseYear = 2002, ImageFileName = "dvd2.png" },
            new Dvd { DvdId = 7, Title = "Dark Knight 3", Director = "Mike Smith", Notes = "not so good",
                Rating = "PG", ReleaseYear = 1999, ImageFileName = "dvd2.png" },
            new Dvd { DvdId = 8, Title = "Arkham City 3", Director = "Bob Allen", Notes = "worst movie",
                Rating = "PG-13", ReleaseYear = 2005, ImageFileName = "dvd2.png" },
            new Dvd { DvdId = 9, Title = "New York City 3", Director = "Albert Jones", Notes = "very funny",
                Rating = "PG", ReleaseYear = 2002, ImageFileName = "dvd2.png" }
        };

        public void Delete(int id)
        {
            dvds.RemoveAll(x => x.DvdId == id);
        }

        public List<Dvd> GetAll()
        {
            return dvds;
        }

        public Dvd GetById(int id)
        {
            return dvds.FirstOrDefault(x => x.DvdId == id);
        }

        public void Insert(Dvd dvd)
        {
            var newId = dvds.Max(x => x.DvdId) + 1;
            dvd.DvdId = newId;
            dvds.Add(dvd);
        }

        public IEnumerable<Dvd> Search(ListingSearchParameters parameters)
        {
            List<Dvd> searchList = new List<Dvd>();

            if(!string.IsNullOrEmpty(parameters.Title))
            {
                searchList = dvds.Where(x => x.Title.ToLower().Contains(parameters.Title.ToLower())).ToList();
            }

            if (!string.IsNullOrEmpty(parameters.Director))
            {
                searchList = dvds.Where(x => x.Director.ToLower().Contains(parameters.Director.ToLower())).ToList();
            }

            if (!string.IsNullOrEmpty(parameters.Rating))
            {
                searchList = dvds.Where(x => x.Rating.ToLower().Contains(parameters.Rating.ToLower())).ToList();
            }

            if (parameters.ReleaseYear.HasValue)
            {
                searchList = dvds.Where(x => x.ReleaseYear.ToString().Contains(parameters.ReleaseYear.ToString())).ToList();
            }

            return searchList;
        }

        public void Update(Dvd dvd)
        {
            Dvd currentDvd = GetById(dvd.DvdId);

            currentDvd.Title = dvd.Title;
            currentDvd.Director = dvd.Director;
            currentDvd.Notes = dvd.Notes;
            currentDvd.Rating = dvd.Rating;
            currentDvd.ReleaseYear = dvd.ReleaseYear;
        }
    }
}
