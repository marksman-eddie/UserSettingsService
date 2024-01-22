using UserManagment.Core.Entities;

namespace UserManagment.Core.Contracts
{
    /// <summary>
    /// Сервис сохранения пользовательских настроек (схемы виджетов)
    /// </summary>  
    public interface ILayoutRepository: IDisposable       
    {
        /// <summary>
        /// Код возврата ошибки: настройки пользователя не найдены в БД.
        /// </summary>
        public const int ErrorNotFound = -1;

        /// <summary>
        /// Код возврата : успешно записано\обновлено
        /// </summary>
        public const int ResultCode = 1;

        /// <summary>
        /// Получение схемы или default
        /// <param name="newItem"></param>
        /// </summary>        
        /// <returns>emptyList if nothing found</returns>
        Task<Layout> GetOrDefaultAsync(string userLogin, string interfaceType);

        /// <summary>
        /// Получение схемы либо null
        /// </summary>
        /// <param name="userLogin"></param>
        /// <param name="interfaceType"></param>
        /// <returns>entity or null</returns>
        Task<Layout?> GetAsync(string userLogin, string interfaceType);

        /// <summary>
        /// Добавление новой схемы
        /// </summary>
        Task<int> CreateAsync(Layout entity);

        /// <summary>
        /// Обновление новой схемы
        /// </summary>
        Task<int> UpdateAsync(Layout entity); 
        
    }
}

