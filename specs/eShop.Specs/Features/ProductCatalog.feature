Feature: Product Catalog

A short summary of the feature

Rule: Users (anonymous and authenticated) should be able to view items

Scenario: Anonymous user views a item with no color specified at home page
	Given the user is not authenticated
	And there is a product cataloged as
		| name | color | featured |
		|      |       | true     |
	And the product are based on model
		| name    | color |
		| Model A |       |
	When the user checks the product catalog page
	Then the catalog item should be listed as
		| name    | color |
		| Model A |       |

Scenario: Anonymous user views a product with no size specified
	Given [context]
	When [action]
	Then [outcome]

Scenario: User views catalog products
	Given [context]
	When [action]
	Then [outcome]

Rule: If product are not based on a model then the item name should be a product name

Scenario: User queries the product catalog and checks item name - (non-model-based product)
	Given there is a product with name 'Product A'
	And the product is not based on a model
	When the user queries the product catalog
	Then the catalog should contain a item with name 'Product A'

Scenario: User queries the product catalog by item name - (non-model-based product)
	Given there is a product with name 'Product A'
	And the product is not based on a model
	When the user queries the product catalog by item name 'Product A'
	Then the catalog should contain one item

Rule: If product are not based on a model then the item color should be a product color
Rule: If product are not based on a model then the item cannot have sizes variations
Rule: If product are not based on a model then the item cannot have color variations

Rule: If product are based on a model then the item name should be a model name

Scenario: User queries the product catalog and checks item name - (model-based product)
	Given there is a product
	And the product is based on a model with name 'Model A'
	When the user queries the product catalog
	Then the catalog should contain a item with name 'Model A'

Rule: If product are based on a model then the item can contains size variations

Rule: Admin can publish products
	
@admin
Scenario: Admin publishes product
	Given [context]
	When [action]
	Then [outcome]

