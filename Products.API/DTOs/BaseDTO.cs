﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Products.API.DTOs
{
    public abstract class BaseDTO : IValidatableObject
    {
        public virtual Guid Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext context)
        {
            if (Name.Length > 100)
            {
                yield return new ValidationResult("Name cannot be more than 100 characters.");
            }

            if (Description != null && Description.Length > 500)
            {
                yield return new ValidationResult("Description cannot be more than 500 characters.");
            }
            
        }
    }
}