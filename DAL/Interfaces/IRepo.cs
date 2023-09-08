using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepo<TYPE, ID, RET, ID2>
    {
        List<TYPE> GetAll();
        TYPE Get(ID id);
        RET Insert(TYPE obj);
        RET Update(TYPE obj);
        RET Delete(ID id);
        RET GetByEmployeeCode(ID2 code, ID id);
        List<TYPE> Show(ID id);
    }
}
