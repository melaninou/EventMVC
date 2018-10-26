﻿using System;
using System.Collections.Generic;
using System.Text;
using Domain.Profile;

namespace Facade.Profile
{
    public static class ProfileViewModelFactory
    {
        public static ProfileViewModel Create(ProfileObject o)
        {
            var v = new ProfileViewModel
            {
                Name = o?.DbRecord.Name,
                ID = o?.DbRecord.ID,
                Location = o?.DbRecord.Location,
                Gender = o.DbRecord.Gender,
                Age = o?.DbRecord.Age
            };
            return v;
        }

    }
}