using CapitalPlacement.Data;
using CapitalPlacement.Models.Entities;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

namespace CapitalPlacement.Repositories
{
    public class ApplicationFormRepository : IApplicationFormRepository
    {
        private readonly CosmosDbService _cosmosDbService;
        private readonly Container _container;
        private readonly IExceptionHandler _exceptionHandler;
        public ApplicationFormRepository(CosmosDbService cosmosDbService, IExceptionHandler exceptionHandler)
        {
            _cosmosDbService = cosmosDbService ?? throw new ArgumentNullException(nameof(cosmosDbService));
            _container = _cosmosDbService.GetContainer("ApplicationFormContainer") ?? throw new NullReferenceException("Cosmos container is null.");
            _exceptionHandler = exceptionHandler ?? throw new ArgumentNullException(nameof(exceptionHandler));

        }
        public async Task<ApplicationFormField> CreateFormFieldAsync(ApplicationFormField field)
        {
            try
            {
                if (field == null)
                {
                    throw new ArgumentNullException(nameof(field));
                }
                field.Id = Guid.NewGuid();
                await _container.CreateItemAsync(field, new PartitionKey(field.Id.ToString()));
                return field;
            }
            catch (CosmosException ex)
            {
                _exceptionHandler.HandleException(ex, "An error occurred while creating the form field.");
                throw; 
            }
        }
        public async Task<List<ApplicationFormField>> GetFormFieldByType(FieldType type)
        {
            try
            {
                var query = _container.GetItemLinqQueryable<ApplicationFormField>().Where(field => field.FieldType == type).ToFeedIterator();

                var results = new List<ApplicationFormField>();

                while (query.HasMoreResults)
                {
                    var response = await query.ReadNextAsync();
                    results.AddRange(response.ToList());
                }

                return results;
            }
            catch (CosmosException ex)
            {
                _exceptionHandler.HandleException(ex, "An error occurred while getting form fields by type.");
                throw;
            }
        }

        public async Task<ApplicationFormField> EditFormFieldAsync(Guid id, ApplicationFormField updatedField)
        {
            try
            {
                updatedField.Id = id;
                var response = await _container.ReplaceItemAsync(updatedField, id.ToString());
                return response.Resource;
            }
            catch (CosmosException ex)
            {
                _exceptionHandler.HandleException(ex, "An error occurred while editing the form field.");
                throw; 
            }
        }

        public async Task DeleteFormFieldAsync(Guid id)
        {
            try
            {
                await _container.DeleteItemAsync<ApplicationFormField>(id.ToString(), new PartitionKey(id.ToString()));
            }
            catch (CosmosException ex)
            {
                _exceptionHandler.HandleException(ex, "An error occurred while deleting the form field.");
                throw;
            }
        }

    }
}
