Setting Up the Project with Cosmos DB Emulator

Install and start the Cosmos DB Emulator on your local machine.

Create a NoSQL Cosmos DB database named DotNetApp.

Create two containers within the DotNetApp database:

ApplicationFormContainer with partition key /id.

CandidateInfoContainer with partition key /id.


Endpoints

1. Create Form Field
Use the POST method to store different types of questions:
Paragraph, YesNo, Dropdown, MultipleChoice, Date, Number.

Endpoint: /api/ApplicationForm/create-form-field

2. Edit Form Field
Use the PUT method to edit a question after creation.

Endpoint: /api/ApplicationForm/edit-form-field/{id}

3. Get Form Fields
Provide a GET endpoint to render questions based on their type.
Endpoint: /api/ApplicationForm/get-form-fields

These are the enums used for question types (Form field types)
  Paragraph, - 0
  YesNo,- 1
  Dropdown, - 2
  MultipleChoice, - 3
  Date, - 4
  Number - 5

4. Submit Candidate Application
Provide a POST endpoint for the front-end team to submit candidate applications.
Endpoint: /api/Candidate/get-candidate-details
Testing

you can also use Swagger UI to test the endpoints mentioned above.