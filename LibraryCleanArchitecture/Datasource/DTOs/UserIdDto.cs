﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClean.Datasource.DTOs
{
    public class UserIdDto
    {
        public readonly Guid id;

        public UserIdDto()
        {
            id = Guid.NewGuid();
        }

        public UserIdDto(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("Id is null, empty or whitespace.", nameof(id));
            }

            if (!Guid.TryParse(id, out var parsedId))
            {
                throw new ArgumentException("Unable to parse id as Guid.", nameof(id));
            }

            this.id = parsedId;
        }

        public override string ToString() => id.ToString();
    }
}
