﻿using BusinessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ICategoryService
    {
        CategoryDTO GetByIdAsync(int id);
        void CreateAsync(CategoryDTO category);
        void UpdateAsync(CategoryDTO category);
        void DeleteAsync(int id);
    }
}
