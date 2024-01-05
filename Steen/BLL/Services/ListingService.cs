﻿using DAL.Contexts;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ListingService : IListingService
    {
        private readonly CarListContext _carListContext;

        public ListingService(CarListContext carListContext) 
        {
            _carListContext = carListContext;
        }

        public Listing CreateListing(string name)
        {
            //todo: tilføj validering på navn

            var listingId = Guid.NewGuid();

            var newListing = new Listing(new List<Car>(), name, listingId);

            _carListContext.ListingContext.AddListing(newListing);

            return newListing;
        }

        public List<Listing> GetListings()
        {
            return _carListContext.ListingContext.GetListings();
        }

        public Listing? GetListing(Guid listingId) 
        { 
            return _carListContext.ListingContext.GetListing(listingId); //Bør man smide en exception her, eller skal det være applicationlaget der håndterer det?
        }

        public void SaveListingToFile(Guid listingId)
        {
            _carListContext.ListingContext.SaveListingToFile(listingId);
        }

        public Listing ImportListingFromFile(string filename, string nameAfterImport)
        {
            return _carListContext.ListingContext.ImportListingFromFile(filename, nameAfterImport);
        }
    }
}
