using System.Threading.Tasks;

namespace News.Api
{
	internal interface IWebClient
	{
		Task<Result> GetDataAsync();
		Result GetData();
	}
}
