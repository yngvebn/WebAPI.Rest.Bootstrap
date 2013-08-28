namespace RestAPI.Core.DataProviders
{
    public interface IProvideDataFor<T> : IProvideDataFor
    {
        void Fill(T model);
    }

    public interface IProvideDataFor
    {

    }
}