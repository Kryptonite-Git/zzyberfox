﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace User.Core.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 EmployeeId
        {
            get;
            set;
        }
        public string FirstName
        {
            get;
            set;
        }
        public string LastName
        {
            get;
            set;
        }
        public DateTime DateOfBirth
        {
            get;
            set;
        }
        public string PhoneNumber
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
    }
}
