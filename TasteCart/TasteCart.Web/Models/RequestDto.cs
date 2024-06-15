using static TasteCart.Web.Utility.SD;

namespace TasteCart.Web.Models
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string ApiUrl { get; set; }
        public object Data {  get; set; }
        public string AccessToken {  get; set; }
    }
}
