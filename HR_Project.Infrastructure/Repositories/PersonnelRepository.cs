﻿using HR_Project.Domain.Entities.Concrete;
using HR_Project.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Infrastructure.Repositories
{
    public class PersonnelRepository : BaseRepository<Personnel>, IPersonnelRepository
    {
        public PersonnelRepository(HR_Context context) : base(context)
        {

        }
    }
}
