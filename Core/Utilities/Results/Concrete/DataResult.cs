using Core.Utilities.Results.Abstract;

namespace Core.Utilities.Results.Concrete
{
    public class DataResult<T> : Result, IDataResult<T>
    {


        public DataResult(T data, bool isSucces,string message):base(isSucces,message)
        {
            Data = data;
        }
        public DataResult(T data, bool isSucces):base(isSucces)
        {
            Data=data;
        }
        public T Data { get; }
    }
}
