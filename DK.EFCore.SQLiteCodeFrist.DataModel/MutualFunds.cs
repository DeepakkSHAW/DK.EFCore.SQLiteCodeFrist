﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DK.EFCore.SQLiteCodeFrist.DataModel
{
    [Table("T_MF")]
    public class MutualFund
    {
        [Required]
        public int MutualFundId { get; set; }

        [Required(ErrorMessage = "Mutual Fund Name required")]
        [StringLength(100, ErrorMessage = "Mutual Fund Name too long (100 char).")]
        public string MutualFundName { get; set; }

        public AMC AMC { get; set; }

        [Column("inDate")]
        public DateTime? InDate { get; set; } = DateTime.Today;
    }
}
