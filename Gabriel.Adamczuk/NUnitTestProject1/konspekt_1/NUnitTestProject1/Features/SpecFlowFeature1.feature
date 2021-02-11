Feature: Cash Class Unit Testing

@mytag
Scenario Outline: Multipy Cash by Value
Given Cash CHF 2
When Multipy by 0
Then Cash Value is 0


Scenario Outline: Multipy Cash by Value negative test
Given Cash CHF 5
When Multipy by <multiplyFirst>
And Multipy by <multiplySecond>
Then Cash Value is <result>
Examples:
| multiplyFirst | multiplySecond | result |
| 123			| 5				 | 23     |
| 546			| 23		     | 324    | 
| 1      		| 3 		     | 15     | 

