using PartTrader.API.DTOs;
using PartTrader.API.Mock.Data;
using PartTrader.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartTrader.API.Mock
{
    public class DataAccess
    {
        public MockedParts mock;

        public DataAccess()
        {
            mock = new MockedParts();
        }

        /// <summary>
        /// Find the compatibles parts of an a Part
        /// </summary>
        /// <param name="partToFindCompatible"></param>
        /// <returns>the Part and its compatible Parts, if can't find anything returns an empty list</returns>
        internal List<PartsCompatible> FindCompatibleParts(List<Parts> partToFindCompatible)
        {
            List<PartsCompatible> returnList = new List<PartsCompatible>();
            foreach (var item in partToFindCompatible)
            {
                Parts returnValue = mock.MockParts.Find(x => x.PartId.Contains(item.PartId) && x.PartCode.Contains(item.PartCode));

                PartsCompatible value = new PartsCompatible
                {
                    CompatibleParts = (returnValue.CompatibleParts == null) ? new List<Parts>() : returnValue.CompatibleParts,
                    Description = returnValue.Description,
                    PartId = returnValue.PartId,
                    PartCode = returnValue.PartCode
                };
                returnList.Add(value);
            }

            return returnList;


        }

        internal List<Parts> GetFullCatalogue()
        {
            return mock.MockParts;
        }


        /// <summary>
        /// filters the catalogue data based in the filters
        /// </summary>
        /// <param name="filters"></param>
        /// <returns>returns a list of the Parts found with the search parameters, if can't find anything returns all the Parts</returns>
        internal List<Parts> GetFilteredCatalogue(PartsFilter filters)
        {
            List<Parts> returnSearch = GetFullCatalogue();
            if (!string.IsNullOrEmpty(filters.Description))
            {
                returnSearch = returnSearch.Where(x => x.Description.ToLower().Contains(filters.Description.ToLower())).ToList();
            }
            if (!string.IsNullOrEmpty(filters.PartId))
            {
                returnSearch = returnSearch.Where(x => x.PartId.ToLower().Contains(filters.PartId.ToLower())).ToList();
            }
            if (!string.IsNullOrEmpty(filters.PartCode))
            {
                returnSearch = returnSearch.Where(x => x.PartCode.ToLower().Contains(filters.PartCode.ToLower())).ToList();
            }
            if (filters.Price > 0)
            {
                returnSearch = returnSearch.Where(x => x.Price == (filters.Price)).ToList();
            }
            if (!string.IsNullOrEmpty(filters.BrandName))
            {
                returnSearch = returnSearch.Where(x => x.Brand.Name.ToLower().Contains(filters.BrandName.ToLower())).ToList();
            }

            return returnSearch;
        }

        internal void AddOrder(WorkOrder workOrder)
        {
            //empty method, should save the data in the storage data
        }
    }
}
