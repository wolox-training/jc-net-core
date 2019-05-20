using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace test_net_core_mvc.Models.DataBase
{
    public class BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }


        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}