Feature: Sample2SocialNet2

Scenario: Sample2_SocialNetwork2
   Given user navigates to "https://www.opensource-socialnetwork.org/demo"
   When navigate to socialnetwork page
   When click on 'dob' form feild and select month 'Jan.'
   When click on 'dob' form feild and select year '2001'
   #When click on 'dob' form feild and select dob as  'Jan-01-2000'
   #Then verify birthdate should be in correct format eg;'04/01/2000'
