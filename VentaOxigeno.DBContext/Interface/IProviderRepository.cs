using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext
{
    public interface IProviderRepository
    {

        BaseResponse SearchById(int id);
    }
}
