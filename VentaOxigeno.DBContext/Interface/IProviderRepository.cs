using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext
{
    public interface IProviderRepository
    {

        BaseResponse SearchById(int id);
        BaseResponse GetProvidersByDistrict(string distrito);
        BaseResponse SearchAllProvider();
        BaseResponse InsertNewProvider(EntityProvider provider);
        BaseResponse UpdateProvider(EntityProvider provider); 
    }
}
