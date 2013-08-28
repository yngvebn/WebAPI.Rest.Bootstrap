namespace WebAPI.Rest.Bootstrap.Interfaces.DataProvider
{
    public interface IProvideDataFor<T> : IProvideDataFor
    {
        void Fill(T model);
    }

    public interface IProvideDataFor
    {

    }
}