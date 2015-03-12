using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PList
{
    public enum PListToken
    {
        None,        
        Key,
        String,
        Null,
        StartAttributes,
        EndAttributes,
        StartDict,
        EndDict,
        StartIndexedDict,
        EndIndexedDict,
        StartTuple,
        EndTuple,
    }
}
