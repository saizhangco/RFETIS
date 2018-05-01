using RfEleTagSysApp.FormModel;
using RfEleTagSysApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfEleTagSysApp.DAL
{
    public interface AddressMappingDAL
    {
        bool create(AddressMapping addrmapping);
        bool delete(long id);
        bool update(AddressMapping addrmapping);
        AddressMapping findMappingById(long id);
        AddressMapping findMappingByGuid(long medicineId);
        List<AddressMapping> list();
        bool empty();
    }
}
