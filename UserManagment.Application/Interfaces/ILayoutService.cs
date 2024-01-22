using UserManagment.Application.Models;
using UserManagment.Application.Models.Requests;
namespace UserManagment.Application.Interfaces
{
    public interface ILayoutService
    {
        /// <summary>
        /// Получение схемы
        /// <param name="request"></param>
        /// </summary>        
        /// <returns>empty if nothing found</returns>
        Task<LayoutDto> GetLayoutAsync(LayoutsRequest request);

        /// <summary>
        /// Добавление новой схемы
        /// </summary>
        /// <param name="item"></param>
        /// <returns>если больше 0 - Id записи, если меньше 0 - код ошибки</returns>
        Task<int> SetLayoutAsync(LayoutDto item);
    }
}
