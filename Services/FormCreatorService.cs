using CapitalPlacement.Models.DTOs;
using CapitalPlacement.Models.Entities;
using CapitalPlacement.Repositories;

namespace CapitalPlacement.Services
{
    public class FormCreatorService : IFormCreatorService
    {
        private readonly IApplicationFormRepository _applicationFormRepository;

        public FormCreatorService(IApplicationFormRepository applicationFormRepository)
        {
            _applicationFormRepository = applicationFormRepository;
        }
        public async Task<ApplicationFormField> CreateFormFieldAsync(ApplicationFormFieldDto fieldDto)
        {
            var field = MapToEntity(fieldDto);
            return await _applicationFormRepository.CreateFormFieldAsync(field);
        }
        public async Task<List<ApplicationFormField>> GetFormFieldsByTypeAsync(FieldType type)
        {
            return await _applicationFormRepository.GetFormFieldByType(type);
        }
        public async Task<ApplicationFormField> EditFormFieldAsync(Guid id, ApplicationFormFieldDto updatedFieldDto)
        {
            var updatedField = MapToEntity(updatedFieldDto);
            return await _applicationFormRepository.EditFormFieldAsync(id, updatedField);
        }
        public async Task DeleteFormFieldAsync(Guid id)
        {
            await _applicationFormRepository.DeleteFormFieldAsync(id);
        }
        private ApplicationFormField MapToEntity(ApplicationFormFieldDto fieldDto)
        {
            return new ApplicationFormField
            {
                QuestionText = fieldDto.QuestionText,
                AnswerOptions = fieldDto.AnswerOptions,
                FieldType = fieldDto.FieldType,
                IsRequired = fieldDto.IsRequired,
            };
        }
    }
}
