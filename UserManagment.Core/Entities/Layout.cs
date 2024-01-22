using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagment.Core.Entities
{
    [Table("t_layouts"), Comment("таблица для хранения схем интерфейсов")]
    public class Layout
    {
        [Key]
        [Column("user_login")]
        public string? UserLogin { get; set; }
                
        [Column("schema_body"), Comment("схема в json формате")]
        [StringLength(2550000)]
        public string? SchemaBody { get; set; }

        [Key]
        [Column("interface_type")]
        public string? InterfaceType { get; set; }
    }    
}
