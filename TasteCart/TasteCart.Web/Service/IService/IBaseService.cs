using TasteCart.Web.Models;

namespace TasteCart.Web.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDto?>SendAsync(RequestDto requestDto);
    }
}
