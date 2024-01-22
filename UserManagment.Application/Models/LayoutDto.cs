namespace UserManagment.Application.Models
{
#nullable enable
    public class LayoutDto
    {
        /// <summary>
        /// Логин пользователя в системе dr-wellreport
        /// </summary>
        public string? Login { get; set; }       
        
        /// <summary>
        /// таргет\название схемы
        /// </summary>
        public string? InterfaceType { get; set; }

        /// <summary>
        /// содержание схемы виджетов пользователя в формате JSON
        /// </summary>
        public string? SchemaBody { get; set; }
    }
#nullable disable
}
