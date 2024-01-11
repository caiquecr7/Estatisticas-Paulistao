namespace EstatisticasFutebol.Business_Logic.ApiServices.Interface
{
    public interface IGeneralApiService
    {
        Task<T> DeserializeAsync<T>(HttpResponseMessage response);
    }
}
