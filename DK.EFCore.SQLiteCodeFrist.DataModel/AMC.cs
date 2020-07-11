using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DK.EFCore.SQLiteCodeFrist.DataModel
{
    [Table("T_AMC")]
    public class AMC
    {
        [Required]
        public int AMCId { get; set; }

        [Required(ErrorMessage = "Asset Management Company Title required")]
        [StringLength(100, ErrorMessage = "AMC Title too long (100 char).")]
        public string AMCTitle { get; set; }

        public IEnumerable<MutualFund> MutualFunds { get; set; }

        [Column("inDate")]
        public DateTime? InDate { get; set; } = DateTime.Today;
    }

}
