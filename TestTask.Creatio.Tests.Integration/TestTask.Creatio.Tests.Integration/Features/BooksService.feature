Feature: BookService API

 Background:
    Given Admin user logged in

 Scenario: Request has correct form
    Given Request json 'json/searchrequest_with_correct_format.json' send
    Then Response status code should be 200

 Scenario: Request with invalid data send
    Given Invalid request json was send
    |Path|
     |json/searchrequest_with_incorrect_data.json|
     |json/searchrequest_with_incorrect_field_name.json|
    Then Response status code should be 422