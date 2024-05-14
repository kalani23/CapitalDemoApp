using CapitalPlacement.Data;
using CapitalPlacement.Models.DTOs;
using CapitalPlacement.Repositories;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

namespace CapitalPlacement.Services
{
    public class FormSubmissionService : IFormSubmissionService
    {
        private readonly CosmosDbService _cosmosDbService;
        private readonly Container _container;
        private readonly IExceptionHandler _exceptionHandler;
        public FormSubmissionService(CosmosDbService cosmosDbService, IExceptionHandler exceptionHandler)
        {
            _cosmosDbService = cosmosDbService ?? throw new ArgumentNullException(nameof(cosmosDbService));
            _container = _cosmosDbService.GetContainer("CandidateInfoContainer") ?? throw new NullReferenceException("Cosmos container is null.");
            _exceptionHandler = exceptionHandler ?? throw new ArgumentNullException(nameof(exceptionHandler));

        }
        public async Task<FormSubmissionDto> SubmitFormAsync(FormSubmissionDto formDto)
        {
            try
            {
                await _container.CreateItemAsync(formDto, new PartitionKey(formDto.Id.ToString()));
                return formDto;
            }
            catch (CosmosException ex)
            {
                _exceptionHandler.HandleException(ex, "An error occurred while creating the form field.");
                throw;
            }
        }
        public async Task<List<FormSubmissionDto>> GetDetailsAsync()
        {
            try
            {
                var iterator = _container.GetItemLinqQueryable<FormSubmissionDto>().ToFeedIterator();

                var submissions = new List<FormSubmissionDto>();
                while (iterator.HasMoreResults)
                {
                    var response = await iterator.ReadNextAsync();
                    submissions.AddRange(response.ToList());
                }
                return submissions;
            }
            catch (CosmosException ex)
            {
                _exceptionHandler.HandleException(ex, "An error occurred while retrieving form submissions.");
                throw;
            }
        }
    }
}
