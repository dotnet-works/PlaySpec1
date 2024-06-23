@demo
Feature: SocialNetDemo Tests




Scenario: Sample1_SocialNetwork1
   Given user navigates to "https://www.opensource-socialnetwork.org/demo"
   When navigate to socialnetwork page
   When switch to new tab
   When click on 'dob' element and enter birtdate as "20 Oct. 2000"
   Then verify birthdate should be in dd/mm/yyyy format
   When enter new user data
   When open new tab and navigate to "https://www.yopmail.com"
   When verify email confirmation
