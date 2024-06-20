﻿Feature: Sample2SocialNet2

Scenario: Sample2_SocialNetwork2
   Given user navigates to "https://www.opensource-socialnetwork.org/demo"
   When navigate to socialnetwork page
   When switch to new tab
   When click on 'dob' element and enter birtdate as "21 Oct. 2000"
   Then verify birthdate should be in dd/mm/yyyy format
   When enter new user data
   When open new tab and navigate to "https://www.yopmail.com"
   When go to newuser yopmail inbox
   And navigates to social network activation page
   And login with credentials using username and password
   #Then verify birthdate should be in correct format eg;'04/01/2000'
