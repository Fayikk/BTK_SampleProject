﻿using AutoMapper;
using BTK_SampleProject.AppDbContext;
using BTK_SampleProject.Entities;
using BTK_SampleProject.Messages;
using BTK_SampleProject.Models;
using BTK_SampleProject.Response;
using BTK_SampleProject.Services.Interface;
using BTK_SampleProject_Business.FluentValidator;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace BTK_SampleProject.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly BaseResponseModel _responseModel;
        public CategoryService(ApplicationDbContext context,IMapper mapper,BaseResponseModel responseModel)
        {
            _responseModel = responseModel;
            _mapper = mapper;
            _context = context;
        }

        public async Task<BaseResponseModel> AddCategory(CategoryDTO model)
        {

            #region Mapleme
            //category.CategoryName = model.CategoryName;
            //category.CategoryDescription = model.CategoryDescription;
            Category category = _mapper.Map<Category>(model);
            #endregion

            var categoryValidator = new CategoryValidator();

            ValidationResult result = categoryValidator.Validate(category);

            if (!result.IsValid)
            {
                result.Errors.ForEach(x => _responseModel.Errors.Add(x.ErrorMessage));
                _responseModel.isSuccess = false;
                _responseModel.Message = ResponseMessages.Hata;
                return _responseModel;
            }



            await _context.Categories.AddAsync(category);
            if (await _context.SaveChangesAsync() > 0)
            {

                _responseModel.Data = category;
                _responseModel.isSuccess = true;
                _responseModel.Message = ResponseMessages.Eklendi;

                return _responseModel;
            }
            _responseModel.isSuccess = false;
            _responseModel.Message = ResponseMessages.Hata;
            return _responseModel;
        }

        public void DeleteCategory(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponseModel> GetCategory(Guid categoryId)
        {
            Category category = await _context
                    .Categories.FirstOrDefaultAsync(x => x.Id == categoryId);
            if (category == null) {
                return null;
            
            }
            _responseModel.Data = category;
            _responseModel.isSuccess = true;
            _responseModel.Message = ResponseMessages.Listelendi;
            return _responseModel;
        
        }

        public async Task<BaseResponseModel> UpdateCategory(Guid categoryId, UpdateCategoryDTO categoryDTO)
        {
            var category = await _context.Categories.FindAsync(categoryId);
            if (category is not null)
            {

                _mapper.Map(categoryDTO, category);
                _context.Categories.Update(category);
                if (await _context.SaveChangesAsync() > 0)
                {
                    _responseModel.Data = category;
                    _responseModel.isSuccess = true;
                    _responseModel.Message = ResponseMessages.Güncellendi;
                    return _responseModel;
                }
            }
            return null;
        }
    }
}
