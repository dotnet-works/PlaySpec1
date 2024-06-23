Feature: PlayActionTest1
A short summary of the feature

@tag1
Scenario: Test Playwright Actions1
	Given user navigates to "https://testautomationpractice.blogspot.com/"
	When Enter data in "Name:" label Textbox using "Fill" method
	And Enter data in "Name:" label Textbox using "Type" method
	And press key combo ctrl and A
	And Scroll To element
	When perform drag and drop operation
	When Get element diamension
	When scroll mouse forward 300 pixel verticalliy
	When select multi elements in selectbox using option
	When wait for 2 secs
	When refresh the page
	When wait for 5 secs
	When select single elements in selectbox using text value
	When wait for 2 secs
	When refresh the page
	When wait for 5 secs
	When click link using javascript with 0 secs delay
	When wait for 2 secs


@tag1
Scenario: Test execute Javascript Actions2
	Given user navigates to "https://testautomationpractice.blogspot.com/"
	When wait for 5 secs
	When click link using javascript with 10 secs delay
	When highlight and click element
	When wait for 2 secs



@tag3
Scenario: Test Handle Dialog Actions3
Playwright can interact with the web page dialogs 
such as alert, confirm, prompt as well as beforeunload confirmation.
	Given user navigates to "https://testautomationpractice.blogspot.com/"
	When wait for 2 secs
	When click alert button
	#When click on "Alert" button
	#When wait for 1 secs
	When click on "Confirm box" button
	When wait for 1 secs