Feature: Home

A short summary of the feature

Rule: A positive message should be shown on the home page

Scenario: Welcome message is shown on home page
	When the user checks the home page
	Then the home page main message should be: "Welcome!"

Rule: The user name should be shown on the home page if logged in

Scenario: The logged-in user name is shown on home page
	Given the user is authenticated
	When the user checks the home page
	Then the user name of the user should be on the home page

Rule: Featured catalog items should be shown on the home page

Scenario: A featured item is shown on home page with no color specified
	Given the user is not authenticated
	And there is a product cataloged as
		| name | color | featured |
		|      |       | true     |
	And the product are based on model
		| name    | color |
		| Model A |       |
	When the user checks the home page
	Then the featured item should be listed as
		| name    | color |
		| Model A |       |

Rule: Featured products are shown on the home page

Scenario: A product is shown on home page with no color specified
	Given the user is not authenticated
	And there is a product cataloged as
		| name      | color | featured |
		| Product A |       | true     |
	When the user checks the home page
	Then the product should be listed as featured

Scenario: A product is shown on home page with no size specified
	Given [context]
	When [action]
	Then [outcome]

Scenario: User views featured catalog products
	Given [context]
	When [action]
	Then [outcome]
