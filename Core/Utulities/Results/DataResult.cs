using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utulities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, string message, bool succes) : base(succes, message)
        {
            Data = data;
        }
        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }
        public T Data { get; }
    }
}
