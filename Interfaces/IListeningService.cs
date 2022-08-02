using SistemaNomina.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaNomina.Interfaces
{
    public interface IListingService
    {
        Task<ListingModels.ListingResult> GetListFiltered(ListingModels.ListingRequest request);
    }
}
